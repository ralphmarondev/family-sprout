﻿using FamilySprout.Core.Utils;
using FamilySprout.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FamilySprout.Core.DB
{
    public static class DBChildren
    {
        public static void InitializeChildrenTable()
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                string query = "CREATE TABLE IF NOT EXISTS children(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "fam_id INTEGER," +
                    "name TEXT," +
                    "bday TEXT," +
                    "baptism TEXT," +
                    "hc TEXT," +
                    "obitus TEXT," +
                    "matrimony TEXT," +
                    "created_by TEXT," +
                    "create_date TEXT," +
                    "is_deleted BOOLEAN DEFAULT 0);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CreateNewChild(
           long _famId,
           string _name,
           string _bday,
           string _baptism,
           string _hc,
           string _obitus,
           string _matrimony)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    var query = "INSERT INTO children (" +
                        "fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, create_date) " +
                        "VALUES(@fam_id, @name, @bday, @baptism, @hc, @obitus, @matrimony, @created_by, @create_date);";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", _famId);
                        command.Parameters.AddWithValue("@name", _name);
                        command.Parameters.AddWithValue("@bday", _bday);
                        command.Parameters.AddWithValue("@baptism", _baptism);
                        command.Parameters.AddWithValue("@hc", _hc);
                        command.Parameters.AddWithValue("@obitus", _obitus);
                        command.Parameters.AddWithValue("@matrimony", _matrimony);
                        command.Parameters.AddWithValue("@created_by", Defaults.ADMIN);
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

        // this function is used in adding new children
        public static List<ChildModel> GetChildrenByFamilyId(long famId)
        {
            List<ChildModel> children = new List<ChildModel>();

            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, fam_id, name, bday, baptism, hc, obitus, matrimony, created_by, create_date " +
                        "FROM children " +
                        "WHERE fam_id = @fam_id AND is_deleted = 0";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var child = new ChildModel(
                                    _id: reader.GetInt64(0),
                                    _famId: reader.GetInt64(1),
                                    _name: reader.GetString(2),
                                    _bday: reader.GetString(3),
                                    _baptism: reader.GetString(4),
                                    _hc: reader.GetString(5),
                                    _obitus: reader.GetString(6),
                                    _matrimony: reader.GetString(7),
                                    _createdBy: reader.GetString(8),
                                    _createDate: reader.GetString(9)
                                    );

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

        public static void UpdateChild(
            long _id,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _obitus,
            string _matrimony)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE children SET " +
                        "name = @name," +
                        "bday = @bday," +
                        "baptism = @baptism," +
                        "hc = @hc," +
                        "obitus = @obitus," +
                        "matrimony = @matrimony " +
                        "WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", _name);
                        command.Parameters.AddWithValue("@bday", _bday);
                        command.Parameters.AddWithValue("@baptism", _baptism);
                        command.Parameters.AddWithValue("@hc", _hc);
                        command.Parameters.AddWithValue("@obitus", _obitus);
                        command.Parameters.AddWithValue("@matrimony", _matrimony);
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

        public static void DeleteChild(long _id)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE children SET is_deleted = 1 WHERE id = @id;";
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