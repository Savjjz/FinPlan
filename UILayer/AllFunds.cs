using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Supervisor;

namespace UILayer
{
    public partial class AllFunds : Form
    {
        public AllFunds()
        {
            InitializeComponent();
        }

        public void FundLabel_Click(object sender, EventArgs e)
        {
            string FundCode = ((FundLabel)sender).FundCode;
            FundForm form = new FundForm(FundCode);
            form.Show();
        }
        public void FundPanel_Click(object sender, EventArgs e)
        {
            string FundCode = ((FundPanel)sender).FundCode;
            FundForm form = new FundForm(FundCode);
            form.Show();
        }

    }
}
