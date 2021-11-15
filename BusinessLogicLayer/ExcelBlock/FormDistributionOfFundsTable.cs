    using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DbBlock;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing;
using BusinessLogicLayer.ExcelBlock.ServiceFunctions;
using DataLayer.Entities;
using System.Linq;

namespace BusinessLogicLayer.ExcelBlock
{
    public class FormDistributionOfFundsTable : TableBase
    {
        DataProvider Provider { get; set; }
        WeekModel CurrentWeek { get; set; }

        /// <summary>
        /// Конструктор для произвольной недели
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="weekNumber"></param>
        public FormDistributionOfFundsTable(DataProvider provider, int weekNumber)
        {
            Provider = provider;
            CurrentWeek = provider.FindWeekByNumber(weekNumber);
            InitializeWorkbook();
            SetTableTextSample();
            SetTableStyleSample();
            SetBankrollDataToTable();
            SetFundsDataToTable();
            CountTotalRevenue(provider);
        }

        /// <summary>
        /// Конструктор для посленей недели
        /// </summary>
        /// <param name="provider"></param>
        public FormDistributionOfFundsTable(DataProvider provider) 
        {
            Provider = provider;
            CurrentWeek = provider.FindLastWeekInDb();
            InitializeWorkbook();
            SetTableTextSample();
            SetTableStyleSample();
            SetBankrollDataToTable();
            SetFundsDataToTable();
            CountTotalRevenue(provider);
        }

        ~FormDistributionOfFundsTable()
        {
            Marshal.ReleaseComObject(Application);
            Marshal.ReleaseComObject(Workbook);
            Marshal.ReleaseComObject(Workbooks);
            Marshal.ReleaseComObject(Worksheets);
            Marshal.ReleaseComObject(Worksheet);
            Application.Quit();
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
            Worksheet.Cells[2,6] = "Итого распределено в фонд за неделю";
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

            range = Worksheet.get_Range("B6");
            range.Value = "Фонды с выручки";

            range = Worksheet.get_Range("A12", "B12").Cells;
            range.Merge(Type.Missing);
            Worksheet.Cells[12, 1] = "МАРЖА";

            range = Worksheet.get_Range("B13");
            range.Value = "Фонды маржинального дохода";

            range = Worksheet.get_Range("A22", "B22").Cells;
            range.Merge(Type.Missing);
            Worksheet.Cells[22, 1] = "СКД = 1.92% от Маржи";

            range = Worksheet.get_Range("B23");
            range.Value = "Фонды скорректированного дохода";

            range = Worksheet.get_Range("E30");
            range.Value = "Итого распределено: ";

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

        //Никогда не раскрывай эту вкладку. Тут таится древнее зло
        protected override void SetTableStyleSample()
        {
            string styleName = "Design";

            Excel.Style style = Workbook.Styles.Add(styleName);
            style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            style.Interior.Color = Color.LightGreen;
            style.WrapText = true;
            style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            Excel.Range range = Worksheet.get_Range("B1", "G1").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("A1", "A5").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("B2", "B5").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("C2", "C5").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("D3", "D5").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("E3", "E5").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("F2", "F5").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("G2", "G5").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("A12", "B12").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("A22", "B22").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("D12", "E12").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("D22", "E22").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName;

            range = Worksheet.get_Range("C12");
            range.Style = styleName;

            range = Worksheet.get_Range("C22");
            range.Style = styleName;

            range = Worksheet.get_Range("F12", "G12").Cells;
            range.Style = styleName;

            range = Worksheet.get_Range("F22", "G22").Cells;
            range.Style = styleName;

            //Блять как же я ненавижу этот фреймворк сука
            string styleName1 = "Design1";

            Excel.Style style1 = Workbook.Styles.Add(styleName1);
            style1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            style1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            style1.Interior.Color = Color.LightGray;
            style1.WrapText = true;
            style1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            style1.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            style1.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            range = Worksheet.get_Range("A7", "G7").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A9", "G9").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A14", "G14").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A16", "G16").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A18", "G18").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A20", "G20").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A24", "G24").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A26", "G26").Cells;
            range.Style = styleName1;

            range = Worksheet.get_Range("A28", "G28").Cells;
            range.Style = styleName1;

            //Блять какая же хуйня
            string styleName2 = "Design2";

            Excel.Style style2 = Workbook.Styles.Add(styleName2);
            style2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            style2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            style2.WrapText = true;
            style2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            style2.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            style2.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            range = Worksheet.get_Range("A6", "G6");
            range.Style = styleName2;

            range = Worksheet.get_Range("A8", "G8");
            range.Style = styleName2;

            range = Worksheet.get_Range("A10", "G10");
            range.Style = styleName2;

            range = Worksheet.get_Range("A11", "G11");
            range.Style = styleName2;

            range = Worksheet.get_Range("A13", "G13");
            range.Style = styleName2;

            range = Worksheet.get_Range("A15", "G15");
            range.Style = styleName2;

            range = Worksheet.get_Range("A17", "G17");
            range.Style = styleName2;

