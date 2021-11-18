using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;
using DataLayer.Entities;
using BusinessLogicLayer.BankrollDistribution;
using BusinessLogicLayer.ExcelBlock.TableElements;

namespace Supervisor
{
    public partial class FundForm : Form
    {
        string fundKey;
        int firstPeriodNum;
        int lastPeriodNum;
        string FundDescriptionText;
        int expenses;
        DataProvider _provider;

        public FundForm(string fundKey)
        {
            _provider = new DataProvider();
            this.fundKey = fundKey;
            this.firstPeriodNum = _provider.FindFirstWeekInDb().Number;
            this.lastPeriodNum = _provider.FindLastWeekInDb().Number;
            this.expenses = _provider.GetUniqueExpendituresNumberByFundKey(fundKey);
            this.FundDescriptionText = _provider.FindFundByKey(fundKey).Name;

            InitializeComponent();
            this.Text = "Фонд";
            FundName.Text = "Фонд " + this.fundKey;
            FundDescription.Text = FundDescriptionText;
            DrowFundTable(this.expenses);
        }

        public void DrowFundTable(int expensesCount)
        {
            fundTable.ColumnStyles.Clear();
            fundTable.RowStyles.Clear();

            fundTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            fundTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));

            ExpendituresMatrix matrix = new ExpendituresMatrix(fundKey);
            var exp = matrix.GetMatrix();
            List<string> lineNames = new List<string>() { "Отчетный период", "Баланс на начало периода", "Приход", "Баланс до затрат", "Затраты:" };
            foreach (var m in matrix.GetUniqueExpendituresNames())
            {
                lineNames.Add(m);
            }
            lineNames.Add("Баланс на конец периода");


            for (int i = 0; i < expensesCount + 6; i++)
            {
                fundTable.RowCount++;
                fundTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                Label lineName = new Label();
                lineName.Dock = DockStyle.Fill;
                lineName.TextAlign = ContentAlignment.MiddleCenter;
                lineName.Text = lineNames[i];
                fundTable.Controls.Add(lineName, 0, i);
            }

            for (int counter = 1; counter <= lastPeriodNum - firstPeriodNum + 1; counter++) 
            {
                int periodNumber = firstPeriodNum + counter - 1;
                fundTable.ColumnCount++;
                fundTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));

                FundPeriod Period = new FundPeriod();
                var weeks = _provider.GetAllWeeksData();

                if ((counter == lastPeriodNum - firstPeriodNum + 1) && (_provider.FindLastWeekInDb().Bankroll == null))
                {
                    if (counter == 1)
                    {
                        Period.moneyStart = 0;
                        Period.moneyBeforeExpenses = 0;
                        Period.moneyEnd = 0;
                    }
                    else
                    {
                        Period.moneyStart = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 2].Number, fundKey).MoneySumAfterFinPlan, 2);
                        Period.moneyBeforeExpenses = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 2].Number, fundKey).MoneySumBeforeFinPlan, 2);
                        Period.moneyEnd = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 2].Number, fundKey).MoneySumAfterFinPlan, 2);
                        Period.expences = _provider.GetExpedituresByFundKey(fundKey);
                    }
                    Period.income = 0;
                }
                else
                {
                    if (counter == 1)
                    {
                        Period.moneyStart = 0;
                    }
                    else
                    {
                        Period.moneyStart = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 2].Number, fundKey).MoneySumAfterFinPlan, 2);
                    }
                    Period.income = Math.Round(_provider.FindRevenueToFundByWeek(weeks[counter - 1].Number, fundKey).TotalSum, 2);
                    Period.moneyBeforeExpenses = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 1].Number, fundKey).MoneySumBeforeFinPlan, 2);
                    Period.expences = _provider.GetExpedituresByFundKey(fundKey);
                    Period.moneyEnd = Math.Round(_provider.FindFundConditionByWeek(weeks[counter - 1].Number, fundKey).MoneySumAfterFinPlan, 2);
                }

                

                DrowPeriodLabel(periodNumber, (periodNumber).ToString(), counter, 0);
                DrowPeriodLabel(periodNumber, Period.moneyStart.ToString(), counter, 1);
                DrowPeriodLabel(periodNumber, Period.income.ToString(), counter, 2);
                DrowPeriodLabel(periodNumber, Period.moneyBeforeExpenses.ToString(), counter, 3);
                DrowPeriodLabel(periodNumber, string.Empty, counter, 4);
                for (int j = 0; j < expensesCount; j++) 
                {
                    if (exp[j, counter - 1] == 0)
                        DrowPeriodLabel(periodNumber, "", counter, 5 + j);
                    else
                        DrowPeriodLabel(periodNumber, Convert.ToString(Math.Round(exp[j, counter - 1], 2)), counter, 5 + j);
                }
                DrowPeriodLabel(periodNumber, Period.moneyEnd.ToString(), counter, 5 + expensesCount);
            }
        }    

        private void DrowPeriodLabel(int periodNum, string text, int column, int row)
        {
            PeriodLabel label = new PeriodLabel(periodNum);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = text;
            label.Cursor = Cursors.Hand;
            label.Click += new EventHandler(Period_Click);
            fundTable.Controls.Add(label, column, row);
        }
        public void Period_Click(object sender, EventArgs e)
        {
            int PeriodNum = ((PeriodLabel)sender).PeriodNum;
            Period form = new Period(PeriodNum);
            form.Show();
        }

        private void ExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ConcreteFundTraficTable table = new ConcreteFundTraficTable(fundKey);
            }
            catch
            {
                MessageBox.Show("Ошибка формирования таблицы Excel");
            }
        }
    }
    public class FundPeriod
    {
        public decimal moneyStart;
        public decimal income;
        public decimal moneyBeforeExpenses;
        public List<ExpenditureModel> expences;
        public decimal moneyEnd;
    }
}
