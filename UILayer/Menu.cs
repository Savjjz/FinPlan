using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Supervisor;
using BusinessLogicLayer.DbBlock;

namespace UILayer
{
    public partial class Menu : Form
    {
        DataProvider _provider;
        public Menu()
        {
            _provider = new DataProvider();

            InitializeComponent();

            if (_provider.FindLastWeekInDb().Number == 0)
            {
                monthCalendar1.SelectionStart = DateTime.Now;
                monthCalendar1.SelectionEnd = DateTime.Now;
                label1.Text = "Отчетные периоды не созданы";
            }
            else
            {
                monthCalendar1.MaxSelectionCount = _provider.FindLastWeekInDb().End.Subtract(_provider.FindLastWeekInDb().Start).Days + 1;
                monthCalendar1.SelectionEnd = _provider.FindLastWeekInDb().End;
                monthCalendar1.SelectionStart = _provider.FindLastWeekInDb().Start;
                label1.Text = "Отчетный период №"+_provider.FindLastWeekInDb().Number.ToString();
            }






            if (_provider.FindLastWeekInDb().Bankroll == null)
            {
                label3.Text = "Приход денежных средств не добавлен";
            }
            else
            {
                label3.Text = "Приход денежных средств добавлен";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            summary form = new summary();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllFunds form = new AllFunds();
            form.Show();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
