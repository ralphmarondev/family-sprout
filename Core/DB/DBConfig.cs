using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FamilySprout.Core.DB
{
    public static class DBConfig
    {
        public static string connectionString = "Data Source=familysprout.db; Version=3;";

        public static void InitializeDatabase()
        {
            try
            {
                if (!File.Exists("familysprout.db"))
                {
                    SQLiteConnection.CreateFile("familysprout.db");
                }
                DBUsers.InitializeUsersTable();
                DBFamily.InitializeFamiliesTable();
                DBParents.InitializeParentsTable();
                DBChildren.InitializeChildrenTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ExportDatabase()
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
    }
}
