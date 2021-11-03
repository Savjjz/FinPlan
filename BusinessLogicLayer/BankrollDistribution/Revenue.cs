using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Revenue
    {

        public double TotalMoney { get; private set; }
        public double MoneyFromService { get; private set; }
        public double MoneyFromGoods { get; private set; }

        /// <summary>
        /// Конструктор для случаев, когда фонд получает деньги отдельно из дохода от продажи товаров и услуг
        /// </summary>
        /// <param name="moneyFromService">ДС от услуг</param>
        /// <param name="moneyFromGoods">ДС от товаров</param>
        public Revenue(double moneyFromService, double moneyFromGoods)
        {
            MoneyFromService = moneyFromService;
            MoneyFromGoods = moneyFromGoods;
            TotalMoney = moneyFromService + moneyFromGoods;
        }

        /// <summary>
        /// Конструктор для случаев, когда фонд получает деньги напрямую из маржи
        /// </summary>
        /// <param name="moneyInFund">ДС от маржи</param>
        public Revenue(double moneyInFund)
        {
            TotalMoney = moneyInFund;
            MoneyFromGoods = 0;
            MoneyFromService = 0;
        }

        public void AddMoney(double moneySum)
        {
            TotalMoney += moneySum;
        }

        public bool WithdrawMoney(double moneySum)
        {
            if (TotalMoney >= moneySum)
            {
                TotalMoney -= moneySum;
                return true;
            }
            return false;
        }

    }
}
