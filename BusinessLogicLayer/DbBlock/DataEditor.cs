using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.DbConfig;
using DataLayer.Entities;
using BusinessLogicLayer.BankrollDistribution;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock
{
    public class DataEditor
    {
        private DataContext DbContext { get; set; }
        private DataProvider Provider { get; set; }
        private WeekModel CurrentWeek { get; set; }

        public DataEditor()
        {
            DbContext = new DataContext();
            Provider = new DataProvider();
            CurrentWeek = Provider.FindLastWeekInDb();
        }

        /// <summary>
        /// Редактирование данных распределения ДС
        /// </summary>
        /// <param name="weekNumber">Номер недели, во время которой были внесены ДС</param>
        /// <param name="correctBankroll">Корректное распределение ДС</param>
        public void EditBankrollData(Bankroll correctBankroll)
        {
            DataProvider provider = new DataProvider();
            var currentWeek = DbContext.Weeks.Include(p => p.Bankroll).FirstOrDefault(p => p.Id == CurrentWeek.Id);
            var currentBanroll = DbContext.Weeks.FirstOrDefault(p => p.Number == currentWeek.Number).Bankroll;
            currentBanroll.GoodsRevenue = correctBankroll.GooodsRevenue;
            currentBanroll.ServiceRevenue = correctBankroll.ServiceRevenue;
            currentBanroll.TotalSum = correctBankroll.TotalSum;
            EditDistributionData(correctBankroll);
            DbContext.SaveChanges();
        }

        private void EditDistributionData(Bankroll correctBankroll)
        {
            var week = DbContext.Weeks.Include(p => p.Bankroll).ThenInclude(p => p.Revenues).FirstOrDefault(p => p.Id == CurrentWeek.Id);
            var funds = DbContext.Funds.Include(p => p.FundConditions).ToArray();
            var fundsConditions = DbContext.FundConditions.Where(p => p.WeekId == CurrentWeek.Id).ToArray();

            week.Bankroll.TotalSum = correctBankroll.TotalSum;
            week.Bankroll.ServiceRevenue = correctBankroll.ServiceRevenue;
            week.Bankroll.GoodsRevenue = correctBankroll.GooodsRevenue;

            FundsGroup fundsGroup = new FundsGroup();
            DistributionPlanner planner = new DistributionPlanner();
            planner.DistributeMoneyForFunds(correctBankroll, fundsGroup);
            
            for (int counter = 0; counter < week.Bankroll.Revenues.Count; counter++)
            {
                foreach (var fundGroupA in fundsGroup.FundsGroupA)
                {
                    if (funds[counter].Key == fundGroupA.Key)
                    {
                        var revenue = week.Bankroll.Revenues.FirstOrDefault(p => p.FundId == funds[counter].Id);
                        revenue.SumFromGoods = Math.Round(fundGroupA.Revenue.MoneyFromGoods, 2);
                        revenue.SumFromService = Math.Round(fundGroupA.Revenue.MoneyFromService, 2);
                        revenue.TotalSum = Math.Round(fundGroupA.Revenue.TotalMoney, 2);
                        EditFundConditionData(funds[counter], revenue);
                    }
                }
                foreach (var fundGroupB in fundsGroup.FundsGroupB)
                {
                    if (funds[counter].Key == fundGroupB.Key)
                    {
                        var revenue = week.Bankroll.Revenues.FirstOrDefault(p => p.FundId == funds[counter].Id);
                        revenue.SumFromGoods = Math.Round(fundGroupB.Revenue.MoneyFromGoods, 2);
                        revenue.SumFromService = Math.Round(fundGroupB.Revenue.MoneyFromService, 2);
                        revenue.TotalSum = Math.Round(fundGroupB.Revenue.TotalMoney, 2);
                        EditFundConditionData(funds[counter], revenue);
                    }
                }
                foreach (var fundGroupC in fundsGroup.FundsGroupC)
                {
                    if (funds[counter].Key == fundGroupC.Key)
                    {
                        var revenue = week.Bankroll.Revenues.FirstOrDefault(p => p.FundId == funds[counter].Id);
                        revenue.SumFromGoods = Math.Round(fundGroupC.Revenue.MoneyFromGoods, 2);
                        revenue.SumFromService = Math.Round(fundGroupC.Revenue.MoneyFromService, 2);
                        revenue.TotalSum = Math.Round(fundGroupC.Revenue.TotalMoney, 2);
                        EditFundConditionData(funds[counter], revenue);
                    }
                }
            }
        }

        private void EditFundConditionData(FundModel fund, RevenueModel revenue)
        {
            var fundsConditions = DbContext.FundConditions.Where(p => p.WeekId == CurrentWeek.Id).ToArray();
            var fundCondition = fundsConditions.FirstOrDefault(p => p.FundId == fund.Id);

            decimal previousFundBalance = 0;
            if (CurrentWeek.Number != Provider.FindFirstWeekInDb().Number)
            {
                var previousWeek = DbContext.Weeks.FirstOrDefault(p => p.Number == CurrentWeek.Number - 1);
                var previousFundsConditions = DbContext.FundConditions.Where(p => p.WeekId == previousWeek.Id);
                var previousFundCondition = previousFundsConditions.FirstOrDefault(p => p.FundId == fund.Id);
                previousFundBalance = previousFundCondition.MoneySumAfterFinPlan;
            }

            var expenditures = DbContext.Expenditures
                .Where(p => p.WeekId == CurrentWeek.Id)
                .ToArray()
                .Where(p => p.FundConditionId == fundCondition.Id);

            decimal expendituresSum = 0;
            foreach(var expenditure in expenditures)
            {
                expendituresSum += expenditure.MoneySum;
            }

            var transactions = DbContext.TransactionBetweenFunds
                .Where(p => p.WeekId == CurrentWeek.Id)
                .ToArray()
                .Where(p => p.FundConditionId == fundCondition.Id);

            decimal transactionsSum = 0;
            foreach(var transaction in transactions)
            {
                transactionsSum += transaction.MoneySum;
            }

            decimal newBalanceBeforeFinPlan = previousFundBalance + revenue.TotalSum;
            decimal newBalanceAfterFinPlan = newBalanceBeforeFinPlan - expendituresSum + transactionsSum;
            fundCondition.MoneySumBeforeFinPlan = Math.Round(newBalanceBeforeFinPlan, 2);
            fundCondition.MoneySumAfterFinPlan = Math.Round(newBalanceAfterFinPlan, 2);
        }

        /// <summary>
        /// Редактирование данных затраты
        /// </summary>
        /// <param name="weekNumber">Номер недели, когда затрата была совершена</param>
        /// <param name="fundKey">Номер фонда, на который приходится затрата</param>
        /// <param name="expenditureName">Название затраты</param>
        /// <param name="correctExpenditure">Корректная затрата</param>
        public void EditExpenditureData(string fundKey, string expenditureId, Expenditure correctExpenditure)
        {
            DataProvider provider = new DataProvider();
            var currentWeek = DbContext.Weeks.FirstOrDefault(p => p.Id == provider.FindLastWeekInDb().Id);
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var week = DbContext.Weeks.FirstOrDefault(p => p.Number == currentWeek.Number);

            var fundCondition = DbContext.FundConditions
                                .Include(p => p.Expenditures)
                                .Where(p => p.FundId == fund.Id).ToArray()
                                .FirstOrDefault(p => p.WeekId == week.Id);

            var expenditure = fundCondition.Expenditures.FirstOrDefault(p => p.Id == expenditureId);
            fundCondition.MoneySumAfterFinPlan = Math.Round(fundCondition.MoneySumAfterFinPlan + correctExpenditure.TotalSum - expenditure.MoneySum, 2);
            expenditure.MoneySum = correctExpenditure.TotalSum;
            expenditure.Name = correctExpenditure.Name;
            DbContext.SaveChanges();
        }

        public void DeleteExpenditure(string fundKey, string expenditureId)
        {
            DataProvider provider = new DataProvider();
            var currentWeek = DbContext.Weeks.FirstOrDefault(p => p.Id == provider.FindLastWeekInDb().Id);
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var week = DbContext.Weeks.FirstOrDefault(p => p.Number == currentWeek.Number);

            var fundCondition = DbContext.FundConditions
                                .Include(p => p.Expenditures)
                                .Where(p => p.FundId == fund.Id).ToArray()
                                .FirstOrDefault(p => p.WeekId == week.Id);

            var expenditure = fundCondition.Expenditures.FirstOrDefault(p => p.Id == expenditureId);
            fundCondition.MoneySumAfterFinPlan = Math.Round(fundCondition.MoneySumAfterFinPlan + expenditure.MoneySum, 2);
            DbContext.Expenditures.Remove(expenditure);
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Редактировать проценты от распределения в фонды
        /// </summary>
        /// <param name="funds"></param>
        public void EdditFundsPercentsData(Fund[] funds)
        {
            foreach (var fund in funds)
            {
                DbContext.Funds.FirstOrDefault(p => p.Key == fund.Key).PercentFromBanckroll = fund.PredictablePercent;
            }
            DbContext.SaveChanges();
        }

        public void EdditFundName(string fundKey, string newName)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            fund.Name = newName;
            DbContext.SaveChanges();
        }

        public void DeactivateFund(string fundId)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Id == fundId);
            fund.IsAcitve = false;
            DbContext.SaveChanges();
        }

        public void ActivateFund(string fundId)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Id == fundId);
            fund.IsAcitve = true;
            DbContext.SaveChanges();
        }
    }
}
