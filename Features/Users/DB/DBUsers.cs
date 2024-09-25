using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.DB
{
    public static class DBUsers
    {
        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, full_name, username, password, created_by, date_created, role " +
                        "FROM users WHERE is_deleted = 0;";

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

        public static bool CreateNewUser(UserModel user)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", user.username);

                        long count = (long)command.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username is already taken.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    query = "INSERT INTO users (full_name, username, password, role, created_by, date_created) " +
                        "VALUES (@full_name, @username, @password, @role, @created_by, @date_created);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@full_name", user.fullName);
                        command.Parameters.AddWithValue("@username", user.username);
                        command.Parameters.AddWithValue("@password", user.password);
                        command.Parameters.AddWithValue("@role", user.role);
                        command.Parameters.AddWithValue("@created_by", user.createdBy);
                        command.Parameters.AddWithValue("@date_created", user.dateCreated);

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
    }
}
