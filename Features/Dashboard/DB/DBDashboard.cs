using FamilySprout.Core.DB;
using System;
using System.Data.SQLite;
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

        public static long GetTotalFamilyCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM families WHERE is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        long count = (long)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
            }
            return 0;
        }

        public static long GetTotalParentCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM parents WHERE is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        long count = (long)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
            }
            return 0;
        }

        public static long GetTotalChildCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM children WHERE is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        long count = (long)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
            }
            return 0;
        }

        public static long GetTotalUserCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        long count = (long)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
            }
            return 0;
        }
    }
}
