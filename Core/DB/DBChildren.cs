using System;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    internal static class DBChildren
    {
        private static void InitializeChildrenTable()
        {
            Console.WriteLine("Initializing childrens table...");

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {

                    connection.Open();

                    string query = "CREATE TABLE IF NOT EXISTS childrens (" +
                        "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "fam_id INTEGER NOT NULL," +
                        "name TEXT NOT NULL," +
                        "bday TEXT NOT NULL, " +
                        "baptism TEXT," +
                        "hc TEXT," +
                        "matrimony TEXT," +
                        "obitus TEXT," +
                        "created_by TEXT," +
                        "create_date TEXT," +
                        "is_deleted BOOLEAN DEFAULT 0," +
                        "FOREIGN KEY (fam_id) REFERENCES families(id)" +
                        ");";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void UpdateChild(
            int _id,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _matrimony,
            string _obitus)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE childrens SET " +
                        "name = @name," +
                        "bday = @bday," +
                        "baptism = @baptism," +
                        "hc = @hc," +
                        "matrimony = @matrimony," +
                        "obitus = @obitus " +
                        "WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", _name);
                        command.Parameters.AddWithValue("@bday", _bday);
                        command.Parameters.AddWithValue("@baptism", _baptism);
                        command.Parameters.AddWithValue("@hc", _hc);
                        command.Parameters.AddWithValue("@obitus", _obitus);
                        command.Parameters.AddWithValue("@matrimony", _matrimony);
                        command.Parameters.AddWithValue("@id", _id);


                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteChild(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE childrens SET is_deleted = 1 WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
