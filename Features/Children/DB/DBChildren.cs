using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FamilySprout.Features.Children.DB
{
    public static class DBChildren
    {
        public static void CreateNewChild(ChildModel child)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    var query = "INSERT INTO children (" +
                        "fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, date_created) " +
                        "VALUES(@fam_id, @name, @bday, @baptism, @hc, @obitus, @matrimony, @created_by, @date_created);";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", child.famId);
                        command.Parameters.AddWithValue("@name", child.name);
                        command.Parameters.AddWithValue("@bday", child.bday);
                        command.Parameters.AddWithValue("@baptism", child.baptism);
                        command.Parameters.AddWithValue("@hc", child.hc);
                        command.Parameters.AddWithValue("@obitus", child.obitus);
                        command.Parameters.AddWithValue("@matrimony", child.matrimony);
                        command.Parameters.AddWithValue("@created_by", child.createdBy);
                        command.Parameters.AddWithValue("@date_created", child.dateCreated);

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Creating new child, {child.name} failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<ChildModel> GetAllChildren(long famId)
        {
            List<ChildModel> children = new List<ChildModel>();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT id, name, bday, baptism, hc, matrimony, obitus, created_by, date_created " +
                           "FROM children WHERE fam_id = @fam_id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChildModel child = new ChildModel();

                                child.famId = famId;
                                child.id = reader.GetInt64(reader.GetOrdinal("id"));
                                child.name = reader.GetString(reader.GetOrdinal("name"));
                                child.bday = reader.GetString(reader.GetOrdinal("bday"));
                                child.baptism = reader.GetString(reader.GetOrdinal("baptism"));
                                child.hc = reader.GetString(reader.GetOrdinal("hc"));
                                child.matrimony = reader.GetString(reader.GetOrdinal("matrimony"));
                                child.obitus = reader.GetString(reader.GetOrdinal("obitus"));
                                child.createdBy = reader.GetString(reader.GetOrdinal("created_by"));
                                child.dateCreated = reader.GetString(reader.GetOrdinal("date_created"));

                                children.Add(child);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [GetAllChildren]: {ex.Message}");
                }
            }

            return children;
        }
    }
}
