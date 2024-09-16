using FamilySprout.Core.Utils;
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
                    "is_deleted BOOLEAN DEFAULT 0);";

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

                    var query = "INSERT INTO parents (name, hometown, created_by, create_date) VALUES(@name, @hometown, @created_by, @create_date)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", _name);
                        command.Parameters.AddWithValue("@hometown", _from);
                        command.Parameters.AddWithValue("@created_by", SessionManager.CurrentUser.username);
                        command.Parameters.AddWithValue("@create_date", DateUtils.GetCreateDate());

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

        public static void UpdateParentInformation(
            long _famId,
            string _husband,
            string _husbandFrom,
            string _wife,
            string _wifeFrom,
            string _remarks)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string getParentIdQuery = "SELECT husband, wife FROM families " +
                        "WHERE id = @fam_id AND is_deleted = 0";

                    long husbandId = 0, wifeId = 0;

                    using (var getParentCommand = new SQLiteCommand(getParentIdQuery, connection))
                    {
                        getParentCommand.Parameters.AddWithValue("@fam_id", _famId);

                        using (var reader = getParentCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                husbandId = reader.GetInt64(reader.GetOrdinal("husband"));
                                wifeId = reader.GetInt64(reader.GetOrdinal("wife"));
                            }
                        }
                    }

                    string updateHusbandQuery = "UPDATE parents SET name = @name," +
                        "hometown = @hometown WHERE id = @id";

                    using (var updateHusbandCommand = new SQLiteCommand(updateHusbandQuery, connection))
                    {
                        updateHusbandCommand.Parameters.AddWithValue("@name", _husband);
                        updateHusbandCommand.Parameters.AddWithValue("@hometown", _husbandFrom);
                        updateHusbandCommand.Parameters.AddWithValue("@id", husbandId);

                        updateHusbandCommand.ExecuteNonQuery();
                    }

                    string updateWifeQuery = "UPDATE parents SET name = @name," +
                        "hometown = @hometown WHERE id = @id";

                    using (var updateHusbandCommand = new SQLiteCommand(updateWifeQuery, connection))
                    {
                        updateHusbandCommand.Parameters.AddWithValue("@name", _wife);
                        updateHusbandCommand.Parameters.AddWithValue("@hometown", _wifeFrom);
                        updateHusbandCommand.Parameters.AddWithValue("@id", wifeId);

                        updateHusbandCommand.ExecuteNonQuery();
                    }

                    string query = "UPDATE families SET remarks = @remarks WHERE id = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@remarks", _remarks);
                        command.Parameters.AddWithValue("@id", _famId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteParentInformation(
            long _id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE parents SET " +
                        "is_deleted = 1" +
                        "WHERE id = @id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", _id);

                        command.ExecuteNonQuery();
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
