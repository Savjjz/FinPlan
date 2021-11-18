using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.DbConfig;
using DataLayer.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock
{
    public class DataProvider
    {
        private DataContext DbContext { get; set; }

        public DataProvider()
        {
            DbContext = new DataContext();
        }

        public ExpenditureModel[] GetAllExpendutiresData()
        {
            var expenditures = DbContext.Expenditures.ToArray();
            return expenditures;
        }

        /// <summary>
        /// Получить все затраты по коду фонда
        /// </summary>
        /// <param name="fundKey"></param>
        /// <returns></returns>
        public List<ExpenditureModel> GetExpedituresByFundKey(string fundKey)
        {
            var funds = DbContext.Funds.Include(p => p.FundConditions).ThenInclude(p => p.Expenditures).ToArray();
            FundModel currentFund = funds.FirstOrDefault(p => p.Key == fundKey);

            List<ExpenditureModel> expenditures = new List<ExpenditureModel>();
            foreach (var f in currentFund.FundConditions)
            {
                foreach (var e in f.Expenditures)
                {
                    expenditures.Add(e);
                }
            }
            return expenditures;
        }

        public int GetUniqueExpendituresNumberByFundKey(string fundKey)
        {
            var funds = DbContext.Funds.Include(p => p.FundConditions).ThenInclude(p => p.Expenditures).ToArray();
            FundModel currentFund = funds.FirstOrDefault(p => p.Key == fundKey);

            List<ExpenditureModel> expenditures = new List<ExpenditureModel>();
            foreach (var f in currentFund.FundConditions)
            {
                foreach (var e in f.Expenditures)
                {
                    expenditures.Add(e);
                }
            }

            List<string> uniqueExpendituresNames = new List<string>();
            foreach (var exp in expenditures)
            {
                if (!uniqueExpendituresNames.Contains(exp.Name))
                    uniqueExpendituresNames.Add(exp.Name);
            }

            return uniqueExpendituresNames.Count;
        }

        public decimal GetExpendituresSumInFundByWeek(int weekNumber, string fundKey)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var week = FindWeekByNumber(weekNumber);
            var fundConditions = DbContext.FundConditions.Where(p => p.FundId == fund.Id).ToArray();
            var fundCondition = fundConditions.FirstOrDefault(p => p.WeekId == week.Id);
            var expenditures = DbContext.Expenditures.Where(p => p.WeekId == week.Id).Where(p => p.FundConditionId == fundCondition.Id).ToArray();

            decimal expendituresSum = 0;
            foreach (var expenditure in expenditures)
            {
                expendituresSum += expenditure.MoneySum;
            }

            return expendituresSum;
        }

        public ExpenditureModel[] GetExpenditureArrayByWeekAndFund(int weekNumber, string fundKey)
        {
            var currentWeek = DbContext.Weeks.FirstOrDefault(p => p.Number == weekNumber);
            var currentFund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var currentFundCondition = DbContext.FundConditions.Include(p => p.Expenditures)
                .Where(p => p.FundId == currentFund.Id)
                .ToArray()
                .FirstOrDefault(p => p.WeekId == currentWeek.Id);
            return currentFundCondition.Expenditures.ToArray();
        }

        public ExpenditureModel FindExpenditureByWeekAndFundKey(int weekNumber, string fundKey, string expenditureName)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var week = FindWeekByNumber(weekNumber);
            var fundConditions = DbContext.FundConditions.Where(p => p.FundId == fund.Id).ToArray();
            var fundCondition = fundConditions.FirstOrDefault(p => p.WeekId == week.Id);
            var expenditures = DbContext.Expenditures.Where(p => p.WeekId == week.Id).Where(p => p.FundConditionId == fundCondition.Id).ToArray();
            var expenditure = expenditures.FirstOrDefault(p => p.Name == expenditureName);
            return expenditure;
        }

        /// <summary>
        /// Найти в бд состояния всех фондов на протяжение всех недель
        /// </summary>
        /// <returns>Матрица, где OX соответсвует неделям, а OY фонду</returns>
        public FundConditionModel[,] GetAllFundConditionsMatrix()
        {
            var weeks = DbContext.Weeks.OrderBy(a => a.Number).ToArray();
            var funds = DbContext.Funds.OrderBy(a => a.Key).ToArray();
            FundConditionModel[,] fundConditions = new FundConditionModel[funds.Length, weeks.Length];

            for (int weekCounter = 0; weekCounter < weeks.Length; weekCounter++)
            {
                var fundConditionsArr = DbContext.FundConditions
                                                    .Include(p => p.TransactionBetweenFunds)
                                                    .Where(p => p.WeekId == weeks[weekCounter].Id)
                                                    .ToArray(); 
                for (int fundCounter = 0; fundCounter < funds.Length; fundCounter++)
                {
                    fundConditions[fundCounter, weekCounter] = fundConditionsArr.FirstOrDefault(p => p.FundId == funds[fundCounter].Id);
                }
            }

            return fundConditions;
        }

        public List<TransactionBetweenFundsModel> GetTransactionsBetweenFundsByFundKey(string fundKey)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var fundsConditions = DbContext.FundConditions.Include(p => p.TransactionBetweenFunds).Where(p => p.FundId == fund.Id);
            List<TransactionBetweenFundsModel> transactions = new List<TransactionBetweenFundsModel>();

            foreach (var fundCondition in fundsConditions)
            {
                foreach (var transaction in fundCondition.TransactionBetweenFunds)
                {
                    transactions.Add(transaction);
                }
            }

            return transactions;
        }

        public TransactionBetweenFundsModel[] GetAllTransactionsBetweenFunds()
        {
            var transactions = DbContext.TransactionBetweenFunds.ToArray();
            return transactions;
        }

        public decimal GetTransactionsSumInFunByWeek(int weekNumber, string fundKey)
        {
            var fund = DbContext.Funds.FirstOrDefault(p => p.Key == fundKey);
            var week = FindWeekByNumber(weekNumber);
            var fundConditions = DbContext.FundConditions.Where(p => p.FundId == fund.Id).ToArray();
            var fundCondition = fundConditions.FirstOrDefault(p => p.WeekId == week.Id);
            var transactions = DbContext.TransactionBetweenFunds.Where(p => p.WeekId == week.Id).Where(p => p.FundConditionId == fundCondition.Id).ToArray();

            decimal transactionsSum = 0;
            foreach (var transaction in transactions)
            {
                transactionsSum += transaction.MoneySum;
            }

            return transactionsSum;
        }

        /// <summary>
        /// Найти в бд все состояния всех фондов
        /// </summary>
        /// <returns></returns>
        public FundConditionModel[] GetAllFundConditions()
        {
            var fundConditions = DbContext.FundConditions.ToArray();
            return fundConditions;
        }

        /// <summary>
        /// Найти в бд состояние фонда, соответствующее заданному коду фонда и номеру недели
        /// </summary>
        /// <param name="weekNumber"></param>
        /// <param name="fundKey"></param>
        /// <returns></returns>
        public FundConditionModel FindFundConditionByWeek(int weekNumber, string fundKey)
        {
            var fund = DbContext.Funds.Include(p => p.FundConditions).FirstOrDefault(p => p.Key == fundKey);
            WeekModel week = DbContext.Weeks.FirstOrDefault(p => p.Number == weekNumber);
            FundConditionModel fundCondition = fund.FundConditions.FirstOrDefault(p => p.WeekId == week.Id);
            return fundCondition;
        }

        /// <summary>
        /// Получить состояния фондов в некоторую неделю
        /// </summary>
        /// <param name="weekNumber"></param>
        /// <returns></returns>
        public FundConditionModel[] GetFundConditionsByWeek(int weekNumber)
        {
            var funds = DbContext.Funds.ToArray();
            var currentWeek = FindLastWeekInDb();
            FundConditionModel[] fundConditions = new FundConditionModel[funds.Length];
            
            for (int counter = 0; counter < funds.Length; counter++)
            {
                fundConditions[counter] = FindFundConditionByWeek(currentWeek.Number, funds[counter].Key);
            }

            fundConditions = fundConditions.OrderBy(p => p.Fund.Key).ToArray();

            return fundConditions;
        }

        /// <summary>
        /// Получить денежные средства, поступившие в прошлую неделю
        /// </summary>
        /// <returns></returns>
        public BankrollModel GetLastWeekBankrollData()
        {
            WeekModel lastWeek = FindLastWeekInDb();
            BankrollModel bankroll = lastWeek.Bankroll;
            return bankroll;
        }

        /// <summary>
        /// Получить массив всех фондов, отсортированных по коду фонда
        /// </summary>
        /// <returns></returns>
        public FundModel[] GetFundsData()
        {
            var funds = DbContext.Funds.OrderBy(a => a.Key).ToArray();
            return funds;
        }



        /// <summary>
        /// Получить распределение по фондам за последнюю неделю
        /// </summary>
        /// <returns></returns>
        public RevenueModel[] GetLastWeekRevenuesData()
        {
            var revenues = DbContext.Revenues.Where(a => a.BankrollId == FindLastWeekInDb().Bankroll.Id).ToArray();
            return revenues;
        }

        public RevenueModel[] GetRevenuesDataByWeek(int weekNumber)
        {
            var revenues = DbContext.Revenues.Where(a => a.BankrollId == FindWeekByNumber(weekNumber).Bankroll.Id).ToArray();
            return revenues;
        }

        public RevenueModel FindRevenueToFundByWeek(int weekNumber, string fundKey)
        {
            var fund = DbContext.Funds.ToArray().FirstOrDefault(p => p.Key == fundKey);
            var revenues = DbContext.Revenues.Where(a => a.BankrollId == FindWeekByNumber(weekNumber).Bankroll.Id).ToArray();
            var revenue = revenues.FirstOrDefault(p => p.FundId == fund.Id);
            return revenue;
        }

        /// <summary>
        /// Найти фонд в БД по коду фонда
        /// </summary>
        /// <param name="fundKey"></param>
        /// <returns></returns>
        public FundModel FindFundByKey(string fundKey)
        {
            FundModel fund = DbContext.Funds.FirstOrDefault(a => a.Key == fundKey);
            return fund;
        }

        /// <summary>
        /// Найти последнюю неделю в БД
        /// </summary>
        /// <returns></returns>
        public WeekModel FindLastWeekInDb()
        {
            var weeks = DbContext.Weeks.Include(a => a.Bankroll).ToList();
            WeekModel lastWeek = new WeekModel { Number = 0 };
            foreach (var w in weeks)
            {
                if (w.Number > lastWeek.Number)
                    lastWeek = w;
            }
            return lastWeek;
        }

        public WeekModel FindFirstWeekInDb()
        {
            var weeks = DbContext.Weeks.Include(a => a.Bankroll).ToList();
            WeekModel firstWeek = FindLastWeekInDb();
            foreach (var w in weeks)
            {
                if (w.Number < firstWeek.Number)
                    firstWeek = w;
            }
            return firstWeek;
        }

        /// <summary>
        /// Найти неделю в БД по номеру
        /// </summary>
        /// <param name="number">Номер недели</param>
        /// <returns></returns>
        public WeekModel FindWeekByNumber(int number)
        {
            var weeks = DbContext.Weeks.Include(a => a.Bankroll).ToList();
            var currentWeek = weeks.FirstOrDefault(p => p.Number == number);
            return currentWeek;
        }

        /// <summary>
        /// Получить все недели из БД, отсортированные по номеру
        /// </summary>
        /// <returns></returns>
        public WeekModel[] GetAllWeeksData()
        {
            var weeks = DbContext.Weeks.OrderBy(p => p.Number).ToArray();
            return weeks;
        }

        
    }
}
