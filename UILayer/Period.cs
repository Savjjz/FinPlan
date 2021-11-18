using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.ExcelBlock;
using UILayer;

namespace Supervisor
{
    public partial class Period : Form
    {
        int PeriodNumber;
        DataProvider provider;
        bool isLastWeek;
        public Period(int periodNumber)
        {
            this.PeriodNumber = periodNumber;
            provider = new DataProvider();
            var currentWeek = provider.FindWeekByNumber(periodNumber);
            //из бд
            int periodNum = periodNumber;
            DateTime startDate = currentWeek.Start;
            DateTime endDate = currentWeek.End;
            int periodLength = endDate.Subtract(startDate).Days + 1;

            var allFunds = provider.GetFundsData();
            decimal[] balance1 = new decimal[allFunds.Length];
            decimal[] balance2 = new decimal[allFunds.Length];
            decimal[] income = new decimal[allFunds.Length];
            decimal[] moneyTransfer = new decimal[allFunds.Length];
            decimal[] expenses = new decimal[allFunds.Length];

            decimal startBalanceSum = 0;
            decimal incomeSum = 0;
            decimal expensesSum = 0;
            decimal endBalanceSum = 0;

            if (currentWeek.Bankroll == null)
            {
                for (int counter = 0; counter < allFunds.Length; counter++)
                {
                    balance1[counter] = 0;
                    balance2[counter] = 0;
                    income[counter] = 0;
                    moneyTransfer[counter] = 0;
                    expenses[counter] = 0;
                }
            }
            else
            {   
                for (int counter = 0; counter < allFunds.Length; counter++)
                {
                    balance1[counter] = Math.Round(provider.FindFundConditionByWeek(currentWeek.Number, allFunds[counter].Key).MoneySumBeforeFinPlan, 2);
                    startBalanceSum += provider.FindFundConditionByWeek(currentWeek.Number, allFunds[counter].Key).MoneySumBeforeFinPlan;
                    balance2[counter] = Math.Round(provider.FindFundConditionByWeek(currentWeek.Number, allFunds[counter].Key).MoneySumAfterFinPlan, 2);
                    endBalanceSum += provider.FindFundConditionByWeek(currentWeek.Number, allFunds[counter].Key).MoneySumAfterFinPlan;
                    income[counter] = Math.Round(provider.FindRevenueToFundByWeek(currentWeek.Number, allFunds[counter].Key).TotalSum, 2);
                    incomeSum += provider.FindRevenueToFundByWeek(currentWeek.Number, allFunds[counter].Key).TotalSum;
                    moneyTransfer[counter] = Math.Round(provider.GetTransactionsSumInFunByWeek(currentWeek.Number, allFunds[counter].Key), 2);
                    expenses[counter] = Math.Round(provider.GetExpendituresSumInFundByWeek(currentWeek.Number, allFunds[counter].Key), 2);
                    expensesSum += provider.GetExpendituresSumInFundByWeek(currentWeek.Number, allFunds[counter].Key);
                }
            }

            InitializeComponent();

            startBalanceTotal.Text = Math.Round(startBalanceSum, 2).ToString() + " ₽";
            incomeTotal.Text = Math.Round(incomeSum, 2).ToString() + " ₽"; 
            expensesTotal.Text = Math.Round(expensesSum, 2).ToString() + " ₽";
            endBalanceTotal.Text = Math.Round(endBalanceSum, 2).ToString() + " ₽";

            if (periodNum == provider.FindLastWeekInDb().Number)
            {
                isLastWeek = true;
            }
            else
            {
                isLastWeek = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }

            label1.Text = "Отчетный период №" + periodNum.ToString();
            Label[] startBalanceLabels = new Label[] { startBalance1, startBalance2, startBalance3, startBalance4, startBalance5, startBalance6, startBalance7, startBalance8, startBalance9, startBalance10, startBalance11, startBalance12, startBalance13, startBalance14, startBalance15 };
            Label[] fundIncomeLabels = new Label[] { income1, income2, income3, income4, income5, income6, income7, income8, income9, income10, income11, income12, income13, income14, income15 };
            Label[] moneyTransferLabels = new Label[] { moneyTransfer1, moneyTransfer2, moneyTransfer3, moneyTransfer4, moneyTransfer5, moneyTransfer6, moneyTransfer7, moneyTransfer8, moneyTransfer9, moneyTransfer10, moneyTransfer11, moneyTransfer12, moneyTransfer13, moneyTransfer14, moneyTransfer15 };
            Label[] expensesLabels = new Label[] {expenses1, expenses2, expenses3, expenses4, expenses5, expenses6, expenses7, expenses8, expenses9, expenses10, expenses11, expenses12, expenses13, expenses14, expenses15};
            Label[] endBalanceLabels = new Label[] { endBalance1, endBalance2, endBalance3, endBalance4, endBalance5, endBalance6, endBalance7, endBalance8, endBalance9, endBalance10, endBalance11, endBalance12, endBalance13, endBalance14, endBalance15};

            for (int i = 0; i < 15; i++)
            {
                startBalanceLabels[i].Text = balance1[i].ToString() + " ₽";
                fundIncomeLabels[i].Text = income[i].ToString() + " ₽";
                if (moneyTransfer[i] < 0)
                {
                    moneyTransferLabels[i].ForeColor = Color.DarkRed;
                    moneyTransferLabels[i].Text = moneyTransfer[i].ToString()+ " ₽";
                } else if (moneyTransfer[i] == 0)
                {
                    moneyTransferLabels[i].ForeColor = Color.Gray; 
                    moneyTransferLabels[i].Text = moneyTransfer[i].ToString()+ " ₽";
                } else
                {
                    moneyTransferLabels[i].ForeColor = Color.DarkGreen;
                    moneyTransferLabels[i].Text = "+" + moneyTransfer[i].ToString()+ " ₽";
                }
                expensesLabels[i].Text = expenses[i].ToString() + " ₽";
                endBalanceLabels[i].Text = balance2[i].ToString() + " ₽";
            }
            calendar.MaxSelectionCount = periodLength;
            calendar.BoldedDates = new DateTime[] { DateTime.Now };
            calendar.SelectionStart = startDate;
            calendar.SelectionEnd = endDate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (provider.FindLastWeekInDb().Bankroll == null)
            {
                MessageBox.Show("Невозможно переводить деньги между счетам для периода без прихода денежных средств");
            }
            else if (isLastWeek)
            {
                MoneyTransfer moneytransfer = new MoneyTransfer();
                moneytransfer.TransferCreated += FormUpdate;
                moneytransfer.Show();
            }
        }