            range = Worksheet.get_Range("A19", "G19");
            range.Style = styleName2;

            range = Worksheet.get_Range("A21", "G21");
            range.Style = styleName2;

            range = Worksheet.get_Range("A23", "G23");
            range.Style = styleName2;

            range = Worksheet.get_Range("A25", "G25");
            range.Style = styleName2;

            range = Worksheet.get_Range("A27", "G27");
            range.Style = styleName2;

            range = Worksheet.get_Range("A29", "G29");
            range.Style = styleName2;

            range = Worksheet.get_Range("E30");
            range.Style = styleName2;

            string styleName3 = "Design3";

            Excel.Style style3 = Workbook.Styles.Add(styleName3);
            style3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            style3.Interior.Color = Color.Yellow;
            style3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            style3.WrapText = true;
            style3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            style3.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            style3.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            range = Worksheet.get_Range("D2", "E2").Cells;
            range.Merge(Type.Missing);
            range.Style = styleName3;

            range = Worksheet.get_Range("F30");
            range.Style = styleName3;

            range = Worksheet.get_Range("G30");
            range.Style = styleName3;

            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(style);
            Marshal.ReleaseComObject(style1);
            Marshal.ReleaseComObject(style2);
            Marshal.ReleaseComObject(style3);
        }

        private void SetBankrollDataToTable()
        {
            var bankroll = CurrentWeek.Bankroll;
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

        private void SetFundsDataToTable()
        {
            void LineFillingGroupA(int lineNumber, FundModel fund, RevenueModel[] revenues)
            {
                Excel.Range range;
                string currentCell = "A" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.Key;

                currentCell = "B" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.Name;

                currentCell = "C" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = Provider.FindFundConditionByWeek(CurrentWeek.Number, fund.Key).PercentFromBankroll;
                //range.Value = fund.PercentFromBanckroll;

                currentCell = "G" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.MonthForecast;

                RevenueModel revenue = revenues.FirstOrDefault(a => a.FundId == fund.Id);

                currentCell = "D" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                if (revenue.SumFromService != 0)
                    range.Value = revenue.SumFromService;
                else
                    range.Value = "-";

                currentCell = "E" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                if (revenue.SumFromGoods != 0)
                    range.Value = revenue.SumFromGoods;
                else
                    range.Value = "-";

                currentCell = "F" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = revenue.TotalSum;
            }

            void LineFillingGroupsBC(int lineNumber, FundModel fund, RevenueModel[] revenues)
            {
                Excel.Range range;
                string currentCell = "A" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.Key;

                currentCell = "B" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.Name;

                currentCell = "C" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = Provider.FindFundConditionByWeek(CurrentWeek.Number, fund.Key).PercentFromBankroll;
                //range.Value = fund.PercentFromBanckroll;

                currentCell = "G" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = fund.MonthForecast;

                RevenueModel revenue = revenues.FirstOrDefault(a => a.FundId == fund.Id);

                range = Worksheet.get_Range("D" + Convert.ToString(lineNumber), "E" + Convert.ToString(lineNumber)).Cells;
                range.Merge(Type.Missing);
                Worksheet.Cells[lineNumber, 4] = revenue.TotalSum;

                currentCell = "F" + Convert.ToString(lineNumber);
                range = Worksheet.get_Range(currentCell);
                range.Value = revenue.TotalSum;
            }

            const int fundsGroupANumber = 4;
            const int fundsGroupBNumber = 12;
            const int fundsGroupCNumber = 15;

            var funds = Provider.GetFundsData();
            var revenues = Provider.GetRevenuesDataByWeek(CurrentWeek.Number);

            int startLine = 7;

            for (int counter = 0; counter < fundsGroupANumber; counter++)
            {
                int currentLine  = startLine + counter;
                LineFillingGroupA(currentLine, funds[counter], revenues);
            }

            startLine = 14;
            for (int counter = fundsGroupANumber; counter < fundsGroupBNumber; counter++)
            {
                int currentLine = startLine + counter - fundsGroupANumber;
                LineFillingGroupsBC(currentLine, funds[counter], revenues);
            }

            startLine = 24;
            for (int counter = fundsGroupBNumber; counter < fundsGroupCNumber; counter++)
            {
                int currentLine = startLine + counter - fundsGroupBNumber;
                LineFillingGroupsBC(currentLine, funds[counter], revenues);
            }
        }

        private void CountTotalRevenue(DataProvider provider)
        {
            var revenues = provider.GetRevenuesDataByWeek(CurrentWeek.Number);
            var funds = provider.GetFundsData();

            double totalRevenue = 0.0;
            foreach(var r in revenues)
            {
                totalRevenue += r.TotalSum;
            }

            double totalForecast = 0.0;
            foreach(var f in funds)
            {
                totalForecast += f.MonthForecast;
            }

            Excel.Range range = Worksheet.get_Range("F30");
            range.Value = Math.Round(totalRevenue, 2);

            range = Worksheet.get_Range("G30");
            range.Value = Math.Round(totalForecast, 2);
        }
    }
}
