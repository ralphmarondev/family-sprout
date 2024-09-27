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


        #region HUSBAND
        public static List<FamilyModel> UpdateDisplayedFamiliesByHusbandName(string searchHusbandName)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, hometown, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND husband_name LIKE @husband_name || '%';";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband_name", searchHusbandName);

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

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }

        public static List<FamilyModel> UpdateDisplayedFamiliesByHusbandNameAndHometown(string searchHusbandName, string hometown)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND hometown = @hometown AND husband_name LIKE @husband_name || '%';";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband_name", searchHusbandName);
                        command.Parameters.AddWithValue("@hometown", hometown);

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
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.hometown = hometown;

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }

        #endregion HUSBAND


        #region WIFE
        public static List<FamilyModel> UpdateDisplayedFamiliesByWifeName(string searchWifeName)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, hometown, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND wife_name LIKE @wife_name || '%';";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@wife_name", searchWifeName);

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

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }
        public static List<FamilyModel> UpdateDisplayedFamiliesByWifeNameAndHometown(string searchWifeName, string hometown)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND hometown = @hometown AND wife_name LIKE @wife_name || '%';";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@wife_name", searchWifeName);
                        command.Parameters.AddWithValue("@hometown", hometown);

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
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.hometown = hometown;

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }
        #endregion WIFE


        #region HOMETOWN
        public static List<FamilyModel> UpdateDisplayedFamiliesByHometown(string hometown)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, husband_name, wife, wife_name, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND hometown = @hometown;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@hometown", hometown);

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
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.hometown = hometown;

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }

        public static List<FamilyModel> UpdateDisplayedFamiliesByHomeTownAndHusbandAndWife(string hometown, string husband, string wife)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, wife, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND husband_name = @husband AND wife_name = @wife AND hometown = @hometown;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband", husband);
                        command.Parameters.AddWithValue("@wife", wife);
                        command.Parameters.AddWithValue("@hometown", hometown);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FamilyModel family = new FamilyModel();

                                family.id = reader.GetInt64(reader.GetOrdinal("id"));
                                family.husband = reader.GetInt64(reader.GetOrdinal("husband"));
                                family.wife = reader.GetInt64(reader.GetOrdinal("wife"));
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.husbandName = husband;
                                family.wifeName = wife;
                                family.hometown = hometown;

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }
        public static List<FamilyModel> UpdateDisplayedFamiliesByHusbandAndWife(string husband, string wife)
        {
            List<FamilyModel> filteredFamilies = new List<FamilyModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, husband, wife, hometown, remarks, child_count " +
                                   "FROM families WHERE is_deleted = 0 AND husband_name = @husband AND wife_name = @wife;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@husband", husband);
                        command.Parameters.AddWithValue("@wife", wife);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FamilyModel family = new FamilyModel();

                                family.id = reader.GetInt64(reader.GetOrdinal("id"));
                                family.husband = reader.GetInt64(reader.GetOrdinal("husband"));
                                family.wife = reader.GetInt64(reader.GetOrdinal("wife"));
                                family.hometown = reader.GetString(reader.GetOrdinal("hometown"));
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.husbandName = husband;
                                family.wifeName = wife;

                                filteredFamilies.Add(family);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [UpdateDisplayedFamilies]: {ex.Message}");
                }
            }
            return filteredFamilies;
        }
        #endregion HOMETOWN
    }
}
