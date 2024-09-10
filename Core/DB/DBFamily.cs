using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FamilySprout.Core.DB
{
    internal static class DBFamily
    {
        private static void InitializeFamiliesTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string createFamiliesTableQuery = "CREATE TABLE IF NOT EXISTS " +
                        "families (" +
                        "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "husband TEXT NOT NULL, " +
                        "husband_from TEXT NOT NULL," +
                        "wife TEXT NOT NULL, " +
                        "wife_from TEXT NOT NULL, " +
                        "remarks TEXT NOT NULL, " +
                        "child_count INTEGER NOT NULL, " +
                        "created_by TEXT NOT NULL, " +
                        "create_date TEXT NOT NULL, " +
                        "is_deleted BOOLEAN DEFAULT 0);";

                    Console.WriteLine("Initializing families table...");
                    using (var command = new SQLiteCommand(createFamiliesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("families table initialized successfuly!");

                    Console.WriteLine("Initializing childrens table...");
                    string createChildrenTableQuery = "CREATE TABLE IF NOT EXISTS childrens (" +
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

                    using (var command = new SQLiteCommand(createChildrenTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Childrens table initialized successfully.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void CreateNewFamily(FamilyModel family)
        {
            try
            {
                InitializeFamiliesTable();

                Console.WriteLine($"CreateDate: {family.createDate}, CreatedBy: {family.createdBy}");

                Console.WriteLine("Creating new family...");
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string insertNewEmployeeQuery = "INSERT INTO families (" +
                        "husband, husband_from, wife, wife_from, remarks, child_count, created_by, create_date) " +
                    "VALUES (@husband, @husbandFrom, @wife, @wifeFrom, @remarks, @childCount, @createdBy, @createDate);";
                    using (var command = new SQLiteCommand(insertNewEmployeeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@husband", family.husband);
                        command.Parameters.AddWithValue("@husbandFrom", family.husbandFrom);
                        command.Parameters.AddWithValue("@wife", family.wife);
                        command.Parameters.AddWithValue("@wifeFrom", family.wifeFrom);
                        command.Parameters.AddWithValue("@remarks", family.remarks);
                        command.Parameters.AddWithValue("@childCount", family.childCount);
                        command.Parameters.AddWithValue("@createdBy", family.createdBy);
                        command.Parameters.AddWithValue("@createDate", family.createDate);

                        command.ExecuteNonQuery();
                    }
                    // Retrieve the last inserted id to use as famId for children
                    long familyId;
                    using (var command = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                    {
                        familyId = (long)command.ExecuteScalar();
                    }

                    // Insert children records associated with the family
                    foreach (var child in family.childrens)
                    {
                        string insertNewChildQuery = "INSERT INTO childrens (fam_id, name, bday, baptism, hc, matrimony, obitus, created_by, create_date) " +
                            "VALUES (@famId, @name, @bday, @baptism, @hc, @matrimony, @obitus, @createdBy, @createDate);";
                        using (var command = new SQLiteCommand(insertNewChildQuery, connection))
                        {
                            command.Parameters.AddWithValue("@famId", familyId);
                            command.Parameters.AddWithValue("@name", child.name);
                            command.Parameters.AddWithValue("@bday", child.bday);
                            command.Parameters.AddWithValue("@baptism", child.baptism);
                            command.Parameters.AddWithValue("@hc", child.hc);
                            command.Parameters.AddWithValue("@matrimony", child.matrimony);
                            command.Parameters.AddWithValue("@obitus", child.obitus);
                            command.Parameters.AddWithValue("@createdBy", child.createdBy);
                            command.Parameters.AddWithValue("@createDate", child.createDate);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Family created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        public static int GetFamilyIdByHusbandAndWife(string husband, string wife)
        {
            int familyId = -1;

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id FROM families WHERE husband = @husband AND wife = @wife";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband", husband);
                        command.Parameters.AddWithValue("@wife", wife);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                familyId = reader.GetInt32(0);
                            }
                            else
                            {
                                throw new InvalidOperationException("No matching family found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return familyId;
        }

        public static DataTable GetFamilyDetailsAndChildrenCount()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT f.husband, f.wife, COUNT(c.id) AS childrenCount
                        FROM families f
                        LEFT JOIN childrens c ON f.id = c.fam_id
                        GROUP BY f.husband, f.wife;
                    ";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return dataTable;
        }

        public static FamilyModel GetFamilyDetailsById(int _id)
        {
            FamilyModel family = null;
            var children = new List<Children>();
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string selectAllChildrensQuery = "SELECT * FROM childrens WHERE fam_id = @id AND is_deleted = 0";
                    using (var command = new SQLiteCommand(selectAllChildrensQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", _id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var child = new Children
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    famId = reader.GetInt32(reader.GetOrdinal("fam_id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    bday = reader.GetString(reader.GetOrdinal("bday")),
                                    baptism = reader.GetString(reader.GetOrdinal("baptism")),
                                    hc = reader.GetString(reader.GetOrdinal("hc")),
                                    matrimony = reader.GetString(reader.GetOrdinal("matrimony")),
                                    obitus = reader.GetString(reader.GetOrdinal("obitus")),
                                    createdBy = reader.GetString(reader.GetOrdinal("created_by")),
                                    createDate = reader.GetString(reader.GetOrdinal("create_date"))
                                };
                                children.Add(child);
                            }
                        }
                    }

                    string query = "SELECT * FROM families WHERE id = @id AND is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", _id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                family = new FamilyModel(
                                    _id: reader.GetInt32(0),
                                    _husband: reader.GetString(1),
                                    _husbandFrom: reader.GetString(2),
                                    _wife: reader.GetString(3),
                                    _wifeFrom: reader.GetString(4),
                                    _remarks: reader.GetString(5),
                                    _childCount: reader.GetInt32(6),
                                    _createdBy: reader.GetString(7),
                                    _createDate: reader.GetString(8),
                                    _childrens: children
                                    );
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

        public static void UpdateFamily(FamilyModel family)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET " +
                        "name = @name," +
                        "bday = @bday," +
                        "baptism = @baptism," +
                        "hc = @hc," +
                        "matrimony = @matrimony," +
                        "obitus = @obitus" +
                        "WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {



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

        public static void DeleteFamily(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET is_deleted = 1 WHERE id = @id";

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
