using System;
namespace Supervisor
{
    partial class CreateNewPeriod
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.openPeriodButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.periodLengthTextBox = new System.Windows.Forms.TextBox();
            this.periodLengthLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePickerLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePickerLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.periodNumTextBox = new System.Windows.Forms.TextBox();
            this.periodNumLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.formHeader = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 202);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.openPeriodButton);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(3, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 146);
            this.panel3.TabIndex = 2;
            // 
            // openPeriodButton
            // 
            this.openPeriodButton.Location = new System.Drawing.Point(3, 119);
            this.openPeriodButton.Name = "openPeriodButton";
            this.openPeriodButton.Size = new System.Drawing.Size(321, 23);
            this.openPeriodButton.TabIndex = 4;
            this.openPeriodButton.Text = "Открыть отчетный период";
            this.openPeriodButton.UseVisualStyleBackColor = true;
            this.openPeriodButton.Click += new System.EventHandler(this.openPeriodButton_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.periodLengthTextBox);
            this.panel7.Controls.Add(this.periodLengthLabel);
            this.panel7.Location = new System.Drawing.Point(3, 90);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(321, 23);
            this.panel7.TabIndex = 2;
            // 
            // periodLengthTextBox
            // 
            this.periodLengthTextBox.Location = new System.Drawing.Point(171, 0);
            this.periodLengthTextBox.Name = "periodLengthTextBox";
            this.periodLengthTextBox.ReadOnly = true;
            this.periodLengthTextBox.Size = new System.Drawing.Size(150, 23);
            this.periodLengthTextBox.TabIndex = 0;
            this.periodLengthTextBox.TabStop = false;
            this.periodLengthTextBox.Text = "7";
            // 
            // periodLengthLabel
            // 
            this.periodLengthLabel.AutoSize = true;
            this.periodLengthLabel.Location = new System.Drawing.Point(3, 3);
            this.periodLengthLabel.Name = "periodLengthLabel";
            this.periodLengthLabel.Size = new System.Drawing.Size(149, 15);
            this.periodLengthLabel.TabIndex = 0;
            this.periodLengthLabel.Text = "Дней в отчетном периоде";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.endDatePicker);
            this.panel6.Controls.Add(this.endDatePickerLabel);
            this.panel6.Location = new System.Drawing.Point(3, 61);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(321, 23);
            this.panel6.TabIndex = 2;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(171, 0);
            this.endDatePicker.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.endDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(150, 23);
            this.endDatePicker.TabIndex = 3;
            this.endDatePicker.Value = new System.DateTime(2020, 1, 7, 0, 0, 0, 0);
            this.endDatePicker.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // endDatePickerLabel
            // 
            this.endDatePickerLabel.AutoSize = true;
            this.endDatePickerLabel.Location = new System.Drawing.Point(3, 3);
            this.endDatePickerLabel.Name = "endDatePickerLabel";
            this.endDatePickerLabel.Size = new System.Drawing.Size(144, 15);
            this.endDatePickerLabel.TabIndex = 0;
            this.endDatePickerLabel.Text = "Дата окончания периода";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.startDatePicker);
            this.panel5.Controls.Add(this.startDatePickerLabel);
            this.panel5.Location = new System.Drawing.Point(3, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 23);
            this.panel5.TabIndex = 2;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(171, 0);
            this.startDatePicker.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.startDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(150, 23);
            this.startDatePicker.TabIndex = 2;
            this.startDatePicker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // startDatePickerLabel
            // 
            this.startDatePickerLabel.AutoSize = true;
            this.startDatePickerLabel.Location = new System.Drawing.Point(3, 3);
            this.startDatePickerLabel.Name = "startDatePickerLabel";
            this.startDatePickerLabel.Size = new System.Drawing.Size(123, 15);
            this.startDatePickerLabel.TabIndex = 0;
            this.startDatePickerLabel.Text = "Дата начала периода";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.periodNumTextBox);
            this.panel4.Controls.Add(this.periodNumLabel);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 23);
            this.panel4.TabIndex = 0;
            // 
            // periodNumTextBox
            // 
            this.periodNumTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.periodNumTextBox.Location = new System.Drawing.Point(171, 0);
            this.periodNumTextBox.MaxLength = 3;
            this.periodNumTextBox.Name = "periodNumTextBox";
            this.periodNumTextBox.ReadOnly = true;
            this.periodNumTextBox.ShortcutsEnabled = false;
            this.periodNumTextBox.Size = new System.Drawing.Size(150, 23);
            this.periodNumTextBox.TabIndex = 1;
            this.periodNumTextBox.TabStop = false;
            this.periodNumTextBox.Text = "0";
            // 
            // periodNumLabel
            // 
            this.periodNumLabel.AutoSize = true;
            this.periodNumLabel.Location = new System.Drawing.Point(3, 3);
            this.periodNumLabel.Name = "periodNumLabel";
            this.periodNumLabel.Size = new System.Drawing.Size(87, 15);
            this.periodNumLabel.TabIndex = 0;
            this.periodNumLabel.Text = "Номер недели";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.formHeader);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 41);
            this.panel2.TabIndex = 1;
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formHeader.Location = new System.Drawing.Point(3, 5);
            this.formHeader.Margin = new System.Windows.Forms.Padding(3);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(321, 28);
            this.formHeader.TabIndex = 0;
            this.formHeader.Text = "Открыть новый отчетный период";
            // 
            // calendar
            // 
            this.calendar.AllowDrop = true;
            this.calendar.BackColor = System.Drawing.SystemColors.Control;
            this.calendar.BoldedDates = new System.DateTime[] {
        new System.DateTime(2021, 9, 15, 17, 38, 27, 0)};
            this.calendar.Enabled = false;
            this.calendar.Location = new System.Drawing.Point(7, 19);
            this.calendar.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.calendar.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.calendar.Name = "calendar";
            this.calendar.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2021, 9, 16, 0, 0, 0, 0), new System.DateTime(2021, 9, 22, 0, 0, 0, 0));
            this.calendar.ShowTodayCircle = false;
            this.calendar.TabIndex = 0;
            this.calendar.TabStop = false;
            this.calendar.TitleBackColor = System.Drawing.Color.Gray;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.calendar);
            this.panel8.Location = new System.Drawing.Point(350, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(180, 202);
            this.panel8.TabIndex = 1;
            // 
            // CreateNewPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(542, 224);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(558, 263);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(558, 263);
            this.Name = "CreateNewPeriod";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Новый отчетный период";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateNewPeriod_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox periodNumTextBox;
        private System.Windows.Forms.Label periodNumLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label endDatePickerLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label startDatePickerLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label periodLengthLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button openPeriodButton;
        private System.Windows.Forms.TextBox periodLengthTextBox;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Panel panel8;
    }
}