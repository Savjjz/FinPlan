using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class TransactionBetweenFundsModel : EntityBase
    {
        /// <summary>
        /// Величина перевода
        /// </summary>
        public decimal MoneySum { get; set; }
        /// <summary>
        /// Название транзакции
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Связь 1 to many с Week
        /// </summary>
        public string WeekId { get; set; }
        public WeekModel Week { get; set; }
        /// <summary>
        /// Связь 1 to many с FundCondition
        /// </summary>
        public string FundConditionId { get; set; }
        public FundConditionModel FundCondition { get; set; }
    }
}
