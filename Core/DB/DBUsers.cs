using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    public static class DBUsers
    {
        public static void InitializeUsersTable()
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS users(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "full_name TEXT," +
                    "username TEXT," +
                    "password TEXT," +
                    "role INTEGER DEFAULT 1," +
                    "created_by TEXT," +
                    "create_date TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string checkIfEmptyQuery = "SELECT COUNT(*) FROM users;";
                using (var checkCommand = new SQLiteCommand(checkIfEmptyQuery, connection))
                {
                    long userCount = (long)checkCommand.ExecuteScalar();

                    if (userCount == 0)
                    {
                        string insertRootUserQuery = @"
                INSERT INTO users (full_name, username, password, role, created_by, create_date) 
                VALUES (@full_name, @username, @password, @role, @created_by, @create_date);";

                        using (var insertCommand = new SQLiteCommand(insertRootUserQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@full_name", "I am root");
                            insertCommand.Parameters.AddWithValue("@username", "root");
                            insertCommand.Parameters.AddWithValue("@password", "toor");
                            insertCommand.Parameters.AddWithValue("@role", 0);
                            insertCommand.Parameters.AddWithValue("@created_by", "System");
                            insertCommand.Parameters.AddWithValue("@create_date", DateUtils.GetCreateDate());

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void CreateNewUser(UserModel user)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO users (full_name, username, password, role, created_by, create_date) " +
                        "VALUES (@full_name, @username, @password, @role, @created_by, @create_date);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@full_name", user.fullName);
                        command.Parameters.AddWithValue("@username", user.username);
                        command.Parameters.AddWithValue("@password", user.password);
                        command.Parameters.AddWithValue("@role", user.role);
                        command.Parameters.AddWithValue("@created_by", SessionManager.CurrentUser.username);
                        command.Parameters.AddWithValue("@create_date", DateUtils.GetCreateDate());

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static UserModel GetUserDetailsByUsername(string _username)
        {
            UserModel user = new UserModel();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, full_name, username, password, role, created_by, create_date " +
                        "FROM users WHERE username = @username AND is_deleted = 0;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", _username);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user.id = reader.GetInt64(reader.GetOrdinal("id"));
                                user.fullName = reader.GetString(reader.GetOrdinal("full_name"));
                                user.username = reader.GetString(reader.GetOrdinal("username"));
                                user.password = reader.GetString(reader.GetOrdinal("password"));
                                user.role = reader.GetInt32(reader.GetOrdinal("role"));
                                user.createdBy = reader.GetString(reader.GetOrdinal("created_by"));
                                user.createDate = reader.GetString(reader.GetOrdinal("create_date"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return user;
        }

        public static bool IsUserExists(
            string _username,
            string _password)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", _username);
                        command.Parameters.AddWithValue("@password", _password);

                        long userCount = (long)command.ExecuteScalar();
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }

        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, full_name, username, password, created_by, create_date, role " +
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
                                user.createDate = reader.GetString(reader.GetOrdinal("create_date"));
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

        public static void UpdateUser(UserModel user)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE users SET " +
                        "full_name = @full_name, username = @username, password = @password, role = @role " +
                        "WHERE username = @username AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@full_name", user.fullName);
                        command.Parameters.AddWithValue("@username", user.username);
                        command.Parameters.AddWithValue("@password", user.password);
                        command.Parameters.AddWithValue("@role", user.role);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteUser(long _id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE users SET is_deleted = 1 WHERE id = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", _id);

                        command.ExecuteNonQuery();
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
