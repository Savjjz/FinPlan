using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.DbConfig;
using DataLayer.Entities;


namespace BusinessLogicLayer.DbBlock.DataProviders
{
    public class BankrollDataProvider
    {
        private DataContext DataContext { get; set; }

        public BankrollDataProvider()
        {
            DataContext = new DataContext();
        }

        public BankrollModel FindLastBankroll()
        {
            WeekDataProvider provider = new WeekDataProvider();
            var bankrolls = DataContext.Bankrolls.ToArray();
            BankrollModel bankroll = bankrolls.FirstOrDefault(p => p.WeekId == provider.FindLastWeek().Id);
            return bankroll;
        }

        public BankrollModel FindFirstBankroll()
        {
            WeekDataProvider provider = new WeekDataProvider();
            var bankrolls = DataContext.Bankrolls.ToArray();
            BankrollModel bankroll = bankrolls.FirstOrDefault(p => p.WeekId == provider.FindFirstWeek().Id);
            return bankroll;
        }

        public BankrollModel FindBankrollByNumber(int number)
        {
            WeekDataProvider provider = new WeekDataProvider();
            var bankrolls = DataContext.Bankrolls.ToArray();
            BankrollModel bankroll = bankrolls.FirstOrDefault(p => p.WeekId == provider.FindWeekByNumber(number).Id);
            return bankroll;
        }

        public BankrollModel FindBankrollById(string id)
        {
            var bankroll = DataContext.Bankrolls.FirstOrDefault(p => p.Id == id);
            return bankroll;
        }
    }
}
