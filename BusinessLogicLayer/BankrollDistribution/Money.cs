using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Money
    {
        public int Roubles { get; set; }
        public int Penny { get; set; }

        public Money(int roubles, int penny)
        {
            Roubles = roubles;
            Penny = penny;
        }
    }
}
