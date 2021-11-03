using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessLogicLayer.DbBlock;
using DataLayer.Entities;
using System.Drawing;
using BusinessLogicLayer.ExcelBlock.ServiceFunctions;
using System.Linq;

namespace BusinessLogicLayer.ExcelBlock.TableElements
{
    public class ConcreteFundTraficTable : TableBase
    {
        private WeekMatchColumn WeekMatchColumn { get; set; } = new WeekMatchColumn();
        private ExpenditureMatchRow ExpenditureMatchRow { get; set; } = new ExpenditureMatchRow();
        private TransactionMatchRow TransactionMatchRow { get; set; } = new TransactionMatchRow();
        private FundModel Fund { get; set; }
        private int _lastRow = 0;


        /// <summary>
        /// Конструктор, на случай, если таблица создается как страница в существующей книге
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="worksheet"></param>
        /// <param name="fundKey"></param>
        public ConcreteFundTraficTable(Excel.Workbook workbook, Excel.Worksheet worksheet, string fundKey)
        {
            Workbook = workbook;
            Worksheet = worksheet;
            string worksheetName = "Фонд" + fundKey;
            Worksheet.Name = worksheetName;
            DataProvider provider = new DataProvider();
            Fund = provider.FindFundByKey(fundKey);
            SetTableTextSample();
            SetWeekData(provider);
            SetExpendituresNames(provider);
            SetExpendituresPayments(provider);
            SetTransactionsNames(provider);
            SetTransactionsPayments(provider);
            SetMoneySettlement(provider);
            SetTableStyleSample();
        }

        /// <summary>
        /// Конструктор на случай создания новой книги
        /// </summary>
        /// <param name="fundKey"></param>
        public ConcreteFundTraficTable(string fundKey)
        {
            DataProvider provider = new DataProvider();
            Fund = provider.FindFundByKey(fundKey);
            InitializeWorkbook();
            SetTableTextSample();
            SetWeekData(provider);
            SetExpendituresNames(provider);
            SetExpendituresPayments(provider);
            SetTransactionsNames(provider);
            SetTransactionsPayments(provider);
            SetMoneySettlement(provider);
            SetTableStyleSample();
        }

        protected override void SetTableTextSample()
        {
            Excel.Range range = Worksheet.get_Range("A1");
            range.Value = "Фонд " + Fund.Key;

            range = Worksheet.get_Range("B1", "D1");
            range.Merge(Type.Missing);
            range.Value = "Фонд поставщиков ТМЦ";

            range = Worksheet.get_Range("A2", "C2");
            range.Merge(Type.Missing);
            range.Cells[1, 1] = "Неделя";

            range.Worksheet.get_Range("A3", "C3");
            range.Merge(Type.Missing);
            range.Cells[2, 1] = "ДС на начало недели";

            range.Worksheet.get_Range("A4", "C4");
            range.Merge(Type.Missing);
            range.Cells[3, 1] = "Приход";

            range.Worksheet.get_Range("A5", "C5");
            range.Merge(Type.Missing);
            range.Cells[4, 1] = "Итого ДС в фонде";

            range.Worksheet.get_Range("A6", "C6");
            range.Merge(Type.Missing);
            range.Cells[5, 1] = "Расход ДС:";
        }

        protected override void SetTableStyleSample()
        {
            string styleName = Convert.ToString(Guid.NewGuid());
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.Interior.Color = Color.LightGreen;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            string styleName1 = Convert.ToString(Guid.NewGuid());
            Excel.Style style1 = Workbook.Styles.Add(styleName1);
                style1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            string styleName2 = Convert.ToString(Guid.NewGuid());
            Excel.Style style2 = Workbook.Styles.Add(styleName2);
                style2.Interior.Color = Color.LightGreen;

            Excel.Range range = Worksheet.get_Range("A1");
            range.Style = styleName;
            range = Worksheet.get_Range("B1", "D1");
            range.Merge(Type.Missing);
            range.Style = styleName;
            range = Worksheet.get_Range("A2", "C2");
            range.Merge(Type.Missing);
            range.Style = styleName;
            range = Worksheet.get_Range("A3", "C3");
            range.Merge(Type.Missing);
            range.Style = styleName1;
            range = Worksheet.get_Range("A4", "C4");
            range.Merge(Type.Missing);
            range.Style = styleName;
            range = Worksheet.get_Range("A5", "C5");
            range.Merge(Type.Missing);
            range.Style = styleName1;
            range = Worksheet.get_Range("A6", "C6");
            range.Merge(Type.Missing);
            range.Style = styleName;
        }

