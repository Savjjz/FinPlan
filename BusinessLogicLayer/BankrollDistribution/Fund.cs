using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.AuxiliaryTypes;

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
        /// Источник из которого поступают деньги в фонд
        /// </summary>
        public MoneySourceType  MoneySourceType { get; private set; }

        public Fund(string key, decimal predictablePercent, MoneySourceType moneySourceType)
        {
            Key = key;
            PredictablePercent = predictablePercent;
            MoneySourceType = moneySourceType;
            TotalMoney = 0.0M;
        }

        public Fund(string key, decimal predictablePercent)
        {
            Key = key;
            PredictablePercent = predictablePercent;
            TotalMoney = 0.0M;
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
