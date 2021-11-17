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
        string id = null;
        string fundKey;
        public delegate void UpdateHandler();
        public event UpdateHandler ExpenceCreated;

        private double[] fundBalances = new double[15];
        public Expenses(string id, string fundKey)
        {
            this.fundKey = fundKey;
            this.id = id;
            DataProvider provider = new DataProvider();

            var exp = provider.GetAllExpendutiresData().FirstOrDefault(p => p.Id == id);
            
            var fundConditions = provider.GetFundConditionsByWeek(provider.FindLastWeekInDb().Number);
            double[] fromDB = new double[fundConditions.Length];

            for (int counter = 0; counter < fundConditions.Length; counter++)
            {
                fromDB[counter] = Math.Round(fundConditions[counter].MoneySumAfterFinPlan, 2);
            }

            fromDB.CopyTo(fundBalances, 0x0000);
            InitializeComponent();
            label1.Text = "Редактировать затрату из фонда";

            fundPicker.SelectedItem = fundKey;
            fundPicker.Enabled = false;
            expenditureName.Text = exp.Name;
            expenditureSum.Text = exp.MoneySum.ToString();
        }

        public Expenses(string fundKey)
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
            label1.Text = "Добавить затрату из фонда";
            fundPicker.SelectedItem = fundKey;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == null)
                {
                    Expenditure expenditure = new Expenditure(Convert.ToDouble(expenditureSum.Text), expenditureName.Text);
                    DataAdder dataAdder = new DataAdder();
                    dataAdder.AddExpenditure(fundPicker.Text, expenditure);
                    this.Close();
                    MessageBox.Show("Трата успешно добавлена");
                }
                else
                {
                    DataEditor dataEditor = new DataEditor();
                    Expenditure expenditure = new Expenditure(Convert.ToDouble(expenditureSum.Text), expenditureName.Text);
                    dataEditor.EditExpenditureData(fundKey, id, expenditure);
                    this.Close();
                    MessageBox.Show("Трата успешно отредактирована");
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(id == null)
            {
                this.Close();
                MessageBox.Show("Вы нихуя не сделали поэтому мы закрываем форму");
            }
            else
            {
                DataEditor dataEditor = new DataEditor();
                dataEditor.DeleteExpenditure(fundKey, id);
                this.Close();
                MessageBox.Show("Затрата удалена");
            }
        }
    }
}
