using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout
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

            DBConfig.InitializeDatabase();

            Application.Run(new Features.Auth.AuthenticationForm());
        }
    }
}
