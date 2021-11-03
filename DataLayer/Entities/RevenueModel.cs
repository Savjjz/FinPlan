using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class RevenueModel : EntityBase
    {
        /// <summary>
        /// Доход от услуг
        /// </summary>
        public double SumFromService { get; set; }
        /// <summary>
        /// Доход от товаров
        /// </summary>
        public double SumFromGoods { get; set; }
        /// <summary>
        /// Общий доход
        /// </summary>
        public double TotalSum { get; set; }
        /// <summary>
        /// Связь 1 to many с Fund
        /// </summary>
        public FundModel Fund { get; set; }
        public string FundId { get; set; }
        /// <summary>
        /// Связь 1 to many с Fund
        /// </summary>
        public BankrollModel Bankroll { get; set; }
        public string BankrollId { get; set; }
    }
}
