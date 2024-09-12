using FamilySprout.Core.Utils;
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
    }
}
