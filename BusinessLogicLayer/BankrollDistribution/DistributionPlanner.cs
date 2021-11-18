using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class DistributionPlanner
    {
        /// <summary>
        /// Неделя, в которую осуществляется распределение
        /// </summary>
        public Week CurrentWeek { get; private set; }
        public DistributionPlanner(Week currentWeek) 
        {
            CurrentWeek = currentWeek;
        }
        public DistributionPlanner()
        {

        }

        public void DistributeMoneyForFunds(Bankroll bankroll, FundsGroup fundsGroup)
        {
            decimal transferSum = 0.0M;

            for(int counter = 0; counter < fundsGroup.FundsGroupA.Length; counter++)
            {
                if (counter == 0)
                {
                    DistributeFromGoods(fundsGroup.FundsGroupA[counter], bankroll);
                    transferSum += fundsGroup.FundsGroupA[counter].TotalMoney;
                }
                else if (counter == 1)
                {
                    DistributeFromService(fundsGroup.FundsGroupA[counter], bankroll);
                    transferSum += fundsGroup.FundsGroupA[counter].TotalMoney;
                }
                else
                {
                    DistributeFromGoodsAndService(fundsGroup.FundsGroupA[counter], bankroll);
                    transferSum += fundsGroup.FundsGroupA[counter].TotalMoney;
                }
            }

            bankroll.WithdrawMoney(transferSum);
            transferSum = 0.0M;

            for (int counter = 0; counter < fundsGroup.FundsGroupB.Length; counter++)
            {
                DistributeFromTotalSum(fundsGroup.FundsGroupB[counter], bankroll);
                transferSum += fundsGroup.FundsGroupB[counter].TotalMoney;
            }

            bankroll.WithdrawMoney(transferSum);

            for (int counter = 0; counter < fundsGroup.FundsGroupC.Length; counter++)
            {
                DistributeFromTotalSum(fundsGroup.FundsGroupC[counter], bankroll);
            }
        }

        private void DistributeFromGoods(Fund fund, Bankroll bankroll)
        {
            fund.AddMoneyWithPercents(bankroll.GooodsRevenue);
            decimal distributeFromService = 0;
            Revenue revenue = new Revenue(distributeFromService, fund.TotalMoney);
            fund.SetRevenue(revenue);
        }
        private void DistributeFromService(Fund fund, Bankroll bankroll)
        {
            fund.AddMoneyWithPercents(bankroll.ServiceRevenue);
            decimal distributeFromGoods = 0;
            Revenue revenue = new Revenue(fund.TotalMoney, distributeFromGoods);
            fund.SetRevenue(revenue);
        }

        private void DistributeFromTotalSum(Fund fund, Bankroll bankroll)
        {
            fund.AddMoneyWithPercents(bankroll.TotalSum);
            Revenue revenue = new Revenue(fund.TotalMoney);
            fund.SetRevenue(revenue);
        }

        private void DistributeFromGoodsAndService(Fund fund, Bankroll bankroll)
        {
            fund.AddMoneyWithPercents(bankroll.GooodsRevenue);
            fund.AddMoneyWithPercents(bankroll.ServiceRevenue);
            decimal moneyFromService = fund.PredictablePercent * bankroll.ServiceRevenue / 100;
            decimal moneyFromGoods = fund.PredictablePercent * bankroll.GooodsRevenue / 100;
            Revenue revenue = new Revenue(moneyFromService, moneyFromGoods);
            fund.SetRevenue(revenue);
        }
    }
}
