using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using BusinessLogicLayer.DbBlock.DataProviders;
using System.Drawing;
using BusinessLogicLayer.ExcelBlock.ServiceFunctions;
using Excel = Microsoft.Office.Interop.Excel;
using DataLayer.AuxiliaryTypes;
using System.Runtime.InteropServices;

namespace BusinessLogicLayer.ExcelBlock
{
    public class FRS_Table : TableBase
    {
        private int WeekNumber { get; set; }
        private string WeekId { get; set; }

        public FRS_Table(int weekNumber)
        {
            WeekNumber = weekNumber;
            InitializeWorkbook();
            SetStyles();
            SetTableTextSample();
            SetDistributionData();
            SetBankrollData();
        }

        protected override void SetTableStyleSample()
        {
            throw new NotImplementedException();
        }

        protected override void SetTableTextSample()
        {
            //Заполняем таблицу текстом
            Excel.Range range = Worksheet.get_Range("B1", "G1").Cells;
            range.Merge(Type.Missing);
            Worksheet.Cells[1, 2] = "Форма распределения средств";

            range = Worksheet.get_Range("B2");
            range.Value = "Поступило ДС за отчетную неделю";
            range = Worksheet.get_Range("C2");
            range.Value = "руб.";

            range = Worksheet.get_Range("F2", "F5").Cells;
            range.Merge(Type.Missing);
            Worksheet.Cells[2, 6] = "Итого распределено в фонд за неделю";
            range = Worksheet.get_Range("G2", "G5").Cells;
            range.Merge(Type.Missing);
            Worksheet.Cells[2, 7] = "Прогноз распределения в фонды за месяц";

            range = Worksheet.get_Range("A3");
            range.Value = "Код фонда";
            range = Worksheet.get_Range("B3");
            range.Value = "Фонды";
            range = Worksheet.get_Range("D3");
            range.Value = "Выручка от Услуги";
            range = Worksheet.get_Range("E3");
            range.Value = "Выручка от продажи товаров";

            range = Worksheet.get_Range("C4");
            range.Value = "%";

            //Форматируем размеры ячеек
            range = Worksheet.get_Range("B2");
            range.ColumnWidth = 40;
            range.RowHeight = 30;

            range = Worksheet.get_Range("D3");
            range.ColumnWidth = 20;
            range.RowHeight = 30;

            range = Worksheet.get_Range("E1");
            range.ColumnWidth = 20;

            range = Worksheet.get_Range("F1");
            range.ColumnWidth = 20;

            range = Worksheet.get_Range("G1");
            range.ColumnWidth = 20;


            Marshal.ReleaseComObject(range);
        }

        private void SetDistributionData()
        {
            WeekDataProvider weekProvider = new WeekDataProvider();
            FundConditionDataProvider fundProvider = new FundConditionDataProvider();
            WeekId = weekProvider.FindWeekByNumber(WeekNumber).Id;
            var funds = fundProvider.GetFundConditionsByWeek(WeekId);

            string firstCell = "A7";
            string lastCell = "G7";

            foreach (var fund in funds)
            {
                FundLine(firstCell, fund);
                firstCell = firstCell.NextLine();
            }
        }

        private void SetBankrollData()
        {
            WeekDataProvider weekProvider = new WeekDataProvider();
            var bankroll = weekProvider.FindWeekById(WeekId).Bankroll;
            Excel.Range range = Worksheet.get_Range("D2");
            range.Value = bankroll.TotalSum;
            range = Worksheet.get_Range("D5");
            range.Value = bankroll.ServiceRevenue;
            range = Worksheet.get_Range("D4");
            range.Value = Math.Round(bankroll.ServiceRevenue / bankroll.TotalSum * 100, 2);
            range = Worksheet.get_Range("E5");
            range.Value = bankroll.GoodsRevenue;
            range = Worksheet.get_Range("E4");
            range.Value = Math.Round(bankroll.GoodsRevenue / bankroll.TotalSum * 100, 2);
        }

        private void FundLine(string cellNumber, FundConditionModel fund)
        {
            //Ссылаемся на первую ячейку
            Excel.Range cell = Worksheet.get_Range(cellNumber);
            cell.Value = fund.Fund.Key;

            cellNumber = cellNumber.NextColumn();
            cell = Worksheet.get_Range(cellNumber);
            cell.Value = fund.Fund.Name;

            cellNumber = cellNumber.NextColumn();
            cell = Worksheet.get_Range(cellNumber);
            cell.Value = fund.PercentFromBankroll;

            RevenueDataProvider revenueProvider = new RevenueDataProvider();

            switch (fund.Fund.MoneySourceType)
            {
                case MoneySourceType.Goods:
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = "-";
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).SumFromGoods;
                    break;
                case MoneySourceType.Service:
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).SumFromService;
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = "-";
                    break;
                case MoneySourceType.ServiceAndGoods:
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).SumFromService;
                    cellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber);
                    cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).SumFromGoods;
                    break;
                case MoneySourceType.Total:
                    cellNumber = cellNumber.NextColumn();
                    string nextCellNumber = cellNumber.NextColumn();
                    cell = Worksheet.get_Range(cellNumber, nextCellNumber).Cells;
                    cell.Merge(Type.Missing);
                    cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).TotalSum;
                    cellNumber = cellNumber.NextColumn();
                    break;
            }

            cellNumber = cellNumber.NextColumn();
            cell = Worksheet.get_Range(cellNumber);
            cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).TotalSum;

            cellNumber = cellNumber.NextColumn();
            cell = Worksheet.get_Range(cellNumber);
            cell.Value = revenueProvider.FindRevenueToFundByWeek(WeekId, fund.FundId).TotalSum * 4;
        }


        private enum StylesNames
        {
            GreenBackCentralAligment,
            GreenBackLeftAligment,
            YellowBackCentralAligment,
            GreyBackCentralAligment,
            GreyBackLeftAligment,
            GreyBackRightAligment,
            WhightBackCentralAligment,
            WhiteBackLeftAligment,
            WhiteBackRightAligment
        }

        private void SetStyles()
        {
            string styleName = Convert.ToString(StylesNames.GreenBackCentralAligment);
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                style.Interior.Color = Color.LightGreen;
                style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                style.WrapText = true;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            styleName = Convert.ToString(StylesNames.GreenBackLeftAligment);
            style = Workbook.Styles.Add(styleName);
                style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                style.Interior.Color = Color.LightGreen;
                style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                style.WrapText = true;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            styleName = Convert.ToString(StylesNames.YellowBackCentralAligment);
            style = Workbook.Styles.Add(styleName);
            style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            style.Interior.Color = Color.Yellow;
            style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            style.WrapText = true;
            style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
        }
    }
}
