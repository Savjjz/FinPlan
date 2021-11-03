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
            FundsGroupA = new Fund[]
            {
                new Fund("A1", 80.0),
                new Fund("A2", 20.0),
                new Fund("A3", 3.0),
                new Fund("A4", 1.0)
            };
            FundsGroupB = new Fund[]
            {
                new Fund("B1", 3.30),
                new Fund("B2", 13.0),
                new Fund("B3", 9.0),
                new Fund("B4", 45.0),
                new Fund("B5", 5.0),
                new Fund("B6", 18.0),
                new Fund("B7", 4.5),
                new Fund("B8", 0.28)
            };
            FundsGroupC = new Fund[]
            {
                new Fund("C1", 29.0),
                new Fund("C2", 29.0),
                new Fund("C3", 42.0)
            };
        }

        public FundsGroup(Fund[] fundsGroupA, Fund[] fundsGroupB, Fund[] fundsGroupC)
        {
            FundsGroupA = fundsGroupA;
            FundsGroupB = fundsGroupB;
            FundsGroupC = fundsGroupC;
        }

        public Fund[] GetAllFunds()
        {
            Fund[] allFunds = new Fund[FundsGroupA.Length + FundsGroupB.Length + FundsGroupC.Length];
            int counter = 0;

            foreach (var fund in FundsGroupA)
            {
                allFunds[counter] = fund;
                counter++;
            }
            foreach (var fund in FundsGroupB)
            {
                allFunds[counter] = fund;
                counter++;
            }
            foreach (var fund in FundsGroupC)
            {
                allFunds[counter] = fund;
                counter++;
            }

            return allFunds;
        }
    }
}
