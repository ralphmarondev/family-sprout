using FamilySprout.Core.Model;
using System;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    internal static class DBFamily
    {
        private static void InitializeFamiliesTable()
        {
            try
            {
                Console.WriteLine("Initializing family table...");

                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string createFamiliesTableQuery = "CREATE TABLE IF NOT EXISTS " +
                        "families (" +
                        "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "husband TEXT NOT NULL, " +
                        "husbandFrom TEXT NOT NULL," +
                        "wife TEXT NOT NULL, " +
                        "wifeFrom TEXT NOT NULL, " +
                        "remarks TEXT NOT NULL, " +
                        "createdBy TEXT NOT NULL, " +
                        "createDate TEXT NOT NULL, " +
                        "is_deleted BOOLEAN DEFAULT 0);";

                    using (var command = new SQLiteCommand(createFamiliesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string createChildrenTableQuery = @"
                CREATE TABLE IF NOT EXISTS childrens (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    famId INTEGER NOT NULL,
                    name TEXT NOT NULL,
                    bday TEXT NOT NULL,
                    hc TEXT NOT NULL,
                    FOREIGN KEY (famId) REFERENCES families(id)
                );";

                    using (var command = new SQLiteCommand(createChildrenTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Families table initialized successfully.");
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

                Console.WriteLine("Creating new family...");
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();
                    //// Begin a transaction to ensure both family and children are inserted atomically
                    //using (var transaction = connection.BeginTransaction())
                    //{
                    string insertNewEmployeeQuery = "INSERT INTO families (husband, husbandFrom, wife, wifeFrom, remarks, createdBy, createDate) " +
                    "VALUES (@husband, @husbandFrom, @wife, @wifeFrom, @remarks, @createdBy, @createDate);";
                    using (var command = new SQLiteCommand(insertNewEmployeeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@husband", family.husband);
                        command.Parameters.AddWithValue("@husbandFrom", family.husbandFrom);
                        command.Parameters.AddWithValue("@wife", family.wife);
                        command.Parameters.AddWithValue("@wifeFrom", family.wifeFrom);
                        command.Parameters.AddWithValue("@remarks", family.remarks);
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
                        string insertNewChildQuery = "INSERT INTO childrens (famId, name, bday, hc) " +
                            "VALUES (@famId, @name, @bday, @hc);";
                        using (var command = new SQLiteCommand(insertNewChildQuery, connection))
                        {
                            command.Parameters.AddWithValue("@famId", familyId);
                            command.Parameters.AddWithValue("@name", child.name);
                            command.Parameters.AddWithValue("@bday", child.bday);
                            command.Parameters.AddWithValue("@hc", child.hc);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                //}

                //// Commit the transaction
                //transaction.Commit();
                Console.WriteLine("Family created successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
