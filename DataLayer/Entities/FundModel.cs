using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.AuxiliaryTypes;

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
        /// Источник, из которого в фонд поступают деньги
        /// </summary>
        public MoneySourceType MoneySourceType { get; set; }

        /// <summary>
        /// Является ли фонд активным
        /// </summary>
        public bool IsAcitve { get; set; }

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
