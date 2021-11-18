using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    /// <summary>
    /// Сущность БД, отражающая Фонд
    /// </summary>
    public class FundModel : EntityBase
    {
        /// <summary>
        /// Название фонда
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код фонда
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Процент распределения в фонд от ДС
        /// </summary>
        public decimal PercentFromBanckroll { get; set; }
        /// <summary>
        /// Сумма денег в фонде
        /// </summary>
        public decimal TotalSum { get; set; }
        /// <summary>
        /// Прогноз распределения в фонд за месяц
        /// </summary>
        public decimal MonthForecast { get; set; }
        /// <summary>
        /// Связь many to many с Bankroll
        /// </summary>
        public List<BankrollModel> Bankrolls { get; set; } = new List<BankrollModel>();
        /// <summary>
        /// Связь 1 to many с Revenue
        /// </summary>
        public List<RevenueModel> Revenues { get; set; } = new List<RevenueModel>();
        /// <summary>
        /// Связь 1 to many с FundCondition
        /// </summary>
        public List<FundConditionModel> FundConditions { get; set; } = new List<FundConditionModel>();
    }
}
