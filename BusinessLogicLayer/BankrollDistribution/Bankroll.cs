using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Bankroll
    {
        public decimal TotalSum { get; private set; }
        public decimal ServiceRevenue { get; private set; }
        public decimal GooodsRevenue { get; private set; }

        public Bankroll(decimal totalSum, decimal serviceRevenue, decimal goodsRevenue)
        {
            TotalSum = totalSum;
            ServiceRevenue = serviceRevenue;
            GooodsRevenue = goodsRevenue;
        }

        public void WithdrawMoney(decimal sum)
        {
            TotalSum -= sum;
        }
    }
}
