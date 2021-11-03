
namespace UILayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TotalSum = new System.Windows.Forms.TextBox();
            this.AddBankrollToDb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ServiceRevenue = new System.Windows.Forms.TextBox();
            this.GoodsRevenue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FundPercent = new System.Windows.Forms.TextBox();
            this.FundName = new System.Windows.Forms.TextBox();
            this.FundCode = new System.Windows.Forms.TextBox();
            this.AddFundToDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Форма распределения средств ";
            // 
            // TotalSum
            // 
            this.TotalSum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TotalSum.Location = new System.Drawing.Point(190, 62);
            this.TotalSum.Name = "TotalSum";
            this.TotalSum.Size = new System.Drawing.Size(324, 27);
            this.TotalSum.TabIndex = 1;
            // 
            // AddBankrollToDb
            // 
            this.AddBankrollToDb.Location = new System.Drawing.Point(583, 65);
            this.AddBankrollToDb.Name = "AddBankrollToDb";
            this.AddBankrollToDb.Size = new System.Drawing.Size(182, 62);
            this.AddBankrollToDb.TabIndex = 2;
            this.AddBankrollToDb.Text = "Добавить в БД";
            this.AddBankrollToDb.UseVisualStyleBackColor = true;
            this.AddBankrollToDb.Click += new System.EventHandler(this.AddBankrollToDb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Всего выручки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выручка за услуги";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Выручка за товары";
            // 
            // ServiceRevenue
            // 
            this.ServiceRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceRevenue.Location = new System.Drawing.Point(190, 96);
            this.ServiceRevenue.Name = "ServiceRevenue";
            this.ServiceRevenue.Size = new System.Drawing.Size(324, 27);
            this.ServiceRevenue.TabIndex = 6;
            // 
            // GoodsRevenue
            // 
            this.GoodsRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoodsRevenue.Location = new System.Drawing.Point(190, 133);
            this.GoodsRevenue.Name = "GoodsRevenue";
            this.GoodsRevenue.Size = new System.Drawing.Size(324, 27);
            this.GoodsRevenue.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Добавить фонд";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Код фонда";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Название фонда";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Процент от распределения";
            // 
            // FundPercent
            // 
            this.FundPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FundPercent.Location = new System.Drawing.Point(219, 316);
            this.FundPercent.Name = "FundPercent";
            this.FundPercent.Size = new System.Drawing.Size(324, 27);
            this.FundPercent.TabIndex = 12;
            // 
            // FundName
            // 
            this.FundName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FundName.Location = new System.Drawing.Point(219, 281);
            this.FundName.Name = "FundName";
            this.FundName.Size = new System.Drawing.Size(324, 27);
            this.FundName.TabIndex = 13;
            // 
            // FundCode
            // 
            this.FundCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FundCode.Location = new System.Drawing.Point(219, 242);
            this.FundCode.Name = "FundCode";
            this.FundCode.Size = new System.Drawing.Size(324, 27);
            this.FundCode.TabIndex = 14;
            // 
            // AddFundToDb
            // 
            this.AddFundToDb.Location = new System.Drawing.Point(583, 260);
            this.AddFundToDb.Name = "AddFundToDb";
            this.AddFundToDb.Size = new System.Drawing.Size(182, 62);
            this.AddFundToDb.TabIndex = 15;
            this.AddFundToDb.Text = "Добавить в БД";
            this.AddFundToDb.UseVisualStyleBackColor = true;
            this.AddFundToDb.Click += new System.EventHandler(this.AddFundToDb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 383);
            this.Controls.Add(this.AddFundToDb);
            this.Controls.Add(this.FundCode);
            this.Controls.Add(this.FundName);
            this.Controls.Add(this.FundPercent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GoodsRevenue);
            this.Controls.Add(this.ServiceRevenue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddBankrollToDb);
            this.Controls.Add(this.TotalSum);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TotalSum;
        private System.Windows.Forms.Button AddBankrollToDb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ServiceRevenue;
        private System.Windows.Forms.TextBox GoodsRevenue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox FundPercent;
        private System.Windows.Forms.TextBox FundName;
        private System.Windows.Forms.TextBox FundCode;
        private System.Windows.Forms.Button AddFundToDb;
    }
}

