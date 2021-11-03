using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataLayer.Entities;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.ExcelBlock;

namespace Supervisor
{
    public partial class summary : Form
    {
        int firstPeriodNum;
        int lastPeriodNum;
        DataProvider _provider;


        public summary()
        {
            InitializeComponent();

            _provider = new DataProvider();
            firstPeriodNum = _provider.FindFirstWeekInDb().Number; ;
            lastPeriodNum = _provider.FindLastWeekInDb().Number;

            PeriodTable.ColumnStyles.Clear();
            if (lastPeriodNum != 0) 
            {
                for (int counter = firstPeriodNum; counter <= lastPeriodNum; counter++)
                {
                    DrowPeriodPanel(counter);
                }
                
            }
            DrowCreateNewPeriodPanel();
        }

        private void summary_Load(object sender, EventArgs e)
        {

        }
        public void DrowPeriodPanel(int periodNum)
        {
            var currentWeek = _provider.FindWeekByNumber(periodNum);

            DateTime startDate = currentWeek.Start;
            DateTime endDate = currentWeek.End;

            PeriodTable.ColumnCount++;
            PeriodTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));

            PeriodPanel container = new PeriodPanel(periodNum);
            container.Dock = DockStyle.Fill;
            container.BackColor = Color.FromName("ControlLight");
            container.BorderStyle = BorderStyle.FixedSingle;
            container.Cursor = Cursors.Hand;
            container.Click += new EventHandler(PeriodPanel_Click);

            PeriodLabel periodLabel = new PeriodLabel(periodNum);
            periodLabel.BorderStyle = BorderStyle.FixedSingle;
            periodLabel.AutoSize = false;
            periodLabel.Size = new Size(146, 30);
            periodLabel.Text = "Период №" + periodNum.ToString();
            periodLabel.TextAlign = ContentAlignment.MiddleCenter;
            periodLabel.Location = new Point(3, 3);
            periodLabel.Click += new EventHandler(PeriodLabel_Click);

            PeriodLabel startDateLabel = new PeriodLabel(periodNum);
            startDateLabel.AutoSize = false;
            startDateLabel.Size = new Size(146, 30);
            startDateLabel.Text = "Начало периода: " + startDate.ToShortDateString();
            startDateLabel.TextAlign = ContentAlignment.MiddleLeft;
            startDateLabel.Location = new Point(3, 42);
            startDateLabel.Click += new EventHandler(PeriodLabel_Click);

            PeriodLabel endDateLabel = new PeriodLabel(periodNum);
            endDateLabel.AutoSize = false;
            endDateLabel.Size = new Size(146, 30);
            endDateLabel.Text = "Конец периода: " + endDate.ToShortDateString();
            endDateLabel.TextAlign = ContentAlignment.MiddleLeft;
            endDateLabel.Location = new Point(3, 79);
            endDateLabel.Click += new EventHandler(PeriodLabel_Click);

            container.Controls.Add(periodLabel);
            container.Controls.Add(startDateLabel);
            container.Controls.Add(endDateLabel);

            PeriodTable.Controls.Add(container, periodNum - firstPeriodNum, 0);
        }
        public void DrowCreateNewPeriodPanel()
        {
            PeriodTable.ColumnCount++;
            PeriodTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            Panel container = new Panel();
            container.BackColor = Color.FromName("ControlLight");
            container.Dock = DockStyle.Fill;
            container.BorderStyle = BorderStyle.FixedSingle;
            container.Cursor = Cursors.Hand;
            Label create = new Label();
            create.Text = "Создать новый период";
            create.TextAlign = ContentAlignment.MiddleCenter;
            create.Dock = DockStyle.Fill;
            create.Click += new EventHandler(CreateNewPeriod_Click);
            container.Controls.Add(create);
            if (_provider.GetAllWeeksData().Length != 0)
            {
                PeriodTable.Controls.Add(container, lastPeriodNum - firstPeriodNum + 1, 0);
            }
            else
            {
                PeriodTable.Controls.Add(container, 0, 0);
            }
            
        }

        private void CreateNewPeriod_Click(object sender, EventArgs e)
        {
            CreateNewPeriod form = new CreateNewPeriod();
            form.PeriodCreated += FormUpdate;
            form.Show();
        }

        public void PeriodPanel_Click(object sender, EventArgs e)
        {
            int PeriodNum = ((PeriodPanel)sender).PeriodNum;
            Period form = new Period(PeriodNum);
            form.Show();
        }
        private void PeriodLabel_Click(object sender, EventArgs e)
        {
            int PeriodNum = ((PeriodLabel)sender).PeriodNum;
            Period form = new Period(PeriodNum);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider provider = new DataProvider();
                BankrollTraficTable table = new BankrollTraficTable(provider);
            }
            catch
            {
                MessageBox.Show("Ошибка формирования таблицы Excel");
            }
        }

        private void FormUpdate()
        {
            this.Close();
            summary form = new summary();
            form.Show();
        }
    }
}
