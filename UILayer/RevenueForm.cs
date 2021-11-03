using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.BankrollDistribution;
using DataLayer.Entities;

namespace Supervisor
{
    public partial class RevenueForm : Form
    {
        Label[] incomeLabels = new Label[15];
        int periodNum;

        DataProvider _dataProvider;
        DataEditor _dataEditor;
        DataAdder _dataAdder;

        WeekModel _currentWeek;
        FundsGroup _fundsGroup;

        Bankroll _bankroll;
        

        public RevenueForm(int periodNum)
        {
            InitializeComponent();

            this.periodNum = periodNum;
            _dataEditor = new DataEditor();
            _dataAdder = new DataAdder();
            _dataProvider = new DataProvider();

            _currentWeek = _dataProvider.FindWeekByNumber(periodNum);
            calendar.SelectionStart = _currentWeek.Start;
            calendar.SelectionEnd = _currentWeek.End;

            label1.Text = "Поступления за отчетный период №" + periodNum;

            Label[] labels = new Label[] { incomeLabel1, incomeLabel2, incomeLabel3, incomeLabel4, incomeLabel5, incomeLabel6, incomeLabel7, incomeLabel8, incomeLabel9, incomeLabel10, incomeLabel11, incomeLabel12, incomeLabel13, incomeLabel14, incomeLabel15 };
            incomeLabels = labels;

            UpdateInputLabels();
            UpdateOutputLabels();

            labels.CopyTo(incomeLabels, 0);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            double serviceSum = 0;
            double goodsSum = 0;
            double totalSum = 0;

            try
            {
                serviceSum = double.Parse(serviceRevenueSum.Text);
                goodsSum = double.Parse(goodsRevenueSum.Text);
                totalSum = Math.Round(serviceSum + goodsSum, 2);
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных");
            }

            Week week = new Week(_currentWeek.Start, _currentWeek.End);
            DistributionPlanner planner = new DistributionPlanner(week);
            Bankroll bankroll = new Bankroll(totalSum, serviceSum, goodsSum);
            _bankroll = bankroll;
            _fundsGroup = new FundsGroup();

            planner.DistributeMoneyForFunds(bankroll, _fundsGroup);

            if (_dataProvider.FindLastWeekInDb().Bankroll == null)
            {
                _dataAdder.SetBankrollData(_fundsGroup, _bankroll);
            }
            else
            {
                //_dataEditor.EditBankrollData(_bankroll); чето хуйня какая-то
            }

            UpdateInputLabels();
            UpdateOutputLabels();
        }

        private void UpdateInputLabels()
        {
            if (_dataProvider.FindLastWeekInDb().Bankroll != null)
            {
                serviceRevenueSum.Text = _dataProvider.FindLastWeekInDb().Bankroll.ServiceRevenue.ToString();
                goodsRevenueSum.Text = _dataProvider.FindLastWeekInDb().Bankroll.GoodsRevenue.ToString();
                totalRevenueSum.Text = _dataProvider.FindLastWeekInDb().Bankroll.TotalSum.ToString();
            }
            else
            {
                serviceRevenueSum.Text = "0";
                goodsRevenueSum.Text = "0";
                totalRevenueSum.Text = "0";
            }
        }

        private void UpdateOutputLabels()
        {
            var funds = _dataProvider.GetFundsData();
            string[] fundsKeys = new string[funds.Length];

            for (int counter = 0; counter < funds.Length; counter++)
            {
                fundsKeys[counter] = funds[counter].Key;
            }
            if(_dataProvider.FindLastWeekInDb().Bankroll == null)
            {
                for (int counter = 0; counter < funds.Length; counter++)
                {
                    incomeLabels[counter].Text = "0 ₽";
                }
            }
            else
            {
                for (int counter = 0; counter < funds.Length; counter++)
                {
                    incomeLabels[counter].Text = _dataProvider.FindRevenueToFundByWeek(periodNum, fundsKeys[counter]).TotalSum + " ₽";
                }
            }
        }
    }
}
