using DataLayer.DbConfig;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class FundDataProvider
    {
        private DataContext DataContext { get; set; }

        public FundDataProvider()
        {
            DataContext = new DataContext();
        }

        /// <summary>
        /// Получить данные только по активным фондам
        /// </summary>
        /// <returns></returns>
        public FundModel[] GetActiveFunds()
        {
            var funds = DataContext.Funds.Where(p => p.IsAcitve == true).OrderBy(p => p.Key).ToArray();
            return funds;
        }

        /// <summary>
        /// Получить данные по всем фондам в бд
        /// </summary>
        /// <returns></returns>
        public FundModel[] GetAllFunds()
        {
            var funds = DataContext.Funds.OrderBy(p => p.Key).ToArray();
            return funds;
        }

        /// <summary>
        /// Получить данные по неактивынм фондам
        /// </summary>
        /// <returns></returns>
        public FundModel[] GetInactiveFunds()
        {
            var funds = DataContext.Funds.Where(p => p.IsAcitve == false).OrderBy(p => p.Key).ToArray();
            return funds;
        }

        /// <summary>
        /// Найти фонд по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FundModel FindFundById(string id)
        {
            var fund = DataContext.Funds.FirstOrDefault(p => p.Id == id);
            return fund;
        }

        /// <summary>
        /// Найти фонд по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public FundModel FindFundByKey(string key)
        {
            var fund = DataContext.Funds.FirstOrDefault(p => p.Key == key);
            return fund;
        }

        public FundModel FindAcitveFundByKey(string key)
        {
            var fund = DataContext.Funds.Where(p => p.IsAcitve).FirstOrDefault(p => p.Key == key);
            return fund;
        }

        public int GetFundGroupNumber(char number)
        {
            var funds = DataContext.Funds.ToArray().Where(p => p.Key.Contains(number));
            return funds.Count();
        }

        public int GetActiveFundGroupNumber(char number)
        {
            var funds = DataContext.Funds.Where(p => p.IsAcitve).ToArray().Where(p => p.Key.Contains(number));
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

        public List<string> GetActiveUniqueFundsGroupsNumbers()
        {
            var funds = DataContext.Funds.Where(p => p.IsAcitve).ToArray();
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

        public List<int> GetActiveFundsGroupsSizes(string[] fundsNumbers)
        {
            List<int> groupsSizes = new List<int>();

            foreach (var fundNumber in fundsNumbers)
            {
                int size = DataContext.Funds.Where(p => p.IsAcitve).ToArray().Where(p => p.Key.Contains(fundNumber)).Count();
                groupsSizes.Add(size);
            }

            return groupsSizes;
        }
    }
}
