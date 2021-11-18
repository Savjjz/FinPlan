using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Fund
    {
        /// <summary>
        /// Код фонда
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// Сумма денег в фонде 
        /// </summary>
        public decimal TotalMoney { get; private set; }
        /// <summary>
        /// Процент от распределения денег в фонд
        /// </summary>
        public decimal PredictablePercent { get; private set; }
        /// <summary>
        /// Ссылка на распределение в фонд за текущую неделю
        /// </summary>
        public Revenue Revenue { get; private set; }
        /// <summary>
        /// Список расходов фонда за текущую неделю 
        /// </summary>
        public List<Expenditure> Expenditures { get; set; } = new List<Expenditure>();

        public Fund(string key, decimal totalMoney, decimal predictablePercent)
        {
            Key = key;
            TotalMoney = totalMoney;
            PredictablePercent = predictablePercent;
        }

        public Fund(string key, decimal predictablePercent)
        {
            Key = key;
            PredictablePercent = predictablePercent;
            TotalMoney = 0.0M;
        }

        /// <summary>
        /// Добавить деньги в фонд
        /// </summary>
        /// <param name="moneySum"></param>
        public void AddMoney(decimal moneySum)
        {
            TotalMoney += moneySum;
        }

        /// <summary>
        /// Добавить деньги в фонд за вычетом процентов
        /// </summary>
        /// <param name="moneySum"></param>
        public void AddMoneyWithPercents(decimal moneySum)
        {
            decimal totalMoney = moneySum * PredictablePercent / 100;
            TotalMoney += Math.Round(totalMoney, 2);
        }

        /// <summary>
        /// Списать деньги со счета фонда
        /// </summary>
        /// <param name="moneySum"></param>
        /// <returns></returns>
        public bool WithdrawMoney(Expenditure expenditure)
        {
            Expenditures.Add(expenditure);
            if (TotalMoney >= expenditure.TotalSum)
            {
                TotalMoney -= expenditure.TotalSum;
                return true;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Установить связь с распределением в фонд
        /// </summary>
        /// <param name="revenue"></param>
        public void SetRevenue(Revenue revenue)
        {
            Revenue = revenue;
        }

        /// <summary>
        /// Получить прогноз распределения ДС в фонд в течение месяца
        /// </summary>
        /// <returns></returns>
        public decimal GetMonthForecast()
        {
            decimal monthForecast = TotalMoney * 4;
            return Math.Round(monthForecast, 2);
        }


    }
}
