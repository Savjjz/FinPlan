using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.BankrollDistribution;

namespace UILayer
{
    public partial class EditFundDisribution : Form
    {
        DataProvider _provider;
        DataEditor _editor;
        TextBox[] _percentsBoxes;

        public EditFundDisribution()
        {
            _provider = new DataProvider();
            _editor = new DataEditor();
            decimal[] percents = new decimal[15];
            var funds  = _provider.GetFundsData();
            for (int counter = 0; counter <funds.Length; counter++)
            {
                percents[counter] = funds[counter].PercentFromBanckroll;
            }
            InitializeComponent();
            _percentsBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15 };
            for(int i = 0; i < 15; i++)
            {
                _percentsBoxes[i].Text = percents[i].ToString();
            }
        }

        private void EditFundDisribution_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePercents_Click(object sender, EventArgs e)
        {
            decimal[] newPercents = new decimal[_percentsBoxes.Length];
            for (int counter = 0; counter < _percentsBoxes.Length; counter++)
            {
                newPercents[counter] = Convert.ToDecimal(_percentsBoxes[counter].Text);
            }
            
            if (!IsPercentsCorrect(newPercents))
            {
                MessageBox.Show("Проверьте корректность введенных процентов");
                return;
            }

            int fundCounter = 1;
            List<Fund> funds = new List<Fund>();
            string group = "A";
            for (int counter = 1; counter <= 4; counter++)
            {
                string fundKey = group + Convert.ToString(fundCounter);
                Fund fund = new Fund(fundKey, newPercents[counter]);
                fundCounter++;
                funds.Add(fund);
            }

            fundCounter = 1;
            group = "B";
            for (int counter = 1; counter <= 8; counter++)
            {
                string fundKey = group + Convert.ToString(fundCounter);
                Fund fund = new Fund(fundKey, newPercents[counter]);
                fundCounter++;
                funds.Add(fund);
            }

            fundCounter = 1;
            group = "C";
            for (int counter = 1; counter <= 3; counter++)
            {
                string fundKey = group + Convert.ToString(fundCounter);
                Fund fund = new Fund(fundKey, newPercents[counter]);
                fundCounter++;
                funds.Add(fund);
            }

            _editor.EdditFundsPercentsData(funds.ToArray());
        }

        private bool IsPercentsCorrect(decimal[] percents)
        {
            decimal servicePercents = 100;
            decimal goodsPercnets = 100;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    goodsPercnets -= percents[i];
                }
                else if (i == 1)
                {
                    servicePercents -= percents[i];
                }
                else
                {
                    goodsPercnets -= percents[i];
                    servicePercents -= percents[i];
                }
            }

            if ((servicePercents < 0) || (goodsPercnets < 0))
                return false;

            decimal remainder = 100;

            for (int i = 4; i < 12; i++)
            {
                remainder -= percents[i];
            }

            if (remainder <= 0)
                return false;

            remainder = 100;
            for (int i = 12; i < 15; i++)
            {
                remainder -= percents[i];
            }
            if (remainder != 0)
                return false;

            return true;
        }
    }
}
