using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.DbConfig;
using DataLayer.Entities;


namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class RevenueDataProvider
    {
        private DataContext DataContext { get; set; }

        public RevenueDataProvider()
        {
            DataContext = new DataContext();
        }

        public RevenueModel[] GetLastWeekRevenuesData()
        {
            WeekDataProvider provider = new WeekDataProvider();
            var revenues = DataContext.Revenues.Where(a => a.BankrollId == provider.FindLastWeek().Bankroll.Id).ToArray();
            return revenues;
        }

        public RevenueModel[] GetRevenuesDataByWeek(int weekNumber)
        {
            WeekDataProvider provider = new WeekDataProvider();
            var revenues = DataContext.Revenues.Where(a => a.BankrollId == provider.FindWeekByNumber(weekNumber).Bankroll.Id).ToArray();
            return revenues;
        }

        public RevenueModel FindRevenueToFundByWeek(string weekId, string fundId)
        {
            WeekDataProvider provider = new WeekDataProvider();
            var fund = DataContext.Funds.ToArray().FirstOrDefault(p => p.Id == fundId);
            var revenues = DataContext.Revenues.Where(a => a.BankrollId == provider.FindWeekById(weekId).Bankroll.Id).ToArray();
            var revenue = revenues.FirstOrDefault(p => p.FundId == fund.Id);
            return revenue;
        }
    }
}
