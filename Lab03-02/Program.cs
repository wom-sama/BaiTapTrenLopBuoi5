using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // mot chut tuy chinh de co the chay doc lap cac form (chuong trinh se khong tat khi dong form dau tien)
            Form1 myForm = new Form1();
            myForm.Show();
            myForm.FormClosed += new FormClosedEventHandler(OnFormClosed);
            Application.Run();
        }
        public static void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread(); // thoát hẳn app khi không còn form nào
            }
        }
    }
}