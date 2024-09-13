using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyList.Forms;
using FamilySprout.Shared.Model;
using System;
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
                    "husband INTEGER," +
                    "wife INTEGER," +
                    "child_count INTEGER DEFAULT 0," +
                    "remarks TEXT," +
                    "created_by TEXT," +
                    "create_date TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static long CreateNewFamily(
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
                    long husbandId, wifeId;

                    husbandId = DBParents.CreateNewParent(
                        _name: _husband,
                        _from: _husbandFrom);

                    wifeId = DBParents.CreateNewParent(
                        _name: _wife,
                        _from: _wifeFrom);


                    var query = "INSERT INTO families (" +
                        "husband, wife, remarks, created_by, create_date) " +
                        "VALUES (@husband, @wife, @remarks, @created_by, @create_date);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband", husbandId);
                        command.Parameters.AddWithValue("@wife", wifeId);
                        command.Parameters.AddWithValue("@remarks", _remarks);
                        command.Parameters.AddWithValue("@created_by", Defaults.ADMIN);
                        command.Parameters.AddWithValue("@create_date", DateUtils.GetCreateDate());

                        command.ExecuteNonQuery();
                    }

                    long familyId;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                    {
                        familyId = (long)cmd.ExecuteScalar();
                    }
                    Console.WriteLine($"Retrieved family id: {familyId}");
                    return familyId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return -1;
        }

        public static FamilyData GetFamilyDetails(long _famId)
        {
            FamilyData familyData = new FamilyData();

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
                                familyData.id = reader.GetInt64(reader.GetOrdinal("FamilyId"));
                                familyData.husband = reader["Husband"] != DBNull.Value ? reader["Husband"].ToString() : string.Empty;
                                familyData.husbandFrom = reader["HusbandFrom"] != DBNull.Value ? reader["HusbandFrom"].ToString() : string.Empty;
                                familyData.wife = reader["Wife"] != DBNull.Value ? reader["Wife"].ToString() : string.Empty;
                                familyData.wifeFrom = reader["WifeFrom"] != DBNull.Value ? reader["WifeFrom"].ToString() : string.Empty;
                                familyData.remarks = reader["remarks"] != DBNull.Value ? reader["remarks"].ToString() : string.Empty;
                                familyData.createdBy = reader["created_by"] != DBNull.Value ? reader["created_by"].ToString() : string.Empty;
                                familyData.createDate = reader["create_date"] != DBNull.Value ? reader["create_date"].ToString() : string.Empty;
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

                                familyData.childrens.Add(child);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return familyData;
        }
    }
}
