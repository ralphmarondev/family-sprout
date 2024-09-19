using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    public static class DBFamily
    {
        public static void InitializeFamiliesTable()
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS families(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "child_count INTEGER DEFAULT 0," +
                    "remarks TEXT," +
                    "created_by TEXT," +
                    "date_created TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static long CreateNewFamily(FamilyModel family)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO families (remarks, created_by, date_created) " +
                        "VALUES (@remarks, @created_by, @date_created);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@remarks", family.remarks);
                        command.Parameters.AddWithValue("@created_by", family.createdBy);
                        command.Parameters.AddWithValue("@date_created", family.dateCreated);

                        command.ExecuteNonQuery();
                    }

                    long famId;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                    {
                        famId = (long)cmd.ExecuteScalar();
                    }
                    Console.WriteLine($"Retrieved family id: {famId}");
                    return famId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return -1;
        }

        public static List<FamilyModel> GetAllFamilies()
        {
            List<FamilyModel> families = new List<FamilyModel>();

            return families;
        }

        public static void UpdateFamilyDetails(FamilyModel family)
        {

        }

        public static void DeleteFamilyDetails(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET is_deleted = 1 WHERE id = @id AND is_deleted = 0";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }
                }
                // TODO: Also delete parent details
                DBChildren.DeleteChildByFamId(famId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        #region TRASH
        public static void PermanentlyDeleteFamilyDetails(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = "DELETE FROM families WHERE id = @id AND is_deleted = 1";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", famId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Family with Id: {famId} permanently deleted.");
                            }
                            else
                            {
                                Console.WriteLine($"No family found with id: {famId} to delete.");
                            }
                        }
                        // TODO: ALSO PERMANENTLY DELETE PARENTS AND CHILDREN ASSOCIATED
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void RestoreFamilyDetails(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET is_deleted = 0 WHERE id = @id AND is_deleted = 1";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }
                }
                // TODO: ALSO RESTORE PARENTS DETAILS
                DBChildren.RestoreChildByFamId(famId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        /*
        public static List<FamilyModel> GetDeletedFamilies()
        {
            List<FamilyModel> families = new List<FamilyModel>();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string familyQuery = "SELECT f.id AS fam_id," +
                        "h.name AS husband," +
                        "h.hometown AS husband_from," +
                        "w.name AS wife," +
                        "w.hometown AS wife_from," +
                        "f.remarks," +
                        "f.created_by," +
                        "f.create_date " +
                        "FROM families f " +
                        "LEFT JOIN parents h ON f.husband = h.id " +
                        "LEFT JOIN parents w ON f.wife = w.id " +
                        "WHERE f.is_deleted = 1;";

                    using (var command = new SQLiteCommand(familyQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FamilyModel family = new FamilyModel();
                                family.id = reader.GetInt64(reader.GetOrdinal("fam_id"));
                                family.husband = reader["husband"] != DBNull.Value ? reader["husband"].ToString() : string.Empty;
                                family.husbandFrom = reader["husband_from"] != DBNull.Value ? reader["husband_from"].ToString() : string.Empty;
                                family.wife = reader["wife"] != DBNull.Value ? reader["wife"].ToString() : string.Empty;
                                family.wifeFrom = reader["wife_from"] != DBNull.Value ? reader["wife_from"].ToString() : string.Empty;
                                family.remarks = reader["remarks"] != DBNull.Value ? reader["remarks"].ToString() : string.Empty;
                                family.createdBy = reader["created_by"] != DBNull.Value ? reader["created_by"].ToString() : string.Empty;
                                family.createDate = reader["create_date"] != DBNull.Value ? reader["create_date"].ToString() : string.Empty;

                                string childrenQuery = "SELECT " +
                                    "id, fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, create_date " +
                                    "FROM children WHERE fam_id = @fam_id AND is_deleted = 0;";

                                using (var childCommand = new SQLiteCommand(childrenQuery, connection))
                                {
                                    childCommand.Parameters.AddWithValue("@fam_id", family.id);

                                    using (var childReader = childCommand.ExecuteReader())
                                    {
                                        while (childReader.Read())
                                        {
                                            var child = new ChildModel(
                                                 childReader.GetInt64(childReader.GetOrdinal("id")),
                                        childReader.GetInt64(childReader.GetOrdinal("fam_id")),
                                        childReader["name"] != DBNull.Value ? childReader["name"].ToString() : string.Empty,
                                        childReader["bday"] != DBNull.Value ? childReader["bday"].ToString() : string.Empty,
                                        childReader["baptism"] != DBNull.Value ? childReader["baptism"].ToString() : string.Empty,
                                        childReader["hc"] != DBNull.Value ? childReader["hc"].ToString() : string.Empty,
                                        childReader["obitus"] != DBNull.Value ? childReader["obitus"].ToString() : string.Empty,
                                        childReader["matrimony"] != DBNull.Value ? childReader["matrimony"].ToString() : string.Empty,
                                        childReader["created_by"] != DBNull.Value ? childReader["created_by"].ToString() : string.Empty,
                                        childReader["create_date"] != DBNull.Value ? childReader["create_date"].ToString() : string.Empty
                                                );
                                            family.children.Add(child);
                                        }
                                    }
                                }
                                families.Add(family);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return families;
        }
        */
        #endregion TRASH

        /*
        public static FamilyModel GetFamilyDetails(long _famId)
        {
            FamilyModel familyModel = new FamilyModel();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string familyQuery = "SELECT " +
                        "f.id AS familyId," +
                        "h.name AS Husband," +
                        "h.hometown AS HusbandFrom," +
                        "w.name AS Wife," +
                        "w.hometown AS WifeFrom," +
                        "f.remarks," +
                        "f.created_by," +
                        "f.create_date " +
                        "FROM families f " +
                        "LEFT JOIN parents h ON f.husband = h.id " +
                        "LEFT JOIN parents w ON f.wife = w.id " +
                        "WHERE f.id = @fam_id AND f.is_deleted = 0;";

                    using (var familyCommand = new SQLiteCommand(familyQuery, connection))
                    {
                        familyCommand.Parameters.AddWithValue("@fam_id", _famId);

                        using (var reader = familyCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                familyModel.id = reader.GetInt64(reader.GetOrdinal("FamilyId"));
                                familyModel.husband = reader["Husband"] != DBNull.Value ? reader["Husband"].ToString() : string.Empty;
                                familyModel.husbandFrom = reader["HusbandFrom"] != DBNull.Value ? reader["HusbandFrom"].ToString() : string.Empty;
                                familyModel.wife = reader["Wife"] != DBNull.Value ? reader["Wife"].ToString() : string.Empty;
                                familyModel.wifeFrom = reader["WifeFrom"] != DBNull.Value ? reader["WifeFrom"].ToString() : string.Empty;
                                familyModel.remarks = reader["remarks"] != DBNull.Value ? reader["remarks"].ToString() : string.Empty;
                                familyModel.createdBy = reader["created_by"] != DBNull.Value ? reader["created_by"].ToString() : string.Empty;
                                familyModel.createDate = reader["create_date"] != DBNull.Value ? reader["create_date"].ToString() : string.Empty;
                            }
                        }
                    }

                    string childrenQuery = "SELECT " +
                        "id, fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, create_date " +
                        "FROM children " +
                        "WHERE fam_id = @fam_id AND is_deleted = 0";

                    using (var childCommand = new SQLiteCommand(childrenQuery, connection))
                    {
                        childCommand.Parameters.AddWithValue("@fam_id", _famId);

                        using (var reader = childCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var child = new ChildModel(
                                    reader.GetInt64(reader.GetOrdinal("id")),  // id
                                    reader.GetInt64(reader.GetOrdinal("fam_id")),  // fam_id
                                    reader["name"] != DBNull.Value ? reader["name"].ToString() : string.Empty,
                                    reader["bday"] != DBNull.Value ? reader["bday"].ToString() : string.Empty,
                                    reader["baptism"] != DBNull.Value ? reader["baptism"].ToString() : string.Empty,
                                    reader["hc"] != DBNull.Value ? reader["hc"].ToString() : string.Empty,
                                    reader["obitus"] != DBNull.Value ? reader["obitus"].ToString() : string.Empty,
                                    reader["matrimony"] != DBNull.Value ? reader["matrimony"].ToString() : string.Empty,
                                    reader["created_by"] != DBNull.Value ? reader["created_by"].ToString() : string.Empty,
                                    reader["create_date"] != DBNull.Value ? reader["create_date"].ToString() : string.Empty
                                    );

                                familyModel.children.Add(child);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return familyModel;
        }
        */

        public static int GetTotalFamilyCount()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM families WHERE is_deleted = 0;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public static void UpdateFamilyCreatedBy(string _newUsername, string _oldUsername)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET created_by = @new_username WHERE created_by = @old_username;";
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


        #region FAMILY_LIST
        public static FamilyModel GetFamilyDetailsById(long id)
        {
            FamilyModel family = new FamilyModel();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, remarks FROM families " +
                        "WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idOrdinal = reader.GetOrdinal("id");
                                int remarksOrdinal = reader.GetOrdinal("remarks");

                                family.id = reader.GetInt64(idOrdinal);
                                family.remarks = reader.GetString(remarksOrdinal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return family;
        }
        // update parent dialog
        public static void UpdateRemarks(long id, string newRemark)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET remarks = @remarks WHERE id = @id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@remarks", newRemark);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion FAMILY_LIST
    }
}
