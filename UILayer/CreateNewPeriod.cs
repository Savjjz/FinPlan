using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer.DbBlock;
using BusinessLogicLayer.BankrollDistribution;

namespace Supervisor
{
	public partial class CreateNewPeriod : Form
	{
		public delegate void UpdateHandler();
		public event UpdateHandler PeriodCreated;
		private bool isWeekNumberSettable = false;

		private DateTime lastDate; //Последний день учтенных отчетных периодов. Поле необходимо для проверки наложения дат нового и старых отчетных периодов.
		public CreateNewPeriod()
		{
			DataProvider provider = new DataProvider();
			var lastWeek = provider.FindLastWeekInDb();
			int periodNum = 0;
			// ПОДТЯНУТЬ periodNum, lastDate и defaultStartDate ИЗ БД !!!

			 //Автоматически присвоенный номер отчетного периода (из бд)
			DateTime defaultStartDate = lastWeek.End.AddDays(1); //Автоматически предложенная дата начала отчетного периода. По дефолту должна быть как дата закрытия прошлого периода плюс один день. (из бд)
			DateTime defaultEndDate = defaultStartDate.AddDays(6); //Автоматически предложенная дата окончания отчетного периода.
			lastDate = lastWeek.End; //Подтянуть из бд последний день последнего отчетного периода для проверки на наложение дат

			InitializeComponent(); //Все же оказалось что стоит ему дать сработать как надо

			if (lastWeek.Number != 0)
			{
				periodNum = lastWeek.Number + 1;
			}
			else
			{
				isWeekNumberSettable = true;
				periodNumTextBox.ReadOnly = false;
				periodNumTextBox.TabStop = true;
				periodNumTextBox.TabIndex = 0;
			}

			//Обновление данных после инициализации
			periodNumTextBox.Text = periodNum.ToString();
			if (lastWeek.Number != 0)
            {
				endDatePicker.Value = defaultEndDate;
				startDatePicker.Value = defaultStartDate;
				DateChanged(defaultStartDate, defaultEndDate);
            }
            else
            {
				DateChanged(startDatePicker.Value, endDatePicker.Value);
			}

			calendar.BoldedDates = new DateTime[] {DateTime.Now};	
		}
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			DateTime startDate = startDatePicker.Value;
			DateTime endDate = endDatePicker.Value;
			if (startDate > endDate) //Проверка валидности дат
			{
				MessageBox.Show("Дата начала отчетного периода не может быть позже даты окончания", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
				endDate = startDate;
				endDatePicker.Value = endDate;
			}
			DateChanged(startDate, endDate);

		}
		private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			DateTime startDate = startDatePicker.Value;
			DateTime endDate = endDatePicker.Value;
			if (startDate > endDate) //Проверка валидности дат
			{
				MessageBox.Show("Дата окончания отчетного периода не может быть раньше даты начала", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
				startDate = endDate;
				startDatePicker.Value = startDate;
			}
			DateChanged(startDate, endDate);
		}

		private void DateChanged(DateTime startDate, DateTime endDate) 
		{ 
			//Метод обновления даты на форме
			int periodLength = endDate.Subtract(startDate).Days + 1;
			periodLengthTextBox.Text = periodLength.ToString();
			calendar.MaxSelectionCount = periodLength;
			calendar.SelectionStart = startDate;
			calendar.SelectionEnd = endDate;
		}
		
		private void openPeriodButton_Click(object sender, EventArgs e)                //Отправка данных в БД
		{
			DateTime startDate = startDatePicker.Value; //Дата начала отчетного периода
			DateTime endDate = endDatePicker.Value; //Дата окончания отчетного периода
			int WeekNum;
			if (Int32.TryParse(periodNumTextBox.Text, out WeekNum))
            {
				if (lastDate.Date > startDate.Date)
				{
					MessageBox.Show($"Дата начала нового отчетного периода не может быть раньше даты завершения предыдущего периода.\nДата завершения предыдущего периода: " + lastDate.ToShortDateString(), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					DataAdder adder = new DataAdder();
					if (isWeekNumberSettable)
					{
						Week week = new Week(startDate, endDate, WeekNum);
						adder.SetNewWeekData(week);
					}
					else
					{
						Week week = new Week(startDate, endDate);
						adder.SetNewWeekData(week);
					}
					this.Close();
					MessageBox.Show("Период успешно создан");
					PeriodCreated();
				}
			}
            else
            {
				MessageBox.Show("Проверьте правильность ввода данных");
			}
			
		}

        private void CreateNewPeriod_Load(object sender, EventArgs e)
        {

        }
    }
}
