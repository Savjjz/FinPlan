using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supervisor;

namespace UILayer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{
            Application.Run(new Loading());
            //}
            //catch(Exception e)
            //{
            //    //File.AppendAllText("C:\\Users\\Вадим\\Desktop\\ErrorLog.txt", "\n ================================\n" + DateTime.Now.ToString() + "\n" + e.Message + "\n\n" + e + "\n");
            //    MessageBox.Show($"Программа неожиданно завершила свою работу\nИнформация об ошибке сохранена\nПожалуйста, уведомите разработчика", "Возникла ошибка в работе программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
