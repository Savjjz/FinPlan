using DataLayer.DbConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.DbBlock
{
    public class SpecificDataProvider
    {
        DataContext DataContext;
        public SpecificDataProvider()
        {
            DataContext dataContext = new DataContext();
            DataContext = dataContext;
        }
 
        public int GetFundGroupNumber(char nubmber)
        {
            var funds = DataContext.Funds.ToArray().Where(p => p.Key.Contains(nubmber));
            return funds.Count();
        }

        public List<string> GetUniqueFundsGroupsNumbers()
        {
            var funds = DataContext.Funds.ToArray();
            List<string> uniqueNumbers = new List<string>();

            foreach (var fund in funds)
            {
                string currentNumber = new String(fund.Key.Where(Char.IsLetter).ToArray());
                if (!uniqueNumbers.Contains(currentNumber))
                {
                    uniqueNumbers.Add(currentNumber);
                }
            }

            uniqueNumbers.Sort();
            return uniqueNumbers;
        }

        public List<int> GetFundsGroupsSizes(string[] fundsNumbers)
        {
            List<int> groupsSizes = new List<int>();

            foreach (var fundNumber in fundsNumbers)
            {
                int size = DataContext.Funds.ToArray().Where(p => p.Key.Contains(fundNumber)).Count();
                groupsSizes.Add(size);
            }

            return groupsSizes;
        }

    }
}
