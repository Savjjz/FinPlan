using BusinessLogicLayer.DbBlock;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace BusinessLogicLayer.ExcelBlock
{
    public abstract class TableBase
    {
        protected Excel.Application Application { get; set; }
        protected Excel.Workbooks Workbooks { get; set; }
        protected Excel.Workbook Workbook { get; set; }
        protected Excel.Sheets Worksheets { get; set; }
        protected Excel.Worksheet Worksheet { get; set; }
       
        
        /// <summary>
        /// Инициализация новой книги
        /// </summary>
        protected void InitializeWorkbook()
        {
            //Запускаем Excel
            Application = new Excel.Application();
            Application.Visible = true;
            //Создаем новую книгу
            Workbooks = Application.Workbooks;
            Workbook = Workbooks.Add();
            //Создаем новый лист
            Worksheets = Workbook.Worksheets;
            Worksheet = Worksheets.Item[1];
        }

        /// <summary>
        /// Создать текстовый шаблон таблицы
        /// </summary>
        protected abstract void SetTableTextSample();

        /// <summary>
        /// Создать шаблон стилей таблицы
        /// </summary>
        protected abstract void SetTableStyleSample();
    }
}
