using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
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
                InitializeUsersTable();
                InitializeFamiliesTable();
                InitializeParentsTable();
                InitializeChildrenTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        #region INITIALIZING_TABLES
        private static void InitializeUsersTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS users(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "full_name TEXT," +
                    "username TEXT," +
                    "password TEXT," +
                    $"role INTEGER DEFAULT {Constants.User.USER}," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    $"is_deleted BOOLEAN DEFAULT {Constants.FALSE});";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string checkIfEmptyQuery = "SELECT COUNT(*) FROM users;";
                using (var checkCommand = new SQLiteCommand(checkIfEmptyQuery, connection))
                {
                    long userCount = (long)checkCommand.ExecuteScalar();

                    if (userCount == 0)
                    {
                        UserModel user = new UserModel();
                        user.fullName = "I am root";
                        user.username = "root";
                        user.password = "toor";
                        user.role = Constants.User.SUPERUSER;

                        //CreateNewUser(user);
                    }
                }
            }
        }

        private static void InitializeFamiliesTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS families(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "husband INTEGER," +
                    "husband_name TEXT," +
                    "wife INTEGER," +
                    "wife_name TEXT," +
                    "hometown TEXT," +
                    "remarks TEXT," +
                    $"child_count INTEGER DEFAULT {Constants.ZERO}," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    $"is_deleted BOOLEAN DEFAULT {Constants.FALSE});";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void InitializeParentsTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS parents(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "fam_id INTEGER," +
                    "name TEXT," +
                    "contact_number TEXT," +
                    "bday TEXT," +
                    "birth_place TEXT," +
                    "baptism TEXT," +
                    "hc TEXT," +
                    "matrimony TEXT," +
                    "obitus TEXT," +
                    $"role INTEGER DEFAULT {Constants.Parent.HUSBAND}," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    $"is_deleted BOOLEAN DEFAULT {Constants.FALSE});";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void InitializeChildrenTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS children(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "fam_id INTEGER," +
                    "name TEXT," +
                    "bday TEXT," +
                    "baptism TEXT," +
                    "hc TEXT," +
                    "obitus TEXT," +
                    "matrimony TEXT," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    $"is_deleted BOOLEAN DEFAULT {Constants.FALSE});";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion INITIALIZING_TABLES
    }
}
