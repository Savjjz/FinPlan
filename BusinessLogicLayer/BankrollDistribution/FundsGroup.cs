using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.DbBlock.DataProviders;
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
        public Fund[][] AllFunds { get; private set; }
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
            FundDataProvider fundProvider = new FundDataProvider();

            FundGroupsNumber = fundProvider.GetActiveUniqueFundsGroupsNumbers().ToArray();
            FundGroupsSizes = fundProvider.GetActiveFundsGroupsSizes(FundGroupsNumber).ToArray();

            SetFundsGroupsData(fundProvider);

            DeleteThisLater();
        }

        private void SetFundsGroupsData(FundDataProvider fundProvider)
        {
            AllFunds = new Fund[FundGroupsNumber.Length][];
            int fundNumber = 1;

            for (int groupCounter = 0; groupCounter < FundGroupsNumber.Length; groupCounter++)
            {
                List<Fund> vs = new List<Fund>();
                for (int counter = 0; counter < FundGroupsSizes[groupCounter]; counter++)
                {
                    string fundKey = FundGroupsNumber[groupCounter] + Convert.ToString(fundNumber);
                    var currentFund = fundProvider.FindAcitveFundByKey(fundKey);
                    vs.Add(new Fund(fundKey, currentFund.PercentFromBanckroll, currentFund.MoneySourceType));
                    fundNumber++;
                }
                fundNumber = 1;
                AllFunds[groupCounter] = vs.ToArray();
            }
        }

        private void DeleteThisLater()
        {
            FundDataProvider provider = new FundDataProvider();
            FundsGroupA = new Fund[provider.GetActiveFundGroupNumber('A')];
            FundsGroupB = new Fund[provider.GetActiveFundGroupNumber('B')];
            FundsGroupC = new Fund[provider.GetActiveFundGroupNumber('C')];

            int fundNumber = 1;

            for (int counterA = 0; counterA < FundsGroupA.Length; counterA++)
            {
                string fundKey = "A" + Convert.ToString(fundNumber);
                FundsGroupA[counterA] = new Fund(fundKey, provider.FindAcitveFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }

            fundNumber = 1;
            for (int counterB = 0; counterB < FundsGroupB.Length; counterB++)
            {
                string fundKey = "B" + Convert.ToString(fundNumber);
                FundsGroupB[counterB] = new Fund(fundKey, provider.FindAcitveFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }

            fundNumber = 1;
            for (int counterC = 0; counterC < FundsGroupC.Length; counterC++)
            {
                string fundKey = "C" + Convert.ToString(fundNumber);
                FundsGroupC[counterC] = new Fund(fundKey, provider.FindAcitveFundByKey(fundKey).PercentFromBanckroll);
                fundNumber++;
            }
        }
    }
}
