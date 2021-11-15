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
using Supervisor;

namespace UILayer
{

    public partial class AllExpenses : Form
    {
        DataProvider _provider;
        string fundKey = "A2";
        int period = 13;

        public AllExpenses(string fundKey, int period)
        {
            this.fundKey = fundKey;
            this.period = period;
            _provider = new DataProvider();
            List<object> periods = new List<object>();
            foreach(var p in _provider.GetAllWeeksData())
            {
                periods.Add(p.Number);
            }

            InitializeComponent();

            periodPicker.Items.AddRange(periods.ToArray());
            fundPicker.SelectedItem = fundKey;
            periodPicker.SelectedItem = period;
            DrowExpensesTable();

        }

        public void DrowExpensesTable()
        {
            List<string> expensesNames = new List<string>();
            var currentExpenses = _provider.GetExpenditureArrayByWeekAndFund(Int32.Parse(periodPicker.SelectedItem.ToString()), fundPicker.SelectedItem.ToString());

            if (currentExpenses.Length == 0)
            {
                Label label = new Label();
                label.Text = "Затраты отсутствуют";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Fill;
                expensesTable.Controls.Add(label, 0, 0);
            }
            else
            {
                expensesTable.ColumnStyles.Clear();
                expensesTable.RowStyles.Clear();

                expensesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
                expensesTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));

                ExpendituresMatrix matrix = new ExpendituresMatrix(fundKey);
                var exp = matrix.GetMatrix();

                foreach (var m in currentExpenses)
                {
                    expensesNames.Add(m.Name);
                }
                for (int i = 0; i < expensesNames.Count; i++)
                {
                    expensesTable.RowCount++;
                    expensesTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                    Label expenseName = new Label();
                    expenseName.Dock = DockStyle.Fill;
                    expenseName.TextAlign = ContentAlignment.MiddleCenter;
                    expenseName.Text = expensesNames[i];
                    expensesTable.Controls.Add(expenseName, 0, i);
                }
                expensesTable.ColumnCount++;
                expensesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
                for (int j = 0; j < expensesNames.Count; j++)
                {
                    DrowExpenseLabel(currentExpenses[j].MoneySum, j, 1);
                }
            }
        }

        private void DrowExpenseLabel(double sum, int row, int column)
        {
            Label ExpenseLabel = new Label();
            ExpenseLabel.Dock = DockStyle.Fill;
            ExpenseLabel.TextAlign = ContentAlignment.MiddleCenter;
            ExpenseLabel.Text = sum.ToString();
            expensesTable.Controls.Add(ExpenseLabel, column, row);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Expenses form = new Expenses(fundPicker.SelectedItem.ToString());
            form.Show();
        }

        private void redrawForm()
        {
            if ((fundPicker.SelectedItem != null) && (periodPicker.SelectedItem != null))
            {
                string fundKey = fundPicker.SelectedItem.ToString();
                int period = Int32.Parse(periodPicker.SelectedItem.ToString());
                this.Close();
                AllExpenses allExpenses = new AllExpenses(fundKey, period);
                allExpenses.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            redrawForm();
        }
    }
}