        private void SetWeekData(DataProvider provider)
        {
            string styleName = Convert.ToString(Guid.NewGuid());
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.Interior.Color = Color.LightGreen;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            string cellNumber = "D2";
            Excel.Range range = Worksheet.get_Range(cellNumber);
            range.Style = styleName;

            var weeks = provider.GetAllWeeksData();
            foreach (var week in weeks)
            {
                WeekMatchColumn.Add(week.Id, cellNumber.GetColumnNumber());
                range.Value = week.Number;
                range.ColumnWidth = 12;
                cellNumber = cellNumber.NextColumn();
                range = Worksheet.get_Range(cellNumber);
                range.Style = styleName;
            }
            
            
        }

        private void SetExpendituresNames(DataProvider provider)
        {
            int currentRow = 7;
            string styleName = Convert.ToString(Guid.NewGuid());
                Excel.Style style = Workbook.Styles.Add(styleName);
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            string firsCellNumber = "A" + Convert.ToString(currentRow);
            string lastCellNumber = "C" + Convert.ToString(currentRow);
            Excel.Range range = Worksheet.get_Range(firsCellNumber, lastCellNumber);
            range.Merge(Type.Missing);
            range.Style = styleName;

            var expenditures = provider.GetExpedituresByFundKey(Fund.Key);
            List<string> addedRevenuesNames = new List<string>();
            foreach (var expenditure in expenditures)
            {
                if (!addedRevenuesNames.Contains(expenditure.Name))
                {
                    ExpenditureMatchRow.Add(expenditure.Id, Convert.ToString(currentRow));
                    addedRevenuesNames.Add(expenditure.Name);
                    currentRow++;
                    range.Value = expenditure.Name;
                    firsCellNumber = firsCellNumber.NextLine();
                    lastCellNumber = lastCellNumber.NextLine();
                    range = Worksheet.get_Range(firsCellNumber, lastCellNumber);
                    range.Merge(Type.Missing);
                    range.Style = styleName;
                }
            }
            _lastRow = currentRow;
        }

        private void SetExpendituresPayments(DataProvider provider)
        {
            var weeks = provider.GetAllWeeksData();
            var expenditures = provider.GetAllExpendutiresData();
            for (int weekCounter = 0; weekCounter < WeekMatchColumn.ColumnNumbers.Count; weekCounter++)
            {
                for (int expCounter = 0; expCounter < ExpenditureMatchRow.RowNumbers.Count; expCounter++)
                {
                    var currentWeek = weeks.FirstOrDefault(p => p.Id == WeekMatchColumn.WeekId[weekCounter]);
                    var currentExpenditure = expenditures.FirstOrDefault(p => p.Id == ExpenditureMatchRow.ExpenditureId[expCounter]);
                    if (currentWeek.Id == currentExpenditure.WeekId)
                    {
                        string cellNumber = WeekMatchColumn.ColumnNumbers[weekCounter] + ExpenditureMatchRow.RowNumbers[expCounter];
                        Excel.Range range = Worksheet.get_Range(cellNumber);
                        range.Value = currentExpenditure.MoneySum;
                    }
                }
            }

        }

