using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    /// <summary>
    /// Сущность БД, отражающая денежные средства
    /// </summary>
    public class BankrollModel : EntityBase
    {
        /// <summary>
        /// Выручка ДС за отчетную неделю
        /// </summary>
        public decimal TotalSum { get; set; }
        /// <summary>
        /// Выручка от услуг
        /// </summary>
        public decimal ServiceRevenue { get; set; }
        /// <summary>
        /// Выручка от Продажи товаров
        /// </summary>
        public decimal GoodsRevenue { get; set; }
        /// <summary>
        /// Связь 1 to 1 с Week 
        /// </summary>
        public WeekModel Week { get; set; }
        public string WeekId { get; set; }
        /// <summary>
        /// Связь 1 to many с Revenue
        /// </summary>
        public List<RevenueModel> Revenues { get; set; } = new List<RevenueModel>();
    }
}
