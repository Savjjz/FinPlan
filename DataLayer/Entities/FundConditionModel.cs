using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class FundConditionModel : EntityBase
    {
        /// <summary>
        /// ДС в фонде в некоторую неделю до финансового планирования 
        /// </summary>
        public decimal MoneySumBeforeFinPlan { get; set; }

        public decimal MoneySumAfterFinPlan { get; set; }
        /// <summary>
        /// Связь 1 to many с Week
        /// </summary>
        public WeekModel Week { get; set; }
        public string WeekId { get; set; }
        /// <summary>
        /// Связь 1 to many с Fund
        /// </summary>
        public FundModel Fund { get; set; }
        public string FundId { get; set; }
        public decimal PercentFromBankroll { get; set; }
        /// <summary>
        /// Связь 1 to many с Expenditure
        /// </summary>
        public List<ExpenditureModel> Expenditures { get; set; } = new List<ExpenditureModel>();
        /// <summary>
        /// Связь 1 to many с TransactionBetweenFund
        /// </summary>
        public List<TransactionBetweenFundsModel> TransactionBetweenFunds { get; set; } = new List<TransactionBetweenFundsModel>();
    }
}
