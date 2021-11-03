using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class FinancialPlanner
    {
        public Fund Fund { get; private set; }
        public Week Week { get; private set; }
        public List<Expenditure> Expenditures { get; private set; } = new List<Expenditure>();

        public FinancialPlanner(Fund fund, Week week)
        {
            Fund = fund;
            Week = week;
        }

        public void SetExpenditure(Expenditure expenditure)
        {
            Expenditures.Add(expenditure);
            Fund.WithdrawMoney(expenditure);

        }
    }
}
