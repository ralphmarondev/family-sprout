using System;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    public static class DBParents
    {
        public static void InitializeParentsTable()
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS parents(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "hometown TEXT," +
                    "created_by TEXT," +
                    "create_date TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0," +
                    "FOREIGN KEY(fam_id) REFERENCES families(id));";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static long CreateNewParent(
            string _name,
            string _from)
        {
            long id;
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    var query = "INSERT INTO parents (name, hometown) VALUES(@name, @hometown)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", _name);
                        command.Parameters.AddWithValue("@hometown", _from);

                        command.ExecuteNonQuery();

                        using (var retrieveId = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                        {
                            id = (long)retrieveId.ExecuteScalar();
                        }
                        Console.WriteLine($"Retrieved ID: {id}");
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return -1;
        }
    }
}
