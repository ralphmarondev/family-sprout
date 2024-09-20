using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Data.SQLite;

namespace FamilySprout.Features.Auth.DB
{
    public static class DBAuth
    {
        public static bool IsUserExists(string username, string password)
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND is_deleted = 0";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        long count = (long)command.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: ${ex.Message}");
                }
            }
            return false;
        }

        public static UserModel GetUserDetailByUsername(string username)
        {
            UserModel user = new UserModel();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT id, full_name, username, password, role, created_by, date_created " +
                        "FROM users WHERE username = @username";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

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
                                user.dateCreated = reader.GetString(reader.GetOrdinal("date_created"));
                            }
                            Console.WriteLine($"Retrieved data: user.id: {user.id}, user.fullname: {user.fullName}, user.createdBy: {user.createdBy}, user.dateCreated: {user.dateCreated}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return user;
        }
    }
}