        private void SetMoneySettlement(DataProvider provider)
        {
            string styleName = Convert.ToString(Guid.NewGuid());
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            string styleName1 = Convert.ToString(Guid.NewGuid());
            Excel.Style style1 = Workbook.Styles.Add(styleName1);
                style1.Interior.Color = Color.LightGreen;
                style1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            int moneyBalanseRow = _lastRow + 2;
            string firstCellNumber = "A" + Convert.ToString(moneyBalanseRow);
            string lastCellNumber = "C" + Convert.ToString(moneyBalanseRow);
            Excel.Range moneyBalanse = Worksheet.get_Range(firstCellNumber, lastCellNumber);
            moneyBalanse.Merge(Type.Missing);
            moneyBalanse.Value = "Остаток ДС";

            var weeks = provider.GetAllWeeksData();
            const int firstRow = 3;
            string cellNumber = "D3";
            Excel.Range range;

            for (int counter = 0; counter < weeks.Length; counter++)
            {
                //ДС на начало недели
                range = Worksheet.get_Range(cellNumber);
                range.Style = styleName;
                if (counter == 0)
                {
                    //Для первой недели ДС отсутствуют 
                    range.Value = 0;
                }
                else
                {
                    range.Value = provider.FindFundConditionByWeek(weeks[counter-1].Number, Fund.Key).MoneySumAfterFinPlan;
                }
                //Приход
                cellNumber = cellNumber.NextLine();
                range = Worksheet.get_Range(cellNumber);
                range.Style = styleName1;
                if (counter == 0)
                {
                    range.Value = provider.FindFundConditionByWeek(weeks[counter].Number, Fund.Key).MoneySumBeforeFinPlan;
                }
                else
                {
                    range.Value = provider
                                    .FindFundConditionByWeek(weeks[counter].Number, Fund.Key).MoneySumBeforeFinPlan - 
                                    provider.FindFundConditionByWeek(weeks[counter - 1].Number, Fund.Key).MoneySumAfterFinPlan;
                }
                //Итого ДС в фонде
                cellNumber = cellNumber.NextLine();
                range = Worksheet.get_Range(cellNumber);
                range.Style = styleName;
                range.Value = provider.FindFundConditionByWeek(weeks[counter].Number, Fund.Key).MoneySumBeforeFinPlan;
                //Остаток ДС
                cellNumber = cellNumber.GetColumnNumber() + Convert.ToString(moneyBalanseRow);
                range = Worksheet.get_Range(cellNumber);
                range.Style = styleName;
                range.Value = provider.FindFundConditionByWeek(weeks[counter].Number, Fund.Key).MoneySumAfterFinPlan;
                //Возвращаемся на исходную строку
                cellNumber = cellNumber.GetColumnNumber() + Convert.ToString(firstRow);
                cellNumber = cellNumber.NextColumn();
            }

        }

        private void SetTransactionsNames(DataProvider provider)
        {
            string mainStyleName = Convert.ToString(Guid.NewGuid());
            Excel.Style mainStyle = Workbook.Styles.Add(mainStyleName);
            mainStyle.Interior.Color = Color.LightGreen;

            string styleName = Convert.ToString(Guid.NewGuid());
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            _lastRow++;
            string firstCell = "A" + Convert.ToString(_lastRow);
            string lastCell = "C" + Convert.ToString(_lastRow);
            Excel.Range mainRange = Worksheet.get_Range(firstCell, lastCell);
                mainRange.Style = mainStyleName;
                mainRange.Merge(Type.Missing);
                mainRange.Value = "Переводы между фондами:";

            var transactions = provider.GetTransactionsBetweenFundsByFundKey(Fund.Key);
            List<string> addedTransactionsNames = new List<string>();
            Excel.Range range;

            foreach (var transaction in transactions)
            {
                if (!addedTransactionsNames.Contains(transaction.Name))
                {
                    _lastRow++;
                    TransactionMatchRow.Add(transaction.Id, Convert.ToString(_lastRow));
                    firstCell = "A" + Convert.ToString(_lastRow);
                    lastCell = "C" + Convert.ToString(_lastRow);
                    range = Worksheet.get_Range(firstCell, lastCell);
                    range.Merge(Type.Missing);
                    range.Value = transaction.Name;
                    range.Style = styleName;
                }
            }
        }

        private void SetTransactionsPayments(DataProvider provider)
        {
            var weeks = provider.GetAllWeeksData();
            var transactions = provider.GetAllTransactionsBetweenFunds();
            for (int weekCounter = 0; weekCounter < WeekMatchColumn.ColumnNumbers.Count; weekCounter++)
            {
                for (int transactionCounter = 0; transactionCounter < TransactionMatchRow.RowNumbers.Count; transactionCounter++)
                {
                    var currentWeek = weeks.FirstOrDefault(p => p.Id == WeekMatchColumn.WeekId[weekCounter]);
                    var currentTransaction = transactions.FirstOrDefault(p => p.Id == TransactionMatchRow.TransactionId[transactionCounter]);
                    if (currentWeek.Id == currentTransaction.WeekId)
                    {
                        string cellNumber = WeekMatchColumn.ColumnNumbers[weekCounter] + TransactionMatchRow.RowNumbers[transactionCounter];
                        Excel.Range range = Worksheet.get_Range(cellNumber);
                        range.Value = currentTransaction.MoneySum;
                    }
                }
            }
        }
    }
}
