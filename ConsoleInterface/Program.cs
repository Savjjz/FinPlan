using System;
using DataLayer.Entities;
using DataLayer.DbConfig;
using BusinessLogicLayer.BankrollDistribution;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.ExcelBlock;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.DbBlock.DataProviders;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Для ФРС нажмите 1");
            //Console.WriteLine("Для ДДС нажмите 2");
            //Console.WriteLine("Для добавления ДС нажмите 3");
            //Console.WriteLine("Для добавления затрат нажмите 4");
            //Console.WriteLine("Для перевода денег между фондами нажмите 5");
            //Console.WriteLine("Для редактирования данных распределения нажмите 6");
            //int i = Convert.ToInt32(Console.ReadLine());

            //if (i == 1)
            //{
            //    DataProvider provider = new DataProvider();
            //    FormDistributionOfFundsTable table = new FormDistributionOfFundsTable(provider, 23);
            //}
            //else if (i == 2)
            //{
            //    DataProvider provider = new DataProvider();
            //    TableBase table = new BankrollTraficTable(provider);
            //}
            //else if (i == 3)
            //{
            //    DateTime weekStart = new DateTime(2021, 5, 20);
            //    DateTime weekEnd = new DateTime(2021, 5, 25);
            //    FundsGroup fundsGroup = new FundsGroup();
            //    Week week = new Week(weekStart, weekEnd);
            //    Bankroll bankroll = new Bankroll(3350000.00, 2010000.00, 1340000.00);
            //    DistributionPlanner planner = new DistributionPlanner(week);
            //    planner.DistributeMoneyForFunds(bankroll, fundsGroup);
            //    DataAdder dataAdder = new DataAdder();
            //    dataAdder.SetData(fundsGroup, week, bankroll);

            //}
            //else if (i == 4)
            //{
            //    DataAdder dataAdder = new DataAdder();
            //    Expenditure expenditure = new Expenditure(162429.06, "СД-СЕРВИС ООО");
            //    dataAdder.AddExpenditure("A1", expenditure);
            //    Expenditure expenditure1 = new Expenditure(25936.00, "АВА-ЛОТ ООО");
            //    dataAdder.AddExpenditure("A2", expenditure1);
            //    Expenditure expenditure2 = new Expenditure(72147.67, "ГетЧипс ООО");
            //    dataAdder.AddExpenditure("A2", expenditure2);
            //    Expenditure expenditure3 = new Expenditure(27940.00, "Гофромир ООО");
            //    dataAdder.AddExpenditure("A2", expenditure3);
            //    Expenditure expenditure4 = new Expenditure(39419.53, "МЕТТАТРОН Группа");
            //    dataAdder.AddExpenditure("A2", expenditure4);
            //    Expenditure expenditure5 = new Expenditure(14055.60, "МИКРОЛИТ ООО");
            //    dataAdder.AddExpenditure("A2", expenditure5);
            //}
            //else if (i == 5)
            //{
            //    DataAdder dataAdder = new DataAdder();
            //    dataAdder.TransferMoneyBetweenFunds("A1", "A2", 15000.0);
            //}
            //else if (i == 6)
            //{
            //    DataEditor dataEditor = new DataEditor();
            //    Bankroll bankroll = new Bankroll(3984657.08, 3053397.19, 931259.89);
            //    dataEditor.EditBankrollData(bankroll);
            //}
            //else if (i == 7)
            //{
            //    DataProvider provider = new DataProvider();
            //    var exp = provider.GetExpenditureArrayByWeekAndFund(2, "A1");
            //    foreach (var e in exp)
            //    {
            //        Console.WriteLine(e.Name);
            //        Console.WriteLine(e.MoneySum);
            //    }
            //}
            //Fund fund1 = new Fund("A5", 1.0M, DataLayer.AuxiliaryTypes.MoneySourceType.ServiceAndGoods);
            //string fundName = "testFund";

            //DataAdder dataAdder = new DataAdder();
            //dataAdder.AddNewFund(fund1, fundName);

            //DateTime weekStart = new DateTime(2021, 5, 20);
            //DateTime weekEnd = new DateTime(2021, 5, 30);
            //Week week = new Week(weekStart, weekEnd);

            //dataAdder.SetNewWeekData(week);

            //FundsGroup fundsGroup = new FundsGroup();
            //Bankroll bankroll = new Bankroll(2783410.32M, 1832588.35M, 950821.97M);
            //DistributionPlanner planner = new DistributionPlanner();
            //planner.DistributeMoneyForFunds(bankroll, fundsGroup);

            //dataAdder.SetBankrollData(fundsGroup, bankroll);

            //foreach (var row in fundsGroup.AllFunds)
            //{
            //    foreach (var fund in row)
            //    {
            //        Console.WriteLine($"{fund.Key}\t{fund.TotalMoney}\t{fund.PredictablePercent}\t{fund.MoneySourceType}");
            //    }
            //    Console.WriteLine();
            //}

            FRS_Table fRS_Table = new FRS_Table(2);
            fRS_Table = new FRS_Table(5);

            //FundDataProvider provider = new FundDataProvider();
            //var fund = provider.FindFundByKey("A5");

            //DataEditor dataEditor = new DataEditor();
            //dataEditor.DeactivateFund(fund.Id);


            Console.WriteLine("Success");
            Console.ReadLine();
        }
    }
}
