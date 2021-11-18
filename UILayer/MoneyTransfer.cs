using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;

namespace Supervisor
{
    public partial class MoneyTransfer : Form
    {
        public delegate void UpdateHandler();
        public event UpdateHandler TransferCreated;

        private decimal[] fundBalances = new decimal[15];
        private DataAdder _dataAdder;
        private DataProvider _dataProvider;

        public MoneyTransfer()
        {
            _dataAdder = new DataAdder();
            _dataProvider = new DataProvider();

            var fundConditions = _dataProvider.GetFundConditionsByWeek(_dataProvider.FindLastWeekInDb().Number);
            decimal[] fromDB = new decimal[fundConditions.Length];

            for (int counter = 0; counter < fundConditions.Length; counter++)
            {
                fromDB[counter] = Math.Round(fundConditions[counter].MoneySumAfterFinPlan, 2);
            }
            
            fromDB.CopyTo(fundBalances, 0x0000);
            InitializeComponent();
        }

        private void MoneyTransfer_Load(object sender, EventArgs e)
        {

        }

        private void fundPicker1_TextUpdate(object sender, EventArgs e)
        {
            label5.Text = "Выберите из выпадающего списка";
        }

        private void fundPicker1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label5.Text = "На счету:" + fundBalances[fundPicker1.SelectedIndex].ToString()+ " ₽";
        }

        private void fundPicker2_TextUpdate(object sender, EventArgs e)
        {
            label6.Text = "Выберите из выпадающего списка";
        }

        private void fundPicker2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label6.Text = "На счету:" + fundBalances[fundPicker2.SelectedIndex].ToString()+ " ₽";
        }


        private void Submit_Click(object sender, EventArgs e)
        {
            decimal value = decimal.Parse(transferValue.Text);
            string _donorFundKey = fundPicker1.Text;
            string _endowmentFunKey = fundPicker2.Text;
            try
            {
                _dataAdder.TransferMoneyBetweenFunds(_donorFundKey, _endowmentFunKey, value);
                this.Close();
                MessageBox.Show("Перевод между фондами успешно завершен");
                TransferCreated();
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных");
            }
        }
    }
}
