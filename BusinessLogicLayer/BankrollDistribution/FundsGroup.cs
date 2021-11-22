using BusinessLogicLayer.DbBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class FundsGroup
    {
        public Fund[] FundsGroupA { get; private set; }
        public Fund[] FundsGroupB { get; private set; } 
        public Fund[] FundsGroupC { get; private set; } 

        public FundsGroup()
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
