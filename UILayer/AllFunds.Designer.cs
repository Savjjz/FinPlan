using Supervisor;
using System.Windows.Forms;

namespace UILayer
{
    partial class AllFunds
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelC3 = new FundPanel("C3");
            this.descC3 = new FundLabel("C3");
            this.labelC3 = new FundLabel("C3");
            this.panelC2 = new FundPanel("C2");
            this.descC2 = new FundLabel("C2");
            this.labelC2 = new FundLabel("C2");
            this.panelC1 = new FundPanel("C1");
            this.descC1 = new FundLabel("C1");
            this.labelC1 = new FundLabel("C1");
            this.panelB8 = new FundPanel("B8");
            this.descB8 = new FundLabel("B8");
            this.labelB8 = new FundLabel("B8");
            this.panelB7 = new FundPanel("B7");
            this.descB7 = new FundLabel("B7");
            this.labelB7 = new FundLabel("B7");
            this.panelB6 = new FundPanel("B6");
            this.descB6 = new FundLabel("B6");
            this.labelB6 = new FundLabel("B6");
            this.panelB5 = new FundPanel("B5");
            this.descB5 = new FundLabel("B5");
            this.labelB5 = new FundLabel("B5");
            this.panelB4 = new FundPanel("B4");
            this.descB4 = new FundLabel("B4");
            this.labelB4 = new FundLabel("B4");
            this.panelB3 = new FundPanel("B3");
            this.descB3 = new FundLabel("B3");
            this.labelB3 = new FundLabel("B3");
            this.panelB2 = new FundPanel("B2");
            this.descB2 = new FundLabel("B2");
            this.labelB2 = new FundLabel("B2");
            this.panelB1 = new FundPanel("B1");
            this.descB1 = new FundLabel("B1");
            this.labelB1 = new FundLabel("B1");
            this.panelA1 = new FundPanel("A1");
            this.descA1 = new FundLabel("A1");
            this.labelA1 = new FundLabel("A1");
            this.panelA2 = new FundPanel("A2");
            this.descA2 = new FundLabel("A2");
            this.labelA2 = new FundLabel("A2");
            this.panelA3 = new FundPanel("A3");
            this.descA3 = new FundLabel("A3");
            this.labelA3 = new FundLabel("A3");
            this.panelA4 = new FundPanel("A4");
            this.descA4 = new FundLabel("A4");
            this.labelA4 = new FundLabel("A4");
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelC3.SuspendLayout();
            this.panelC2.SuspendLayout();
            this.panelC1.SuspendLayout();
            this.panelB8.SuspendLayout();
            this.panelB7.SuspendLayout();
            this.panelB6.SuspendLayout();
            this.panelB5.SuspendLayout();
            this.panelB4.SuspendLayout();
            this.panelB3.SuspendLayout();
            this.panelB2.SuspendLayout();
            this.panelB1.SuspendLayout();
            this.panelA1.SuspendLayout();
            this.panelA2.SuspendLayout();
            this.panelA3.SuspendLayout();
            this.panelA4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 619);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panelA4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelA3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelA2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelA1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelC3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelC2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelC1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelB8, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panelB7, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.panelB6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panelB5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panelB4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelB3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelB2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelB1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(532, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelC3
            // 
            this.panelC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelC3.Controls.Add(this.descC3);
            this.panelC3.Controls.Add(this.labelC3);
            this.panelC3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelC3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelC3.Location = new System.Drawing.Point(357, 155);
            this.panelC3.Name = "panelC3";
            this.panelC3.Size = new System.Drawing.Size(172, 70);
            this.panelC3.TabIndex = 14;
            this.panelC3.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descC3
            // 
            this.descC3.AutoSize = true;
            this.descC3.Location = new System.Drawing.Point(4, 28);
            this.descC3.MaximumSize = new System.Drawing.Size(168, 0);
            this.descC3.Name = "descC3";
            this.descC3.Size = new System.Drawing.Size(147, 15);
            this.descC3.TabIndex = 1;
            this.descC3.Text = "Фонд жизнедеятельности";
            this.descC3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelC3
            // 
            this.labelC3.AutoSize = true;
            this.labelC3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelC3.Location = new System.Drawing.Point(4, 4);
            this.labelC3.Name = "labelC3";
            this.labelC3.Size = new System.Drawing.Size(69, 20);
            this.labelC3.TabIndex = 0;
            this.labelC3.Text = "Фонд C3";
            this.labelC3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelC2
            // 
            this.panelC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelC2.Controls.Add(this.descC2);
            this.panelC2.Controls.Add(this.labelC2);
            this.panelC2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelC2.Location = new System.Drawing.Point(357, 79);
            this.panelC2.Name = "panelC2";
            this.panelC2.Size = new System.Drawing.Size(172, 70);
            this.panelC2.TabIndex = 13;
            this.panelC2.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descC2
            // 
            this.descC2.AutoSize = true;
            this.descC2.Location = new System.Drawing.Point(4, 28);
            this.descC2.MaximumSize = new System.Drawing.Size(168, 0);
            this.descC2.Name = "descC2";
            this.descC2.Size = new System.Drawing.Size(103, 15);
            this.descC2.TabIndex = 1;
            this.descC2.Text = "Фонд маркетинга";
            this.descC2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelC2
            // 
            this.labelC2.AutoSize = true;
            this.labelC2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelC2.Location = new System.Drawing.Point(4, 4);
            this.labelC2.Name = "labelC2";
            this.labelC2.Size = new System.Drawing.Size(69, 20);
            this.labelC2.TabIndex = 0;
            this.labelC2.Text = "Фонд C2";
            this.labelC2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelC1
            // 
            this.panelC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelC1.Controls.Add(this.descC1);
            this.panelC1.Controls.Add(this.labelC1);
            this.panelC1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelC1.Location = new System.Drawing.Point(357, 3);
            this.panelC1.Name = "panelC1";
            this.panelC1.Size = new System.Drawing.Size(172, 70);
            this.panelC1.TabIndex = 12;
            this.panelC1.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descC1
            // 
            this.descC1.AutoSize = true;
            this.descC1.Location = new System.Drawing.Point(4, 28);
            this.descC1.MaximumSize = new System.Drawing.Size(168, 0);
            this.descC1.Name = "descC1";
            this.descC1.Size = new System.Drawing.Size(129, 30);
            this.descC1.TabIndex = 1;
            this.descC1.Text = "Фонд корпоративных расходов";
            this.descC1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelC1
            // 
            this.labelC1.AutoSize = true;
            this.labelC1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelC1.Location = new System.Drawing.Point(4, 4);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(67, 20);
            this.labelC1.TabIndex = 0;
            this.labelC1.Text = "Фонд C1";
            this.labelC1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB8
            // 
            this.panelB8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB8.Controls.Add(this.descB8);
            this.panelB8.Controls.Add(this.labelB8);
            this.panelB8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB8.Location = new System.Drawing.Point(180, 535);
            this.panelB8.Name = "panelB8";
            this.panelB8.Size = new System.Drawing.Size(171, 72);
            this.panelB8.TabIndex = 11;
            this.panelB8.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB8
            // 
            this.descB8.AutoSize = true;
            this.descB8.Location = new System.Drawing.Point(4, 28);
            this.descB8.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB8.Name = "descB8";
            this.descB8.Size = new System.Drawing.Size(168, 30);
            this.descB8.TabIndex = 1;
            this.descB8.Text = "Фонд средства производства и инструмент";
            this.descB8.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB8
            // 
            this.labelB8.AutoSize = true;
            this.labelB8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB8.Location = new System.Drawing.Point(4, 4);
            this.labelB8.Name = "labelB8";
            this.labelB8.Size = new System.Drawing.Size(69, 20);
            this.labelB8.TabIndex = 0;
            this.labelB8.Text = "Фонд B8";
            this.labelB8.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB7
            // 
            this.panelB7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB7.Controls.Add(this.descB7);
            this.panelB7.Controls.Add(this.labelB7);
            this.panelB7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB7.Location = new System.Drawing.Point(180, 459);
            this.panelB7.Name = "panelB7";
            this.panelB7.Size = new System.Drawing.Size(171, 70);
            this.panelB7.TabIndex = 10;
            this.panelB7.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB7
            // 
            this.descB7.AutoSize = true;
            this.descB7.Location = new System.Drawing.Point(4, 28);
            this.descB7.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB7.Name = "descB7";
            this.descB7.Size = new System.Drawing.Size(124, 30);
            this.descB7.TabIndex = 1;
            this.descB7.Text = "Фонд просроченной задолженности";
            this.descB7.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB7
            // 
            this.labelB7.AutoSize = true;
            this.labelB7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB7.Location = new System.Drawing.Point(4, 4);
            this.labelB7.Name = "labelB7";
            this.labelB7.Size = new System.Drawing.Size(69, 20);
            this.labelB7.TabIndex = 0;
            this.labelB7.Text = "Фонд B7";
            this.labelB7.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB6
            // 
            this.panelB6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB6.Controls.Add(this.descB6);
            this.panelB6.Controls.Add(this.labelB6);
            this.panelB6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB6.Location = new System.Drawing.Point(180, 383);
            this.panelB6.Name = "panelB6";
            this.panelB6.Size = new System.Drawing.Size(171, 70);
            this.panelB6.TabIndex = 9;
            this.panelB6.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB6
            // 
            this.descB6.AutoSize = true;
            this.descB6.Location = new System.Drawing.Point(4, 28);
            this.descB6.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB6.Name = "descB6";
            this.descB6.Size = new System.Drawing.Size(82, 15);
            this.descB6.TabIndex = 1;
            this.descB6.Text = "Фонд кредита";
            this.descB6.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB6
            // 
            this.labelB6.AutoSize = true;
            this.labelB6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB6.Location = new System.Drawing.Point(4, 4);
            this.labelB6.Name = "labelB6";
            this.labelB6.Size = new System.Drawing.Size(69, 20);
            this.labelB6.TabIndex = 0;
            this.labelB6.Text = "Фонд B6";
            this.labelB6.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB5
            // 
            this.panelB5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB5.Controls.Add(this.descB5);
            this.panelB5.Controls.Add(this.labelB5);
            this.panelB5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB5.Location = new System.Drawing.Point(180, 307);
            this.panelB5.Name = "panelB5";
            this.panelB5.Size = new System.Drawing.Size(171, 70);
            this.panelB5.TabIndex = 8;
            this.panelB5.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB5
            // 
            this.descB5.AutoSize = true;
            this.descB5.Location = new System.Drawing.Point(4, 28);
            this.descB5.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB5.Name = "descB5";
            this.descB5.Size = new System.Drawing.Size(89, 15);
            this.descB5.TabIndex = 1;
            this.descB5.Text = "Фонд резервов";
            this.descB5.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB5
            // 
            this.labelB5.AutoSize = true;
            this.labelB5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB5.Location = new System.Drawing.Point(4, 4);
            this.labelB5.Name = "labelB5";
            this.labelB5.Size = new System.Drawing.Size(69, 20);
            this.labelB5.TabIndex = 0;
            this.labelB5.Text = "Фонд B5";
            this.labelB5.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB4
            // 
            this.panelB4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB4.Controls.Add(this.descB4);
            this.panelB4.Controls.Add(this.labelB4);
            this.panelB4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB4.Location = new System.Drawing.Point(180, 231);
            this.panelB4.Name = "panelB4";
            this.panelB4.Size = new System.Drawing.Size(171, 70);
            this.panelB4.TabIndex = 7;
            this.panelB4.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB4
            // 
            this.descB4.AutoSize = true;
            this.descB4.Location = new System.Drawing.Point(4, 28);
            this.descB4.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB4.Name = "descB4";
            this.descB4.Size = new System.Drawing.Size(113, 15);
            this.descB4.TabIndex = 1;
            this.descB4.Text = "Фонд оплаты труда";
            this.descB4.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB4
            // 
            this.labelB4.AutoSize = true;
            this.labelB4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB4.Location = new System.Drawing.Point(4, 4);
            this.labelB4.Name = "labelB4";
            this.labelB4.Size = new System.Drawing.Size(70, 20);
            this.labelB4.TabIndex = 0;
            this.labelB4.Text = "Фонд B4";
            this.labelB4.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB3
            // 
            this.panelB3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB3.Controls.Add(this.descB3);
            this.panelB3.Controls.Add(this.labelB3);
            this.panelB3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB3.Location = new System.Drawing.Point(180, 155);
            this.panelB3.Name = "panelB3";
            this.panelB3.Size = new System.Drawing.Size(171, 70);
            this.panelB3.TabIndex = 6;
            this.panelB3.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB3
            // 
            this.descB3.AutoSize = true;
            this.descB3.Location = new System.Drawing.Point(4, 28);
            this.descB3.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB3.Name = "descB3";
            this.descB3.Size = new System.Drawing.Size(80, 15);
            this.descB3.TabIndex = 1;
            this.descB3.Text = "Фонд аренды";
            this.descB3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB3
            // 
            this.labelB3.AutoSize = true;
            this.labelB3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB3.Location = new System.Drawing.Point(4, 4);
            this.labelB3.Name = "labelB3";
            this.labelB3.Size = new System.Drawing.Size(69, 20);
            this.labelB3.TabIndex = 0;
            this.labelB3.Text = "Фонд B3";
            this.labelB3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB2
            // 
            this.panelB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB2.Controls.Add(this.descB2);
            this.panelB2.Controls.Add(this.labelB2);
            this.panelB2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB2.Location = new System.Drawing.Point(180, 79);
            this.panelB2.Name = "panelB2";
            this.panelB2.Size = new System.Drawing.Size(171, 70);
            this.panelB2.TabIndex = 5;
            this.panelB2.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB2
            // 
            this.descB2.AutoSize = true;
            this.descB2.Location = new System.Drawing.Point(4, 28);
            this.descB2.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB2.Name = "descB2";
            this.descB2.Size = new System.Drawing.Size(159, 15);
            this.descB2.TabIndex = 1;
            this.descB2.Text = "Фонд налогов (кроме с з/п)";
            this.descB2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB2
            // 
            this.labelB2.AutoSize = true;
            this.labelB2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB2.Location = new System.Drawing.Point(4, 4);
            this.labelB2.Name = "labelB2";
            this.labelB2.Size = new System.Drawing.Size(69, 20);
            this.labelB2.TabIndex = 0;
            this.labelB2.Text = "Фонд B2";
            this.labelB2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelB1
            // 
            this.panelB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelB1.Controls.Add(this.descB1);
            this.panelB1.Controls.Add(this.labelB1);
            this.panelB1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelB1.Location = new System.Drawing.Point(180, 3);
            this.panelB1.Name = "panelB1";
            this.panelB1.Size = new System.Drawing.Size(171, 70);
            this.panelB1.TabIndex = 4;
            this.panelB1.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descB1
            // 
            this.descB1.AutoSize = true;
            this.descB1.Location = new System.Drawing.Point(4, 28);
            this.descB1.MaximumSize = new System.Drawing.Size(168, 0);
            this.descB1.Name = "descB1";
            this.descB1.Size = new System.Drawing.Size(103, 15);
            this.descB1.TabIndex = 1;
            this.descB1.Text = "Фонд дивидендов";
            this.descB1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelB1
            // 
            this.labelB1.AutoSize = true;
            this.labelB1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelB1.Location = new System.Drawing.Point(4, 4);
            this.labelB1.Name = "labelB1";
            this.labelB1.Size = new System.Drawing.Size(67, 20);
            this.labelB1.TabIndex = 0;
            this.labelB1.Text = "Фонд B1";
            this.labelB1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelA1
            // 
            this.panelA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelA1.Controls.Add(this.descA1);
            this.panelA1.Controls.Add(this.labelA1);
            this.panelA1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelA1.Location = new System.Drawing.Point(3, 3);
            this.panelA1.Name = "panelA1";
            this.panelA1.Size = new System.Drawing.Size(171, 70);
            this.panelA1.TabIndex = 15;
            this.panelA1.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descA1
            // 
            this.descA1.AutoSize = true;
            this.descA1.Location = new System.Drawing.Point(4, 28);
            this.descA1.MaximumSize = new System.Drawing.Size(168, 0);
            this.descA1.Name = "descA1";
            this.descA1.Size = new System.Drawing.Size(142, 15);
            this.descA1.TabIndex = 1;
            this.descA1.Text = "Фонд поставщиков ТМЦ";
            this.descA1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelA1
            // 
            this.labelA1.AutoSize = true;
            this.labelA1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelA1.Location = new System.Drawing.Point(4, 4);
            this.labelA1.Name = "labelA1";
            this.labelA1.Size = new System.Drawing.Size(68, 20);
            this.labelA1.TabIndex = 0;
            this.labelA1.Text = "Фонд A1";
            this.labelA1.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelA2
            // 
            this.panelA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelA2.Controls.Add(this.descA2);
            this.panelA2.Controls.Add(this.labelA2);
            this.panelA2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelA2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelA2.Location = new System.Drawing.Point(3, 79);
            this.panelA2.Name = "panelA2";
            this.panelA2.Size = new System.Drawing.Size(171, 70);
            this.panelA2.TabIndex = 16;
            this.panelA2.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descA2
            // 
            this.descA2.AutoSize = true;
            this.descA2.Location = new System.Drawing.Point(4, 28);
            this.descA2.MaximumSize = new System.Drawing.Size(168, 0);
            this.descA2.Name = "descA2";
            this.descA2.Size = new System.Drawing.Size(116, 30);
            this.descA2.TabIndex = 1;
            this.descA2.Text = "Фонд поставщиков материалов";
            this.descA2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelA2
            // 
            this.labelA2.AutoSize = true;
            this.labelA2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelA2.Location = new System.Drawing.Point(4, 4);
            this.labelA2.Name = "labelA2";
            this.labelA2.Size = new System.Drawing.Size(70, 20);
            this.labelA2.TabIndex = 0;
            this.labelA2.Text = "Фонд A2";
            this.labelA2.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelA3
            // 
            this.panelA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelA3.Controls.Add(this.descA3);
            this.panelA3.Controls.Add(this.labelA3);
            this.panelA3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelA3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelA3.Location = new System.Drawing.Point(3, 155);
            this.panelA3.Name = "panelA3";
            this.panelA3.Size = new System.Drawing.Size(171, 70);
            this.panelA3.TabIndex = 17;
            this.panelA3.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descA3
            // 
            this.descA3.AutoSize = true;
            this.descA3.Location = new System.Drawing.Point(4, 28);
            this.descA3.MaximumSize = new System.Drawing.Size(168, 0);
            this.descA3.Name = "descA3";
            this.descA3.Size = new System.Drawing.Size(146, 15);
            this.descA3.TabIndex = 1;
            this.descA3.Text = "Фонд % с продаж для ОП";
            this.descA3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelA3
            // 
            this.labelA3.AutoSize = true;
            this.labelA3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelA3.Location = new System.Drawing.Point(4, 4);
            this.labelA3.Name = "labelA3";
            this.labelA3.Size = new System.Drawing.Size(70, 20);
            this.labelA3.TabIndex = 0;
            this.labelA3.Text = "Фонд A3";
            this.labelA3.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // panelA4
            // 
            this.panelA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelA4.Controls.Add(this.descA4);
            this.panelA4.Controls.Add(this.labelA4);
            this.panelA4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelA4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelA4.Location = new System.Drawing.Point(3, 231);
            this.panelA4.Name = "panelA4";
            this.panelA4.Size = new System.Drawing.Size(171, 70);
            this.panelA4.TabIndex = 18;
            this.panelA4.Click += new System.EventHandler(this.FundPanel_Click);
            // 
            // descA4
            // 
            this.descA4.AutoSize = true;
            this.descA4.Location = new System.Drawing.Point(4, 28);
            this.descA4.MaximumSize = new System.Drawing.Size(168, 0);
            this.descA4.Name = "descA4";
            this.descA4.Size = new System.Drawing.Size(151, 30);
            this.descA4.TabIndex = 1;
            this.descA4.Text = "Фонд внедрения 1С:ERP + ГОСТ РВ";
            this.descA4.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // labelA4
            // 
            this.labelA4.AutoSize = true;
            this.labelA4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelA4.Location = new System.Drawing.Point(4, 4);
            this.labelA4.Name = "labelA4";
            this.labelA4.Size = new System.Drawing.Size(71, 20);
            this.labelA4.TabIndex = 0;
            this.labelA4.Text = "Фонд A4";
            this.labelA4.Click += new System.EventHandler(this.FundLabel_Click);
            // 
            // AllFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 644);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "AllFunds";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все фонды";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelC3.ResumeLayout(false);
            this.panelC3.PerformLayout();
            this.panelC2.ResumeLayout(false);
            this.panelC2.PerformLayout();
            this.panelC1.ResumeLayout(false);
            this.panelC1.PerformLayout();
            this.panelB8.ResumeLayout(false);
            this.panelB8.PerformLayout();
            this.panelB7.ResumeLayout(false);
            this.panelB7.PerformLayout();
            this.panelB6.ResumeLayout(false);
            this.panelB6.PerformLayout();
            this.panelB5.ResumeLayout(false);
            this.panelB5.PerformLayout();
            this.panelB4.ResumeLayout(false);
            this.panelB4.PerformLayout();
            this.panelB3.ResumeLayout(false);
            this.panelB3.PerformLayout();
            this.panelB2.ResumeLayout(false);
            this.panelB2.PerformLayout();
            this.panelB1.ResumeLayout(false);
            this.panelB1.PerformLayout();
            this.panelA1.ResumeLayout(false);
            this.panelA1.PerformLayout();
            this.panelA2.ResumeLayout(false);
            this.panelA2.PerformLayout();
            this.panelA3.ResumeLayout(false);
            this.panelA3.PerformLayout();
            this.panelA4.ResumeLayout(false);
            this.panelA4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FundPanel panelC3;
        private FundLabel descC3;
        private FundLabel labelC3;
        private FundPanel panelC2;
        private FundLabel descC2;
        private FundLabel labelC2;
        private FundPanel panelC1;
        private FundLabel descC1;
        private FundLabel labelC1;
        private FundPanel panelB8;
        private FundLabel descB8;
        private FundLabel labelB8;
        private FundPanel panelB7;
        private FundLabel descB7;
        private FundLabel labelB7;
        private FundPanel panelB6;
        private FundLabel descB6;
        private FundLabel labelB6;
        private FundPanel panelB5;
        private FundLabel descB5;
        private FundLabel labelB5;
        private FundPanel panelB4;
        private FundLabel descB4;
        private FundLabel labelB4;
        private FundPanel panelB3;
        private FundLabel descB3;
        private FundLabel labelB3;
        private FundPanel panelB2;
        private FundLabel descB2;
        private FundLabel labelB2;
        private FundPanel panelB1;
        private FundLabel descB1;
        private FundLabel labelB1;
        private FundPanel panelA4;
        private FundLabel descA4;
        private FundLabel labelA4;
        private FundPanel panelA3;
        private FundLabel descA3;
        private FundLabel labelA3;
        private FundPanel panelA2;
        private FundLabel descA2;
        private FundLabel labelA2;
        private FundPanel panelA1;
        private FundLabel descA1;
        private FundLabel labelA1;
    }
}