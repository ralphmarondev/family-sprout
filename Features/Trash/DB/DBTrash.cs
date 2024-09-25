using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FamilySprout.Features.Trash.DB
{
    public static class DBTrash
    {
        #region FAMILIES
        public static List<FamilyModel> GetDeletedFamilies()
        {
            List<FamilyModel> families = new List<FamilyModel>();
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, husband, husband_name, wife, wife_name, hometown, remarks, child_count, created_by, date_created " +
                        "FROM families WHERE is_deleted = 1;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FamilyModel family = new FamilyModel();
                                family.id = reader.GetInt64(reader.GetOrdinal("id"));
                                family.husband = reader.GetInt64(reader.GetOrdinal("husband"));
                                family.wife = reader.GetInt64(reader.GetOrdinal("wife"));
                                family.husbandName = reader.GetString(reader.GetOrdinal("husband_name"));
                                family.wifeName = reader.GetString(reader.GetOrdinal("wife_name"));
                                family.hometown = reader.GetString(reader.GetOrdinal("hometown"));
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.createdBy = reader.GetString(reader.GetOrdinal("created_by"));
                                family.dateCreated = reader.GetString(reader.GetOrdinal("date_created"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                                family.isDeleted = true;

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
        #endregion


        #region CHILDREN
        public static List<ChildModel> GetDeletedChildren()
        {
            List<ChildModel> children = new List<ChildModel>();
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, date_created " +
                        "FROM children WHERE is_deleted = 1;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChildModel child = new ChildModel();

                                child.id = reader.GetInt64(reader.GetOrdinal("id"));
                                child.famId = reader.GetInt64(reader.GetOrdinal("fam_id"));
                                child.name = reader.GetString(reader.GetOrdinal("name"));
                                child.bday = reader.GetString(reader.GetOrdinal("bday"));
                                child.baptism = reader.GetString(reader.GetOrdinal("baptism"));
                                child.hc = reader.GetString(reader.GetOrdinal("hc"));
                                child.matrimony = reader.GetString(reader.GetOrdinal("matrimony"));
                                child.obitus = reader.GetString(reader.GetOrdinal("obitus"));
                                child.createdBy = reader.GetString(reader.GetOrdinal("created_by"));
                                child.dateCreated = reader.GetString(reader.GetOrdinal("date_created"));
                                child.isDeleted = true;

                                children.Add(child);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return children;
        }
        #endregion CHILDREN


        #region USER
        public static List<UserModel> GetDeletedUsers()
        {
            List<UserModel> users = new List<UserModel>();
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, full_name, username, password, created_by, date_created, role " +
                        "FROM users WHERE is_deleted = 1;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserModel user = new UserModel();

                                user.id = reader.GetInt64(reader.GetOrdinal("id"));
                                user.fullName = reader.GetString(reader.GetOrdinal("full_name"));
                                user.username = reader.GetString(reader.GetOrdinal("username"));
                                user.password = reader.GetString(reader.GetOrdinal("password"));
                                user.createdBy = reader.GetString(reader.GetOrdinal("created_by"));
                                user.dateCreated = reader.GetString(reader.GetOrdinal("date_created"));
                                user.role = reader.GetInt32(reader.GetOrdinal("role"));
                                user.isDeleted = true;

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return users;
        }
        #endregion USER
    }
}
