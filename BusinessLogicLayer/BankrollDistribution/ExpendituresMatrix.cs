using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DbBlock;
using DataLayer.Entities;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class ExpendituresMatrix
    {
        private DataProvider Provider { get; set; }
        private FundModel CurrentFund { get; set; }

        public ExpendituresMatrix(string fundKey)
        {
            Provider = new DataProvider();
            CurrentFund = Provider.FindFundByKey(fundKey);
        }

        public decimal[,] GetMatrix()
        {
            var weeks = Provider.GetAllWeeksData();
            var expendituresNames = GetUniqueExpendituresNames();
            decimal[,] expenditureMatrix = new decimal[expendituresNames.Count, weeks.Length];

            for (int expCounter = 0; expCounter < expenditureMatrix.GetLength(0); expCounter++)
            {
                for (int weekCounter = 0; weekCounter < expenditureMatrix.GetLength(1); weekCounter++)
                {
                    var currentExp = Provider.FindExpenditureByWeekAndFundKey(weeks[weekCounter].Number, CurrentFund.Key, expendituresNames[expCounter]);
                    if (currentExp == null)
                        expenditureMatrix[expCounter, weekCounter] = 0;
                    else
                        expenditureMatrix[expCounter, weekCounter] = currentExp.MoneySum;
                }
            }

            return expenditureMatrix;
        }

        public List<string> GetUniqueExpendituresNames()
        {
            var allExpenditures = Provider.GetExpedituresByFundKey(CurrentFund.Key);
            List<string> uniqueExpendituresNames = new List<string>();

            foreach (var expenditure in allExpenditures)
            {
                if (!uniqueExpendituresNames.Contains(expenditure.Name))
                    uniqueExpendituresNames.Add(expenditure.Name);
            }

            return uniqueExpendituresNames;
        }
    }
}
