using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Bankroll
    {
        public double TotalSum { get; private set; }
        public double ServiceRevenue { get; private set; }
        public double GooodsRevenue { get; private set; }

        public Bankroll(double totalSum, double serviceRevenue, double goodsRevenue)
        {
            TotalSum = totalSum;
            ServiceRevenue = serviceRevenue;
            GooodsRevenue = goodsRevenue;
        }

        /// <summary>
        /// Рассчитать процент, приходящийся на доход от услуг к полной сумме
        /// </summary>
        /// <returns></returns>
        public double GetServiceRevenueFromTotalSum()
        {
            double number =  TotalSum / ServiceRevenue * 100;
            return Math.Round(number, 2);
        }

        /// <summary>
        /// Рассчитать процент, приходящийся на доход от товаров к полной сумме
        /// </summary>
        /// <returns></returns>
        public double GetGoodsRevenueFromTotalSum()
        {
            double number = TotalSum / GooodsRevenue * 100;
            return Math.Round(number, 2);
        }

        public void WithdrawMoney(double sum)
        {
            TotalSum -= sum;
        }
    }
}
