using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

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

        public static bool RestoreFamily(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE families SET is_deleted = 0 WHERE id = @id AND is_deleted = 1;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }

                    // restore parents too
                    query = "UPDATE parents SET is_deleted = 0 WHERE fam_id = @fam_id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        command.ExecuteNonQuery();
                    }

                    // restore children too
                    query = "UPDATE children SET is_deleted = 0 WHERE fam_id = @fam_id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        command.ExecuteNonQuery();
                    }

                    // get child_count
                    long child_count = 0;
                    query = "SELECT COUNT(*) FROM children WHERE fam_id = @fam_id AND is_deleted = 0";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        child_count = (long)command.ExecuteScalar();
                    }

                    // update family column [child_count]
                    query = "UPDATE families SET child_count = @child_count WHERE id = @id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@child_count", child_count);
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }

        public static bool PermanentlyDeleteFamily(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM families WHERE id = @id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }

                    // delete parents related to the family too
                    query = "DELETE FROM parents WHERE fam_id = @fam_id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        command.ExecuteNonQuery();
                    }

                    // delete its children too
                    query = "DELETE FROM children WHERE fam_id = @fam_id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
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

        public static bool RestoreChild(long id, long famId)
        {
            // if fam_id is deleted : don't allow restoring
            // else restore and increment child_count of the family
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT is_deleted FROM families WHERE id = @id;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        int isDeleted = Convert.ToInt32(command.ExecuteScalar());

                        if (isDeleted == 1)
                        {
                            MessageBox.Show("You need to restore the child's family first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    // restore child
                    query = "UPDATE children SET is_deleted = 0 WHERE id = @id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }

                    // increment family [child_count]
                    query = "UPDATE families SET child_count = child_count + 1 WHERE id = @id AND is_deleted = 0;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }

        public static bool PermanentlyDeleteChild(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM children WHERE id = @id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
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

        public static bool RestoreUser(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE users SET is_deleted = 0 WHERE id = @id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }

        public static bool PermanentlyDeleteUser(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM users WHERE id = @id AND is_deleted = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }
        #endregion USER
    }
}
