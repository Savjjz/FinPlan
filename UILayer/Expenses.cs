using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer.BankrollDistribution;
using BusinessLogicLayer.DbBlock;

namespace Supervisor
{
    public partial class Expenses : Form
    {
        public delegate void UpdateHandler();
        public event UpdateHandler ExpenceCreated;

        private double[] fundBalances = new double[15];

        public Expenses()
        {
            DataProvider provider = new DataProvider();
            var fundConditions = provider.GetFundConditionsByWeek(provider.FindLastWeekInDb().Number);
            double[] fromDB = new double[fundConditions.Length];

            for (int counter = 0; counter < fundConditions.Length; counter++)
            {
                fromDB[counter] = Math.Round(fundConditions[counter].MoneySumAfterFinPlan, 2);
            }

            fromDB.CopyTo(fundBalances, 0x0000);
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Expenditure expenditure = new Expenditure(Convert.ToDouble(expenditureSum.Text), expenditureName.Text);
                DataAdder dataAdder = new DataAdder();
                dataAdder.AddExpenditure(fundPicker.Text, expenditure);
                this.Close();
                MessageBox.Show("Трата успешно добавлена");
                ExpenceCreated();
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных");
            }
        }

        private void fundPicker_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label5.Text = "На счету:" + fundBalances[fundPicker.SelectedIndex].ToString() + " ₽";
        }
    }
}
