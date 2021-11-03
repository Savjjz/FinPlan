
namespace Supervisor
{
    partial class FundForm
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.ExcelButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fundTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FundDescription = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FundName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 427);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ExcelButton);
            this.panel5.Location = new System.Drawing.Point(4, 391);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(724, 33);
            this.panel5.TabIndex = 4;
            // 
            // ExcelButton
            // 
            this.ExcelButton.Location = new System.Drawing.Point(605, 5);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(112, 23);
            this.ExcelButton.TabIndex = 1;
            this.ExcelButton.Text = "ДДС Фонда";
            this.ExcelButton.UseVisualStyleBackColor = true;
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.fundTable);
            this.panel4.Location = new System.Drawing.Point(4, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(724, 328);
            this.panel4.TabIndex = 3;
            // 
            // fundTable
            // 
            this.fundTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fundTable.AutoScroll = true;
            this.fundTable.AutoScrollMinSize = new System.Drawing.Size(715, 0);
            this.fundTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fundTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.fundTable.ColumnCount = 1;
            this.fundTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fundTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fundTable.Location = new System.Drawing.Point(3, 3);
            this.fundTable.MinimumSize = new System.Drawing.Size(715, 119);
            this.fundTable.Name = "fundTable";
            this.fundTable.RowCount = 1;
            this.fundTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fundTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fundTable.Size = new System.Drawing.Size(715, 320);
            this.fundTable.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.FundDescription);
            this.panel3.Location = new System.Drawing.Point(226, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9, 5, 5, 5);
            this.panel3.Size = new System.Drawing.Size(502, 45);
            this.panel3.TabIndex = 1;
            // 
            // FundDescription
            // 
            this.FundDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FundDescription.Location = new System.Drawing.Point(9, 5);
            this.FundDescription.Name = "FundDescription";
            this.FundDescription.Size = new System.Drawing.Size(486, 33);
            this.FundDescription.TabIndex = 0;
            this.FundDescription.Text = "Фонд корпоративных расходов";
            this.FundDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.FundName);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(216, 45);
            this.panel2.TabIndex = 0;
            // 
            // FundName
            // 
            this.FundName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FundName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FundName.Location = new System.Drawing.Point(5, 5);
            this.FundName.Margin = new System.Windows.Forms.Padding(5);
            this.FundName.Name = "FundName";
            this.FundName.Size = new System.Drawing.Size(204, 33);
            this.FundName.TabIndex = 0;
            this.FundName.Text = "Фонд С1";
            this.FundName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(756, 452);
            this.Controls.Add(this.panel1);
            this.Name = "FundForm";
            this.Text = "Fund";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel fundTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label FundDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label FundName;
        private System.Windows.Forms.Button ExcelButton;
    }
}