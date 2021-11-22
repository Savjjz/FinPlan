using DataLayer.DbConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.DbBlock
{
    public class FundDataProvider
    {
        DataContext DataContext;
        public FundDataProvider()
        {
            DataContext dataContext = new DataContext();
            DataContext = dataContext;
        }
 
        public int GetFundGroupNumber(char nubmber)
        {
            var funds = DataContext.Funds.ToArray().Where(p => p.Key.Contains(nubmber));
            return funds.Count();
        }
    }
}
