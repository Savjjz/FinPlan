using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using DataLayer.Entities;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessLogicLayer.ExcelBlock.ServiceFunctions;

namespace BusinessLogicLayer.ExcelBlock.TableElements
{
    class FundConditionInConcreteWeek
    {
        private string FirstCellNumber { get; set; }
        private FundConditionModel[] FundConditions { get; set; }
        private TransactionBetweenFundsModel[] TransactionsBetweenFunds { get; set; }
        private WeekModel Week { get; set; }

        public FundConditionInConcreteWeek(string firstCellNumber, FundConditionModel[] fundConditions, WeekModel week)
        {
            FirstCellNumber = firstCellNumber;
            FundConditions = fundConditions;
            Week = week;
        }

        public void SetDataInTable(Excel.Workbook workbook,  Excel.Worksheet worksheet)
        {
            string firstCellNumber = FirstCellNumber;

            string columnsNamesStyleName = Convert.ToString(Guid.NewGuid());
                Excel.Style columnsNamesStyle = workbook.Styles.Add(columnsNamesStyleName);
                columnsNamesStyle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                columnsNamesStyle.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                columnsNamesStyle.WrapText = true;
                columnsNamesStyle.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                columnsNamesStyle.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                columnsNamesStyle.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;


            string firstColumnStyleName = Convert.ToString(Guid.NewGuid());
            Excel.Style firstColumnStyle = workbook.Styles.Add(firstColumnStyleName);
                firstColumnStyle.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                firstColumnStyle.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                firstColumnStyle.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            string lastColumnStyleName = Convert.ToString(Guid.NewGuid());
            Excel.Style lastColumnStyle = workbook.Styles.Add(lastColumnStyleName);
                lastColumnStyle.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                lastColumnStyle.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                lastColumnStyle.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                lastColumnStyle.Interior.Color = Color.LightGray;

            string cellNumber = firstCellNumber.NextLine().NextLine();
            Excel.Range range = worksheet.get_Range(cellNumber);
                range.ColumnWidth = 15;
                range.Style = columnsNamesStyleName;
                range.Value = "ДС до ФП";

            cellNumber = cellNumber.NextColumn();
            range = worksheet.get_Range(cellNumber);
                range.Style = columnsNamesStyleName;
                range.ColumnWidth = 15;
                range.Value = "Переводы между фондами";

            cellNumber = cellNumber.NextColumn();
            range = worksheet.get_Range(cellNumber);
                range.Style = columnsNamesStyleName;
                range.ColumnWidth = 15;
                range.Value = "ДС после ФП";
            cellNumber = firstCellNumber.NextLine().NextLine();

            foreach (var fund in FundConditions)
            {
                cellNumber = cellNumber.NextLine();
                range = worksheet.get_Range(cellNumber);
                range.Value = fund.MoneySumBeforeFinPlan;
                range.Style = firstColumnStyleName;

                cellNumber = cellNumber.NextColumn().NextColumn();
                range = worksheet.get_Range(cellNumber);
                range.Value = fund.MoneySumAfterFinPlan;
                range.Style = lastColumnStyleName;
                cellNumber = cellNumber.PreviousColumn().PreviousColumn();
            }
        }

        public void SetTransactionsBetweenFunds(Excel.Workbook workbook, Excel.Worksheet worksheet)
        {
            string cellNumber = FirstCellNumber;
            cellNumber = cellNumber.NextColumn().NextLine().NextLine().NextLine();
            Excel.Range range;
            
            foreach (var fund in FundConditions)
            {
                var transactions = fund.TransactionBetweenFunds.ToArray();
                double transactionsSum = 0;
                foreach (var transaction in transactions)
                {
                    transactionsSum += transaction.MoneySum;
                }
                if (transactionsSum > 0)
                {
                    range = worksheet.get_Range(cellNumber);
                    range.Value = transactionsSum;
                    range.Font.Color = Color.Green;
                }
                else if (transactionsSum < 0)
                {
                    range = worksheet.get_Range(cellNumber);
                    range.Value = transactionsSum;
                    range.Font.Color = Color.Red;
                }
                cellNumber = cellNumber.NextLine();
            }
        }

        public void SetWeekDataInTable(Excel.Workbook workbook, Excel.Worksheet worksheet)
        {
            string styleName = Convert.ToString(Guid.NewGuid());
                Excel.Style style = workbook.Styles.Add(styleName);
                style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                style.Interior.Color = Color.LightGreen;
                style.WrapText = true;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            string cellNumber = FirstCellNumber;
            //Объединяем 3 ячейки
            Excel.Range range = worksheet.get_Range(cellNumber, cellNumber.NextColumn().NextColumn());
                range.Style = styleName;
                range.Merge(Type.Missing);
                range.Value = Week.Number;
            //Переходим на следующую строку
            cellNumber = cellNumber.NextLine();
            range = worksheet.get_Range(cellNumber);
            //Записываем дату начала недели
            range.Value = Week.Start.ToLongDateString();
            //Переходим на 2 стобца вперед
            cellNumber = cellNumber.NextColumn().NextColumn();
            range = worksheet.get_Range(cellNumber);
            //Записываем дату конца недели
            range.Value = Week.End.ToLongDateString(); 
        }
    }
}
