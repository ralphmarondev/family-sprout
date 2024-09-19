using FamilySprout.Core.Model;
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
                    "fam_id INTEGER," +
                    $"role INTEGER DEFAULT {Roles.HUSBAND}," +
                    "name TEXT," +
                    "hometown TEXT," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // new-family
        public static void CreateNewParent(ParentModel parent)
        {
            long id;
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    var query = "INSERT INTO parents (fam_id, role, name, hometown, created_by, date_created) " +
                        "VALUES(@fam_id, @role, @name, @hometown, @created_by, @date_created)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", parent.famId);
                        command.Parameters.AddWithValue("@role", parent.role);
                        command.Parameters.AddWithValue("@name", parent.name);
                        command.Parameters.AddWithValue("@hometown", parent.hometown);
                        command.Parameters.AddWithValue("@created_by", parent.createdBy);
                        command.Parameters.AddWithValue("@date_created", parent.dateCreated);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void UpdateParentDetails(ParentModel parent)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE parents SET name = @name, hometown = @hometown WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", parent.id);
                        command.Parameters.AddWithValue("@name", parent.name);
                        command.Parameters.AddWithValue("@hometown", parent.hometown);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteParentDetails(long _id)
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

        public static void UpdateParentCreatedBy(string _newUsername, string _oldUsername)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE parents SET created_by = @new_username WHERE created_by = @old_username;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@new_username", _newUsername);
                        command.Parameters.AddWithValue("@old_username", _oldUsername);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // family details
        public static ParentModel GetParentDetailsByFamilyId(long famId, int role)
        {
            ParentModel parent = new ParentModel();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, name, hometown FROM parents " +
                        "WHERE fam_id = @fam_id AND role = @role AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@famId", famId);
                        command.Parameters.AddWithValue("@role", role);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idOrdinal = reader.GetOrdinal("id");
                                int nameOrdinal = reader.GetOrdinal("name");
                                int hometownOrdinal = reader.GetOrdinal("hometown");

                                parent.id = reader.GetInt64(idOrdinal);
                                parent.name = reader.GetString(nameOrdinal);
                                parent.hometown = reader.GetString(hometownOrdinal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return parent;
        }
    }
}
