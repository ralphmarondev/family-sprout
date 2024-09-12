using System;
using System.Data.SQLite;
using System.IO;

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
                DBFamily.InitializeFamiliesTable();
                DBParents.InitializeParentsTable();
                DBChildren.InitializeChildrenTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
