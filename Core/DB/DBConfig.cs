using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FamilySprout.Core.DB
{
    internal static class DBConfig
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        #region DELETE_EMPTY_TABLES
        public static void DeleteEmptyTables()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    var tables = GetTables(connection);

                    foreach (DataRow row in tables.Rows)
                    {
                        var table = row["name"].ToString();
                        if (IsTableEmpty(connection, table))
                        {
                            DeleteTable(connection, table);
                        }
                    }
                }
                Console.WriteLine("Empty tables deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deleting empty table error: {ex.Message}");
            }
        }

        private static bool IsTableEmpty(SQLiteConnection connection, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            using (var command = new SQLiteCommand(query, connection))
            {
                long count = (long)command.ExecuteScalar();

                return count == 0;
            }
        }

        private static DataTable GetTables(SQLiteConnection connection)
        {
            var tables = new DataTable();
            string query = $"SELECT name FROM sqlite_master WHERE type = 'table' AND " +
                $"name NOT LIKE 'sqlite_%';";

            using (var command = new SQLiteCommand(query, connection))
            {
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(tables);
                }
            }

            return tables;
        }

        private static void DeleteTable(SQLiteConnection connection, string tableName)
        {
            string query = $"DROP TABLE IF EXISTS {tableName}";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        #endregion DELETE_EMPTY_TABLES
    }
}