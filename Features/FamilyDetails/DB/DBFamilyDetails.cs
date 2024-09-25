using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Data.SQLite;

namespace FamilySprout.Features.FamilyDetails.DB
{
    public static class DBFamilyDetails
    {
        /// <summary>
        /// Used in getting family information. Called as the [FamilyDetailsMainForm] is loaded.
        /// </summary>
        /// <param name="famId"></param>
        /// <returns></returns>
        public static FamilyModel GetFamilyDetails(long id)
        {
            FamilyModel family = new FamilyModel();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT husband, husband_name, wife, wife_name, hometown, remarks, child_count " +
                        "FROM families WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                family.id = id;
                                family.husband = reader.GetInt64(reader.GetOrdinal("husband"));
                                family.husbandName = reader.GetString(reader.GetOrdinal("husband_name"));
                                family.wife = reader.GetInt64(reader.GetOrdinal("wife"));
                                family.wifeName = reader.GetString(reader.GetOrdinal("wife_name"));
                                family.hometown = reader.GetString(reader.GetOrdinal("hometown"));
                                family.remarks = reader.GetString(reader.GetOrdinal("remarks"));
                                family.childCount = reader.GetInt32(reader.GetOrdinal("child_count"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return family;
        }

        /// <summary>
        /// Used in getting parents information. Called as the [FamilyDetailsMainForm] is loaded.
        /// This is called twice, first time is for husband, and second time is for wife.
        /// </summary>
        /// <param name="famId"></param>
        /// <returns></returns>
        public static ParentModel GetParentDetails(long famId, long id)
        {
            ParentModel parent = new ParentModel();

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "SELECT name, contact_number, bday, birth_place, baptism, hc, matrimony, obitus, role " +
                        "FROM parents WHERE fam_id = @fam_id AND id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fam_id", famId);
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                parent.id = id;
                                parent.famId = famId;
                                parent.name = reader.GetString(reader.GetOrdinal("name"));
                                parent.contactNumber = reader.GetString(reader.GetOrdinal("contact_number"));
                                parent.bday = reader.GetString(reader.GetOrdinal("bday"));
                                parent.birthPlace = reader.GetString(reader.GetOrdinal("birth_place"));
                                parent.baptism = reader.GetString(reader.GetOrdinal("baptism"));
                                parent.hc = reader.GetString(reader.GetOrdinal("hc"));
                                parent.matrimony = reader.GetString(reader.GetOrdinal("matrimony"));
                                parent.obitus = reader.GetString(reader.GetOrdinal("obitus"));
                                parent.role = reader.GetInt32(reader.GetOrdinal("role"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return parent;
        }

        /// <summary>
        /// Used in update remarks and hometown of a family.
        /// </summary>
        /// <param name="family"></param>
        /// <returns>
        /// This returns [false] by default. Meaning operation is not successful.
        /// It returns [true] if the operation is successful.
        /// </returns>
        public static bool UpdateFamilyDetails(FamilyModel family)
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "UPDATE families SET " +
                        "remarks = @remarks," +
                        "hometown = @hometown " +
                        "WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", family.id);
                        command.Parameters.AddWithValue("@remarks", family.remarks);
                        command.Parameters.AddWithValue("@hometown", family.hometown);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return false;
        }

        /// <summary>
        /// Used in updating parents information.
        /// </summary>
        /// <param name="parent"></param>
        ///  /// <returns>
        /// This returns [false] by default. Meaning operation is not successful.
        /// It returns [true] if the operation is successful.
        /// </returns>
        public static bool UpdateParentDetails(ParentModel parent)
        {
            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    string query = "UPDATE parents SET " +
                        "name = @name," +
                        "contact_number = @contact_number," +
                        "bday = @bday," +
                        "birth_place = @birth_place," +
                        "baptism = @baptism," +
                        "hc = @hc," +
                        "matrimony = @matrimony, " +
                        "obitus = @obitus " +
                        "WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", parent.name);
                        command.Parameters.AddWithValue("@contact_number", parent.contactNumber);
                        command.Parameters.AddWithValue("@bday", parent.bday);
                        command.Parameters.AddWithValue("@birth_place", parent.birthPlace);
                        command.Parameters.AddWithValue("@baptism", parent.baptism);
                        command.Parameters.AddWithValue("@hc", parent.hc);
                        command.Parameters.AddWithValue("@matrimony", parent.matrimony);
                        command.Parameters.AddWithValue("@obitus", parent.obitus);
                        command.Parameters.AddWithValue("@id", parent.id);

                        command.ExecuteNonQuery();
                    }

                    // update family husband/wife name column
                    if (parent.role == Constants.Parent.HUSBAND)
                    {
                        query = "UPDATE families SET " +
                            "husband_name = @husband_name " +
                            "WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@husband_name", parent.name);
                            command.Parameters.AddWithValue("@id", parent.famId);

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (parent.role == Constants.Parent.WIFE)
                    {
                        query = "UPDATE families SET " +
                            "wife_name = @wife_name " +
                            "WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@wife_name", parent.name);
                            command.Parameters.AddWithValue("@id", parent.famId);

                            command.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return false;
        }


        #region DELETE_FAMILY
        /// <summary>
        /// Used in deleting parents information.
        /// We are not totally deleting it, we are only assigning the flag [is_deleted] to true.
        /// </summary>
        /// <param name="famId"></param> 
        /// <returns>
        /// This returns [false] by default. Meaning operation is not successful.
        /// It returns [true] if the operation is successful.
        /// </returns>
        public static bool DeleteFamilyDetails(long famId)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();


                    string query = "UPDATE families SET is_deleted = 1 WHERE id = @id AND is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", famId);

                        command.ExecuteNonQuery();
                    }
                    DeleteParentDetailsByFamId(famId, connection);
                    DeleteChildDetailsByFamId(famId, connection);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }
        private static void DeleteParentDetailsByFamId(long famId, SQLiteConnection connection)
        {
            string query = "UPDATE parents SET is_deleted = 1 WHERE fam_id = @fam_id AND is_deleted = 0;";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fam_id", famId);

                command.ExecuteNonQuery();
            }
        }
        private static void DeleteChildDetailsByFamId(long famId, SQLiteConnection connection)
        {
            string query = "UPDATE children SET is_deleted = 1 WHERE fam_id = @fam_id AND is_deleted = 0;";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fam_id", famId);

                command.ExecuteNonQuery();
            }
        }
        #endregion DELETE_FAMILY
    }
}
