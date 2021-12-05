using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.DbConfig;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class FundConditionDataProvider
    {
        private DataContext DataContext { get; set; }

        public FundConditionDataProvider()
        {
            DataContext = new DataContext(); 
        }

        /// <summary>
        /// Получить состояния активных фондов за все периоды
        /// </summary>
        /// <returns></returns>
        public FundConditionModel[] GetActiveFundsConditions()
        {
            var fundConditions = DataContext.FundConditions.Include(p => p.Fund).Where(p => p.Fund.IsAcitve).ToArray();
            return fundConditions;
        }

        /// <summary>
        /// Получить состояния неактивных фондов за все периоды
        /// </summary>
        /// <returns></returns>
        public FundConditionModel[] GetInactiveFundsConditions()
        {
            var fundConditions = DataContext.FundConditions.Include(p => p.Fund).Where(p => !p.Fund.IsAcitve).ToArray();
            return fundConditions;
        }

        /// <summary>
        /// Получить состояния всех фондов за все периоды
        /// </summary>
        /// <returns></returns>
        public FundConditionModel[] GetAllFundsConditions()
        {
            var fundConditions = DataContext.FundConditions.ToArray();
            return fundConditions;
        }

        /// <summary>
        /// Найти состояние фонда по id недели и фонда
        /// </summary>
        /// <param name="weekId"></param>
        /// <param name="fundId"></param>
        /// <returns></returns>
        public FundConditionModel FindFundCondition(string weekId, string fundId)
        {
            var fund = DataContext.Funds.Include(p => p.FundConditions).FirstOrDefault(p => p.Id == fundId);
            WeekModel week = DataContext.Weeks.FirstOrDefault(p => p.Id == weekId);
            FundConditionModel fundCondition = fund.FundConditions.FirstOrDefault(p => p.WeekId == week.Id);
            return fundCondition;
        }

        /// <summary>
        /// Получить состояния фондов по id недели
        /// </summary>
        /// <param name="weekId"></param>
        /// <returns></returns>
        public FundConditionModel[] GetFundConditionsByWeek(string weekId)
        {
            WeekDataProvider provider = new WeekDataProvider();
            var week = provider.FindLastWeek();
            var fundConditions = DataContext.FundConditions.Include(p => p.Fund).Where(p => p.WeekId == weekId).ToArray();
            fundConditions = fundConditions.OrderBy(p => p.Fund.Key).ToArray();
            return fundConditions;
        }

    }
}
