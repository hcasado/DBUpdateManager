using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBUpdateManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!System.IO.File.Exists("DBUpdateManager.ini"))
            {
                using (var fs = System.IO.File.OpenWrite("DBUpdateManager.ini"))                
                {
                    fs.Close();
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
