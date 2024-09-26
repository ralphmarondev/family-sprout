using System;
using System.IO;
using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard.DB
{
    public static class DBDashboard
    {
        public static void BackUpDatabase()
        {
            try
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string sourcePath = Path.Combine(exeDirectory, "familysprout.db");

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
                string backupFileName = $"familysprout-{timestamp}.db";

                string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string destinationPath = Path.Combine(desktopDirectory, backupFileName);

                File.Copy(sourcePath, destinationPath, true);
                MessageBox.Show($"Database backup created successfully at {destinationPath}", "Backup Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the database backup: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int GetTotalFamilyCount()
        {
            return 0;
        }

        public static int GetTotalParentCount()
        {
            return 0;
        }

        public static int GetTotalChildCount()
        {
            return 0;
        }

        public static int GetTotalUserCount()
        {
            return 0;
        }
    }
}
