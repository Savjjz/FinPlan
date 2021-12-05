using BusinessLogicLayer.DbBlock;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using DataLayer.Entities;
using BusinessLogicLayer.ExcelBlock.ServiceFunctions;
using BusinessLogicLayer.ExcelBlock.TableElements;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ExcelBlock
{
    public class BankrollTraficTable : TableBase
    {
        private List<Excel.Worksheet> ConcreteFundWorksheets { get; set; } = new List<Excel.Worksheet>();

        public BankrollTraficTable(DataProvider provider)
        {
            InitializeWorkbook();
            Workbook.SaveAs("ДДС");
            Worksheet.Name = "Итого ДС";
            CreateTableAsync(provider);
        }

        ~BankrollTraficTable()
        {
            Marshal.ReleaseComObject(Application);
            Marshal.ReleaseComObject(Workbooks);
            Marshal.ReleaseComObject(Workbook);
            Marshal.ReleaseComObject(Worksheets);
            Marshal.ReleaseComObject(Worksheet);
            Marshal.ReleaseComObject(ConcreteFundWorksheets);
        }

        public async void CreateTableAsync(DataProvider provider)
        {
            await Task.Run(() => SetConcreteFundsTraficeTable(provider));
            await Task.Run(() => SetTableTextSample());
            await Task.Run(() => SetTableStyleSample());
            await Task.Run(() => SetFundConditionData(provider));
            await Task.Run(() => SetFundsData(provider));
            await Task.Run(() => SetTotalFundsRevenue(provider));
        }

        protected override void SetTableTextSample()
        {
            //Заполняем ячейки дефолтным текстом
            Excel.Range range = Worksheet.get_Range("A1", "B2");
                range.Merge(Type.Missing);
                Worksheet.Cells[1, 1] = "Неделя";

            range = Worksheet.get_Range("A3");
                range.Value = "Код фонда";

            range = Worksheet.get_Range("B3");
                range.Value = "Фонды";

            range = Worksheet.get_Range("A20", "B20");
                range.Merge(Type.Missing);
                Worksheet.Cells[20, 1] = "Итого ДС";

            range = Worksheet.get_Range("A21", "B21");
                range.Merge(Type.Missing);
                Worksheet.Cells[21, 1] = "Расход ДС";

            //Форматируем ячейки
            range = Worksheet.get_Range("A1");
                range.ColumnWidth = 15;

            range = Worksheet.get_Range("B1");
                range.ColumnWidth = 35;

            range = Worksheet.get_Range("A3");
                range.RowHeight = 30;

            Marshal.ReleaseComObject(range);
        }

        protected override void SetTableStyleSample()
        {
            string styleName = Convert.ToString(Guid.NewGuid());
            Excel.Style style = Workbook.Styles.Add(styleName);
                style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                style.Interior.Color = Color.LightGreen;
                style.WrapText = true;
                style.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            Excel.Range range = Worksheet.get_Range("A1", "B2");
                range.Merge(Type.Missing);
                range.Style = styleName;

            string styleName1 = Convert.ToString(Guid.NewGuid());
            Excel.Style style1 = Workbook.Styles.Add(styleName1);
                style1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                style1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                style1.WrapText = true;
                style1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                style1.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;

            range = Worksheet.get_Range("A3", "B18");
            range.Style = style1;
        }

        private void SetConcreteFundsTraficeTable(DataProvider provider)
        {
            var funds = provider.GetActiveFundsData();
            foreach (var fund in funds)
            {
                Excel.Worksheet worksheet = Worksheets.Add();
                ConcreteFundTraficTable table = new ConcreteFundTraficTable(Workbook, worksheet, fund.Key);
            }
        }

        /// <summary>
        /// Записать данные о состоянии фондов по неделям в таблицу
        /// </summary>
        /// <param name="provider"></param>
        private void SetFundConditionData(DataProvider provider)
        {
            //Ячейка, с которой начинается запись состояния фондов по неделям
            string cellNumber = "C1";
            //Массив всех состояний фондов из бд
            FundConditionModel[,] fundConditions = provider.GetAllFundConditionsMatrix();
            WeekModel[] weeks = provider.GetAllWeeksData();

            //Проходим по всем неделям
            for (int weekCounter = 0; weekCounter < fundConditions.GetLength(1); weekCounter++)
            {
                //Записываем в новый массив состояния фондов, соответсвующих этой неделе
                FundConditionModel[] column = Enumerable.Range(0, fundConditions.GetUpperBound(0) + 1)
                                                        .Select(i => fundConditions[i, weekCounter])
                                                        .ToArray();
                //Записываем данные в таблицу
                FundConditionInConcreteWeek tableElement = new FundConditionInConcreteWeek(cellNumber, column, weeks[weekCounter]);
                tableElement.SetDataInTable(Workbook, Worksheet);
                tableElement.SetWeekDataInTable(Workbook, Worksheet);
                tableElement.SetTransactionsBetweenFunds(Workbook, Worksheet);
                //Сдвигаемся на 3 колонки вперед
                cellNumber = cellNumber.NextColumn().NextColumn().NextColumn();
            }
        }

        /// <summary>
        /// Записать даннные о фондах в таблицу
        /// </summary>
        /// <param name="provider">Проводник БД</param>
        private void SetFundsData(DataProvider provider)
        {
            var funds = provider.GetActiveFundsData();
            string cellNumber = "A4";

            foreach (var fund in funds)
            {
                Excel.Range range = Worksheet.get_Range(cellNumber);
                range.Value = fund.Key;
                cellNumber = cellNumber.NextColumn();
                range = Worksheet.get_Range(cellNumber);
                range.Value = fund.Name;
                cellNumber = cellNumber.NextLine();
                cellNumber = cellNumber.PreviousColumn();
            }
        }

        private void SetTotalFundsRevenue(DataProvider provider)
        {
            var weeks = provider.GetAllWeeksData();
            var fundConditions = provider.GetAllFundConditions();
            string cellNumber = "C20";
            Excel.Range range;
            
            for (int counter = 0; counter < weeks.Length; counter++)
            {
                decimal moneyBeforeFinPlan = 0;
                decimal moneyAfterFinPlan = 0;
                var fundConditionsCurrentWeek = fundConditions.Where(p => p.WeekId == weeks[counter].Id).ToArray();

                foreach (var fund in fundConditionsCurrentWeek)
                {
                    moneyBeforeFinPlan += fund.MoneySumBeforeFinPlan;
                    moneyAfterFinPlan += fund.MoneySumAfterFinPlan;
                }
                range = Worksheet.get_Range(cellNumber);
                range.Value = moneyBeforeFinPlan;

                cellNumber = cellNumber.NextColumn().NextColumn();
                range = Worksheet.get_Range(cellNumber);
                range.Value = moneyAfterFinPlan;

                cellNumber = cellNumber.NextLine();
                range = Worksheet.get_Range(cellNumber);
                range.Value = Math.Round(moneyBeforeFinPlan - moneyAfterFinPlan, 2);

                cellNumber = cellNumber.PreviousLine();
                cellNumber = cellNumber.NextColumn();
            }
        }

    }
}
