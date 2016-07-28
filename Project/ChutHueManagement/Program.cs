using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChutHueManagement.ChutHueManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChutHueManagement.FormPrimary());

            //FormConnection connection = new FormConnection();
            //if (connection.ShowDialog() == DialogResult.OK)
            //    Application.Run(new FormPrimary(connection.account));
        }
    }
}
