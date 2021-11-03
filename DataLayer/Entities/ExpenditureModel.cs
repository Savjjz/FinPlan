using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ExpenditureModel : EntityBase
    {
        /// <summary>
        /// Название затраты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сумма потраченных ДС
        /// </summary>
        public double MoneySum { get; set; }

        /// <summary>
        /// Связь 1 to many с Week
        /// </summary>
        public WeekModel Week { get; set; }
        public string WeekId { get; set; }

        /// <summary>
        /// Связь 1 to many с FundCondition
        /// </summary>
        public FundConditionModel FundCondition { get; set; }
        public string FundConditionId { get; set; }
    }
}
