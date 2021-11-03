using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.BankrollDistribution;
using DataLayer.DbConfig;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock
{
    public class DataAdder
    {
        private DataContext DbContext { get; set; }

        public DataAdder()
        {
            DbContext = new DataContext();
        }

        /// <summary>
        /// Добавить данные в бд
        /// </summary>
        /// <param name="fundsGroup">Группа фондов</param>
        /// <param name="week">Данные о текущей недели</param>
        /// <param name="bankroll">Данные о текущем распределении ДС</param>
        public void SetData(FundsGroup fundsGroup, Week week, Bankroll bankroll)
        {
            WeekModel weekModel = SetWeekData(week);
            BankrollModel bankrollModel = SetBankrollData(bankroll);
            bankrollModel.Week = weekModel;
            DbContext.Weeks.Add(weekModel);
            DbContext.Bankrolls.Add(bankrollModel);

            foreach (var currentFund in fundsGroup.FundsGroupA)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }
            foreach (var currentFund in fundsGroup.FundsGroupB)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }
            foreach (var currentFund in fundsGroup.FundsGroupC)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }

            DbContext.SaveChanges();
        }

        public void SetNewWeekData(Week week)
        {
            WeekModel weekModel = SetWeekData(week);
            DbContext.Weeks.Add(weekModel);
            DbContext.SaveChanges();
        }

        public void SetBankrollData(FundsGroup fundsGroup, Bankroll bankroll)
        {
            DataProvider provider = new DataProvider();
            var weekModel = DbContext.Weeks.FirstOrDefault(p => p.Id == provider.FindLastWeekInDb().Id);

            BankrollModel bankrollModel = SetBankrollData(bankroll);
            bankrollModel.Week = weekModel;
            DbContext.Bankrolls.Add(bankrollModel);

            foreach (var currentFund in fundsGroup.FundsGroupA)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }
            foreach (var currentFund in fundsGroup.FundsGroupB)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }
            foreach (var currentFund in fundsGroup.FundsGroupC)
            {
                AddDistributionData(currentFund, bankrollModel, weekModel);
            }

            DbContext.SaveChanges();
        }

        /// <summary>
        /// Добавить в бд новую затрату 
        /// </summary>
        /// <param name="fundKey">Ключ фонда, с которым связана затрата</param>
        /// <param name="expenditure">Затрата</param>
        public void AddExpenditure(string fundKey, Expenditure expenditure)
        {
            DataProvider dataProvider = new DataProvider();
            //Я хуй знает как это работает, но если присвоить неделе нарпямую значение метода, то вылетает ошибка с присвоением повторного
            //первичного ключа.  
            WeekModel week = DbContext.Weeks.FirstOrDefault(p => p.Id == dataProvider.FindLastWeekInDb().Id);
            var funds = DbContext.Funds.Include(p => p.FundConditions);
            FundModel fund = funds.FirstOrDefault(p => p.Key == fundKey);
            FundConditionModel fundCondition = fund.FundConditions.FirstOrDefault(p => p.WeekId == week.Id);

            if (fundCondition.MoneySumAfterFinPlan >= expenditure.TotalSum)
            {
                fundCondition.MoneySumAfterFinPlan -= expenditure.TotalSum;
                fund.TotalSum = fundCondition.MoneySumAfterFinPlan;
            }
            else
            {
                throw new Exception("Невозможно совершить оперцию: на счету фонда недостаточно средств");
            }

            if (dataProvider.FindExpenditureByWeekAndFundKey(week.Number, fundKey, expenditure.Name) == null)
            {
                ExpenditureModel expenditureModel = new ExpenditureModel
                {
                    Name = expenditure.Name,
                    MoneySum = expenditure.TotalSum,
                    Week = week,
                    FundCondition = fundCondition,
                };

                fundCondition.Expenditures.Add(expenditureModel);
                week.Expenditures.Add(expenditureModel);
            }
            else
            {
                var exp = dataProvider.FindExpenditureByWeekAndFundKey(week.Number, fundKey, expenditure.Name);
                var exp1 = DbContext.Expenditures.FirstOrDefault(p => p.Name == exp.Name);
                exp1.MoneySum += expenditure.TotalSum;
            }

            DbContext.SaveChanges();
        }

        /// <summary>
        /// Перевести деньги из одного фонда в другой
        /// </summary>
        /// <param name="donorFundKey">Фонд-донор</param>
        /// <param name="endowmentFundKey">Дотационный фонд</param>
        /// <param name="transferSum">Сумма транзакции</param>
        public void TransferMoneyBetweenFunds(string donorFundKey, string endowmentFundKey, double transferSum)
        {
            DataProvider provider = new DataProvider();
            var funds = DbContext.Funds.ToArray();
            var week = DbContext.Weeks.FirstOrDefault(p => p.Id == provider.FindLastWeekInDb().Id);
            FundModel donorFund = funds.FirstOrDefault(p => p.Key == donorFundKey);
            FundModel endowmentFund = funds.FirstOrDefault(p => p.Key == endowmentFundKey);
            var fundConditions = DbContext.FundConditions.Where(p => p.WeekId == week.Id);
            FundConditionModel donorFundCondition = fundConditions.FirstOrDefault(p => p.FundId == donorFund.Id);
            FundConditionModel endowmentFundCondition = fundConditions.FirstOrDefault(p => p.FundId == endowmentFund.Id);

            if (donorFundCondition.MoneySumAfterFinPlan >= transferSum)
            {
                donorFundCondition.MoneySumAfterFinPlan -= transferSum;
                donorFundCondition.MoneySumAfterFinPlan = Math.Round(donorFundCondition.MoneySumAfterFinPlan, 2);
                endowmentFundCondition.MoneySumAfterFinPlan += transferSum;
                endowmentFundCondition.MoneySumAfterFinPlan = Math.Round(endowmentFundCondition.MoneySumAfterFinPlan, 2);
                TransactionBetweenFundsModel donorTransaction = new TransactionBetweenFundsModel
                {
                    MoneySum = -transferSum,
                    FundCondition = donorFundCondition,
                    Name = "Перевод в фонд " + endowmentFund.Key,
                    Week = week
                };
                TransactionBetweenFundsModel endowmentTransaction = new TransactionBetweenFundsModel
                {
                    MoneySum = transferSum,
                    FundCondition = endowmentFundCondition,
                    Name = "Перевод из фонда " + donorFund.Key,
                    Week = week
                };
                DbContext.TransactionBetweenFunds.Add(donorTransaction);
                DbContext.TransactionBetweenFunds.Add(endowmentTransaction);
                DbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Невозможно совершить операцию: в фонде недостаточно средств");
            }
        }
         
        /// <summary>
        /// Добавить в бд новое состояние фонда в текущую неделю
        /// </summary>
        /// <param name="fund">Номер фонда</param>
        /// <param name="week">Номер текущей недели</param>
        private void AddFundConditionalData(FundModel fund, WeekModel week)
        {
            FundConditionModel fundCondition = new FundConditionModel
            {
                MoneySumBeforeFinPlan = fund.TotalSum,
                MoneySumAfterFinPlan = fund.TotalSum,
                Fund = fund,
                Week = week
            };
            DbContext.FundConditions.Add(fundCondition);
        }

       /// <summary>
       /// Распределить деньги в фонд
       /// </summary>
       /// <param name="fund">Фонд</param>
       /// <param name="bankrollModel">Денежное поступление</param>
       /// <param name="week">Текущая неделя</param>
        private void AddDistributionData(Fund fund, BankrollModel bankrollModel, WeekModel week)
        {
            var fundsInDb = DbContext.Funds.ToList();
            FundModel fundModel = fundsInDb.FirstOrDefault(p => p.Key == fund.Key);
            fundModel.TotalSum += Math.Round(fund.TotalMoney, 2);
            RevenueModel revenueModel = new RevenueModel
            {
                SumFromGoods = Math.Round(fund.Revenue.MoneyFromGoods, 2),
                SumFromService = Math.Round(fund.Revenue.MoneyFromService, 2),
                TotalSum = Math.Round(fund.Revenue.TotalMoney, 2),
                Fund = fundModel,
                Bankroll = bankrollModel
            };
            AddFundConditionalData(fundModel, week);
            fundModel.MonthForecast = fund.GetMonthForecast();
            fundModel.Revenues.Add(revenueModel);
            bankrollModel.Revenues.Add(revenueModel);
        }

        /// <summary>
        /// Добавить в бд новую неделю
        /// </summary>
        /// <param name="week">Данные текущей недели</param>
        /// <returns></returns>
        private WeekModel SetWeekData(Week week)
        {
            var weeks = DbContext.Weeks.ToList();
            if (!weeks.Any())
            {
                WeekModel initializingWeek = new WeekModel
                {
                    Number = week.WeekNumber,
                    Start = week.WeekStart,
                    End = week.WeekEnd,
                };
                return initializingWeek;
            }
            else
            {
                WeekModel previousWeek = new WeekModel { Number = 0 };
                foreach (var w in weeks)
                {
                    if (w.Number > previousWeek.Number)
                        previousWeek = w;
                }
                WeekModel weekModel = new WeekModel
                {
                    Start = week.WeekStart,
                    End = week.WeekEnd,
                    Number = previousWeek.Number + 1
                };
                return weekModel;
            }
        }

        /// <summary>
        /// Добавить в бд новое поступление ДС
        /// </summary>
        /// <param name="bankroll">Данные о новом поступлении ДС</param>
        /// <returns></returns>
        private BankrollModel SetBankrollData(Bankroll bankroll)
        {
            BankrollModel bankrollModel = new BankrollModel
            {
                ServiceRevenue = bankroll.ServiceRevenue,
                GoodsRevenue = bankroll.GooodsRevenue,
                TotalSum = bankroll.ServiceRevenue + bankroll.GooodsRevenue
            };
            return bankrollModel;
        }
    }
}
