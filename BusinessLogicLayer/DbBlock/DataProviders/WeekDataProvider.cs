using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using DataLayer.DbConfig;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class WeekDataProvider
    {
        private DataContext DataContext { get; set; }

        public WeekDataProvider()
        {
            DataContext = new DataContext();
        }

        /// <summary>
        /// Найти последнюю добавленую неделю в бд
        /// </summary>
        /// <returns></returns>
        public WeekModel FindLastWeek()
        {
            var weeks = DataContext.Weeks.ToArray();
            WeekModel lastWeek = new WeekModel { Number = 0 };
            foreach (var w in weeks)
            {
                if (w.Number > lastWeek.Number)
                    lastWeek = w;
            }
            return lastWeek;
        }
        
        /// <summary>
        /// Найти первую добавленную неделю в бд
        /// </summary>
        /// <returns></returns>
        public WeekModel FindFirstWeek()
        {
            var weeks = DataContext.Weeks.ToArray();
            WeekModel firstWeek = FindLastWeek();
            foreach (var w in weeks)
            {
                if (w.Number < firstWeek.Number)
                    firstWeek = w;
            }
            return firstWeek;
        }

        /// <summary>
        /// Найти неделю в бд  по номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public WeekModel FindWeekByNumber(int number)
        {
            var week = DataContext.Weeks.ToArray().FirstOrDefault(p => p.Number == number);
            return week;
        }

        /// <summary>
        /// Найти неделю в бд по 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WeekModel FindWeekById(string id)
        {
            var week = DataContext.Weeks.Include(p => p.Bankroll).ToArray().First(p => p.Id == id);
            return week;
        }

    }
}
