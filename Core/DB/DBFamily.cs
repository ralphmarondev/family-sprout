using FamilySprout.Core.Helper;
using FamilySprout.Core.Model;
using System;
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
                        "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "fam_id INTEGER NOT NULL, " +
                        "name TEXT NOT NULL," +
                        "bday TEXT NOT NULL, " +
                        "hc TEXT NOT NULL, " +
                        "matrimony TEXT, " +
                        "obitus TEXT, " +
                        "created_by TEXT, " +
                        "create_date TEXT, " +
                        "is_deleted BOOLEAN DEFAULT 0," +
                        "FOREIGN KEY (fam_id) REFERENCES families(id)" +
                        ");";

                    using (var command = new SQLiteCommand(createChildrenTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("childrens table initialized successfully.");
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

                string createDate = Utils.GetCurrentDate();
                string createdBy = Utils.GetAdmin();
                Console.WriteLine($"CreateDate: {createDate}, CreatedBy: {createdBy}");

                Console.WriteLine("Creating new family...");
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string insertNewEmployeeQuery = "INSERT INTO families (" +
                        "husband, husband_from, wife, wife_from, remarks, created_by, create_date) " +
                    "VALUES (@husband, @husbandFrom, @wife, @wifeFrom, @remarks, @createdBy, @createDate);";
                    using (var command = new SQLiteCommand(insertNewEmployeeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@husband", family.husband);
                        command.Parameters.AddWithValue("@husbandFrom", family.husbandFrom);
                        command.Parameters.AddWithValue("@wife", family.wife);
                        command.Parameters.AddWithValue("@wifeFrom", family.wifeFrom);
                        command.Parameters.AddWithValue("@remarks", family.remarks);
                        command.Parameters.AddWithValue("@createdBy", createdBy);
                        command.Parameters.AddWithValue("@createDate", createDate);

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
                        string insertNewChildQuery = "INSERT INTO childrens (fam_id, name, bday, hc, matrimony, obitus, created_by, create_date) " +
                            "VALUES (@famId, @name, @bday, @hc, @matrimony, @obitus, @createdBy, @createDate);";
                        using (var command = new SQLiteCommand(insertNewChildQuery, connection))
                        {
                            command.Parameters.AddWithValue("@famId", familyId);
                            command.Parameters.AddWithValue("@name", child.name);
                            command.Parameters.AddWithValue("@bday", child.bday);
                            command.Parameters.AddWithValue("@hc", child.hc);
                            command.Parameters.AddWithValue("@matrimony", child.matrimony);
                            command.Parameters.AddWithValue("@obitus", child.obitus);
                            command.Parameters.AddWithValue("@createdBy", createdBy);
                            command.Parameters.AddWithValue("@createDate", createDate);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Family created successfully.");
                MessageBox.Show("Family created successfully.");
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
                        // Adding parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@husband", husband);
                        command.Parameters.AddWithValue("@wife", wife);

                        // Execute the query and read the result
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Convert the result to an integer
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
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM families WHERE id = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", _id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                family = new FamilyModel(
                                    //id: reader.GetInt32(0),
                                    //name: reader.GetString(1),
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
    }
}
