using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FamilySprout.Features.Families.DB
{
    public static class DBFamilyList
    {
        public static List<FamilyModel> GetAllFamilies()
        {
            List<FamilyModel> families = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, hometown, remarks, child_count " +
                        "FROM families WHERE is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FamilyModel family = new FamilyModel();

                                family.id = reader.GetInt64(reader.GetOrdinal("id"));
                                family.husband = reader.GetInt64(reader.GetOrdinal("husband"));
                                family.husbandName = reader.GetString(reader.GetOrdinal("husband_name"));
                                family.wife = reader.GetInt64(reader.GetOrdinal("wife"));
                                family.wifeName = reader.GetString(reader.GetOrdinal("wife_name"));
                                family.hometown = reader.GetString(reader.GetOrdinal("hometown"));
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));

                                families.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [GetAllFamilies]: {ex.Message}");
                }
            }

            return families;
        }
    }
}
