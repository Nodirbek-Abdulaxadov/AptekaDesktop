using AptekaDesktop.Formalar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop
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

            FileInfo file = new FileInfo("login.txt");

            if (file.Exists)
            {
                StreamReader reader = new StreamReader("login.txt");
                string text = reader.ReadToEnd();
                if (text != "")
                {
                    reader.Close();
                    Application.Run(new Form1());
                }
            }
            else
            {
                Application.Run(new Login());
            }
        }
    }
}
