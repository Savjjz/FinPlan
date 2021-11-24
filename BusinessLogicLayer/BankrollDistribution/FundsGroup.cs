using BusinessLogicLayer.DbBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class FundsGroup
    {
        public Fund[] FundsGroupA { get; private set; }
        public Fund[] FundsGroupB { get; private set; } 
        public Fund[] FundsGroupC { get; private set; }

        /// <summary>
        /// все фонды вообще
        /// </summary>
        public Fund[] AllFunds { get; private set; }
        public Fund[][] FundsGroups { get; private set; }
        /// <summary>
        /// Буквы групп фондов
        /// </summary>
        private string[] FundGroupsNumber { get; set; }
        /// <summary>
        /// Количество фондов в каждой группе
        /// </summary>
        private int[] FundGroupsSizes { get; set; }

        public FundsGroup()
        {
            DataProvider provider = new DataProvider();
            FundDataProvider fundProvider = new FundDataProvider();

            FundGroupsNumber = fundProvider.GetUniqueFundsGroupsNumbers().ToArray();
            FundGroupsSizes = fundProvider.GetFundsGroupsSizes(FundGroupsNumber).ToArray();

            SetAllFundsData(provider, fundProvider);
            SetFundsGroupsData(provider, fundProvider);

            DeleteThisLater();
        }

        private void SetAllFundsData(DataProvider provider, FundDataProvider fundProvider)
        {
            AllFunds = new Fund[FundGroupsSizes.Sum()];
            int fundNumber = 1;
            int fundCounter = 0;

            for (int groupCounter = 0; groupCounter < FundGroupsNumber.Length; groupCounter++)
            {
                for (int counter = 0; counter < FundGroupsSizes[groupCounter]; counter++)
                {
                    string fundKey = FundGroupsNumber[groupCounter] + Convert.ToString(fundNumber);
                    var currentFund = provider.FindFundByKey(fundKey);
                    AllFunds[fundCounter] = new Fund(fundKey, currentFund.PercentFromBanckroll, currentFund.MoneySourceType);
                    fundNumber++;
                    fundCounter++;
                }
                fundNumber = 1;
            }
        }

        private void SetFundsGroupsData(DataProvider provider, FundDataProvider fundProvider)
        {
            FundsGroups = new Fund[FundGroupsNumber.Length][];
            int fundNumber = 1;

            for (int groupCounter = 0; groupCounter < FundGroupsNumber.Length; groupCounter++)
            {
                List<Fund> vs = new List<Fund>();
                for (int counter = 0; counter < FundGroupsSizes[groupCounter]; counter++)
                {
                    string fundKey = FundGroupsNumber[groupCounter] + Convert.ToString(fundNumber);
                    var currentFund = provider.FindFundByKey(fundKey);
                    vs.Add(new Fund(fundKey, currentFund.PercentFromBanckroll, currentFund.MoneySourceType));
                    fundNumber++;
                }
                fundNumber = 1;
                FundsGroups[groupCounter] = vs.ToArray();
            }
        }

        private void DeleteThisLater()
        {
            DataProvider provider = new DataProvider();
            FundDataProvider fundProvider = new FundDataProvider();
            FundsGroupA = new Fund[fundProvider.GetFundGroupNumber('A')];
            FundsGroupB = new Fund[fundProvider.GetFundGroupNumber('B')];
            FundsGroupC = new Fund[fundProvider.GetFundGroupNumber('C')];

            int fundNumber = 1;

            for (int counterA = 0; counterA < FundsGroupA.Length; counterA++)
            {
                string fundKey = "A" + Convert.ToString(fundNumber);
                FundsGroupA[counterA] = new Fund(fundKey, provider.FindFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }

            fundNumber = 1;
            for (int counterB = 0; counterB < FundsGroupB.Length; counterB++)
            {
                string fundKey = "B" + Convert.ToString(fundNumber);
                FundsGroupB[counterB] = new Fund(fundKey, provider.FindFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }

            fundNumber = 1;
            for (int counterC = 0; counterC < FundsGroupC.Length; counterC++)
            {
                string fundKey = "C" + Convert.ToString(fundNumber);
                FundsGroupC[counterC] = new Fund(fundKey, provider.FindFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }
        }
    }
}
