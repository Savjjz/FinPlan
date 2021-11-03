using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.DbConfig;
using DataLayer.Entities;

namespace UILayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddBankrollToDb_Click(object sender, EventArgs e)
        {
            //using (DataContext db = new DataContext())
            //{
            //    BankrollModel bankroll = new BankrollModel
            //    {
            //        TotalSum = Convert.ToDouble(TotalSum.Text),
            //        GoodsRevenue = Convert.ToDouble(GoodsRevenue.Text),
            //        ServiceReveue = Convert.ToDouble(ServiceRevenue.Text)
            //    };
            //    db.Bankrolls.Add(bankroll);
            //    db.SaveChanges();
            //    MessageBox.Show("ДС успешно добавлены");
            //}
        }

        private void AddFundToDb_Click(object sender, EventArgs e)
        {
            //using (DataContext db = new DataContext())
            //{
            //    FundModel fund = new FundModel
            //    {
            //        Key = FundCode.Text,
            //        Name = FundName.Text,
            //        PercentFromBanckroll = Convert.ToDouble(FundPercent.Text)
            //    };
            //    db.Funds.Add(fund);
            //    db.SaveChanges();
            //    MessageBox.Show("Фонд успешно добавлен");
            //}
        }
    }
}
