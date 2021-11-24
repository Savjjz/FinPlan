using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.AuxiliaryTypes;

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
            decimal totalSum = 0.0M;

            for (int columnCounter = 0; columnCounter < fundsGroup.FundsGroups.Length; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < fundsGroup.FundsGroups[columnCounter].Length; rowCounter++)
                {
                    switch (fundsGroup.FundsGroups[columnCounter][rowCounter].MoneySourceType)
                    {
                        case MoneySourceType.Goods:
                            DistributeFromGoods(fundsGroup.FundsGroups[columnCounter][rowCounter], bankroll);
                            totalSum += fundsGroup.FundsGroups[columnCounter][rowCounter].TotalMoney;
                            break;
                        case MoneySourceType.Service:
                            DistributeFromService(fundsGroup.FundsGroups[columnCounter][rowCounter], bankroll);
                            totalSum += fundsGroup.FundsGroups[columnCounter][rowCounter].TotalMoney;
                            break;
                        case MoneySourceType.ServiceAndGoods:
                            DistributeFromGoodsAndService(fundsGroup.FundsGroups[columnCounter][rowCounter], bankroll);
                            totalSum += fundsGroup.FundsGroups[columnCounter][rowCounter].TotalMoney;
                            break;
                        case MoneySourceType.Total:
                            DistributeFromTotalSum(fundsGroup.FundsGroups[columnCounter][rowCounter], bankroll);
                            totalSum += fundsGroup.FundsGroups[columnCounter][rowCounter].TotalMoney;
                            break;
                    }
                }
                bankroll.WithdrawMoney(totalSum);
                totalSum = 0.0M;
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
