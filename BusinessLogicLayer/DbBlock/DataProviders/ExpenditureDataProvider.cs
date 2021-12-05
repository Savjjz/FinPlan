using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.DbConfig;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class ExpenditureDataProvider
    {
        private DataContext DataContext { get; set; }

        public ExpenditureDataProvider()
        {
            DataContext = new DataContext();
        }

        /// <summary>
        /// Получить все затраты за все периоды
        /// </summary>
        /// <returns></returns>
        public ExpenditureModel[] GetAllExpendutiresData()
        {
            var expenditures = DataContext.Expenditures.ToArray();
            return expenditures;
        }

        /// <summary>
        /// Получить затраты за определнную неделю
        /// </summary>
        /// <param name="fundId"></param>
        /// <returns></returns>
        public ExpenditureModel[] GetExpedituresByFundId(string fundId)
        {
            var expenditures = DataContext.Expenditures.Where(p => p.FundCondition.FundId == fundId).ToArray();
            return expenditures;
        }

        /// <summary>
        /// Получить затраты за определенную неделю и фонд
        /// </summary>
        /// <param name="weekNumber"></param>
        /// <param name="fundKey"></param>
        /// <returns></returns>
        public ExpenditureModel[] GetExpenditureArrayByWeekAndFund(string weekId, string fundId)
        {
            var currentWeek = DataContext.Weeks.FirstOrDefault(p => p.Id == weekId);
            var currentFund = DataContext.Funds.ToArray().FirstOrDefault(p => p.Id== fundId);
            var currentFundCondition = DataContext.FundConditions.Include(p => p.Expenditures)
                .Where(p => p.FundId == currentFund.Id)
                .ToArray()
                .FirstOrDefault(p => p.WeekId == currentWeek.Id);
            return currentFundCondition.Expenditures.ToArray();
        }

    }
}
