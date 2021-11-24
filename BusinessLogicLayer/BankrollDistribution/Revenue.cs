using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Revenue
    {

        public decimal TotalMoney { get; private set; }
        public decimal MoneyFromService { get; private set; }
        public decimal MoneyFromGoods { get; private set; }

        /// <summary>
        /// Конструктор для случаев, когда фонд получает деньги отдельно из дохода от продажи товаров и услуг
        /// </summary>
        /// <param name="moneyFromService">ДС от услуг</param>
        /// <param name="moneyFromGoods">ДС от товаров</param>
        public Revenue(decimal moneyFromService, decimal moneyFromGoods)
        {
            MoneyFromService = moneyFromService;
            MoneyFromGoods = moneyFromGoods;
            TotalMoney = moneyFromService + moneyFromGoods;
        }

        /// <summary>
        /// Конструктор для случаев, когда фонд получает деньги напрямую из маржи
        /// </summary>
        /// <param name="moneyInFund">ДС от маржи</param>
        public Revenue(decimal moneyInFund)
        {
            TotalMoney = moneyInFund;
            MoneyFromGoods = 0;
            MoneyFromService = 0;
        }
    }
}
