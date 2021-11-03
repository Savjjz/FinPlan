using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    /// <summary>
    /// Сущность БД, отражающая неделю, по которой собираются данные
    /// </summary>
    public class WeekModel : EntityBase
    {
        /// <summary>
        /// Номер рабочей недели
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Дата начал недели
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Дата конца недели
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Отношение 1 to 1 с Bankroll
        /// </summary>
        public BankrollModel Bankroll { get; set; }
        /// <summary>
        /// Отношение 1 to many с Expenditure
        /// </summary>
        public List<ExpenditureModel> Expenditures { get; set; } = new List<ExpenditureModel>();

        /// <summary>
        /// Отношение 1 to many с FundCondition
        /// </summary>
        public List<FundConditionModel> FundConditions { get; set; } = new List<FundConditionModel>();
        /// <summary>
        /// Связь 1 to many с TransactionBetweenFund
        /// </summary>
        public List<TransactionBetweenFundsModel> TransactionBetweenFunds { get; set; } = new List<TransactionBetweenFundsModel>();
    }
}
