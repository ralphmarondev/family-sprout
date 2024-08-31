using FamilySprout.Core.DB;
using FamilySprout.Core.Helper;
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
            Utils.ReadFamilySproutConfig();

            Application.Run(new AuthScreen());
        }
    }
}