        private void Period_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isLastWeek)
            {
                RevenueForm revenueForm = new RevenueForm(PeriodNumber);
                revenueForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (provider.FindLastWeekInDb().Bankroll == null)
            {
                MessageBox.Show("Невозможно добавить расходы для периода с незаданным распределением");
            }
            else if (isLastWeek)
            {
                AllExpenses expenses = new AllExpenses("A1", PeriodNumber);
                expenses.Show();
            }
        }

        private void OpenFRS_Click(object sender, EventArgs e)
        {
            if (provider.FindWeekByNumber(PeriodNumber).Bankroll == null)
            {
                MessageBox.Show("Невозможно построить ФРС недели, для которой не задано распределение");
            }
            else
            {
                try
                {
                    FormDistributionOfFundsTable table = new FormDistributionOfFundsTable(provider, PeriodNumber);
                }
                catch
                {
                    MessageBox.Show("Ошибка формирования таблицы Excel");
                }
            }   
        }
        public void FormUpdate()
        {
            this.Close();
            Period period = new Period(PeriodNumber);
            period.Show();
        }

        public void Fund_Click(object sender, EventArgs e)
        {
            string FundCode = ((FundLabel)sender).FundCode;
            FundForm form = new FundForm(FundCode);
            form.Show();
        }
    }
}
