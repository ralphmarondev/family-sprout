using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.DB
{
    public static class DBNewFamily
    {
        #region SAVE_NEW_FAMILY
        public static long SaveNewFamily(FamilyModel family, ParentModel husband, ParentModel wife)
        {
            // save new family [blank husband id and wife id]
            // get id
            // save husband
            // get id
            // save wife
            // get id
            // update new family inserting id from wife and husband

            using (var connection = new SQLiteConnection(DBConfig.connectionString))
            {
                connection.Open();

                try
                {
                    family.id = SaveFamily(family, connection);
                    husband.famId = family.id;
                    wife.famId = family.id;

                    husband.id = SaveParents(husband, connection);
                    wife.id = SaveParents(wife, connection);

                    UpdateFamilyHusbandWifeId(famId: family.id, husbandId: husband.id, wifeId: wife.id, connection: connection);

                    MessageBox.Show("Saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return family.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error [SaveNewFamily]: {ex.Message}");
                    MessageBox.Show($"Failed Creating New Family.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private static long SaveFamily(FamilyModel family, SQLiteConnection connection)
        {
            string query = "INSERT INTO families(" +
                "husband_name, wife_name, hometown, remarks, created_by, date_created) VALUES(" +
                "@husband_name, @wife_name, @hometown, @remarks, @created_by, @date_created);";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@husband_name", family.husbandName);
                command.Parameters.AddWithValue("@wife_name", family.wifeName);
                command.Parameters.AddWithValue("@hometown", family.hometown);
                command.Parameters.AddWithValue("@remarks", family.remarks);
                command.Parameters.AddWithValue("@created_by", family.createdBy);
                command.Parameters.AddWithValue("@date_created", family.dateCreated);

                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand("SELECT last_insert_rowid()", connection))
            {
                family.id = (long)command.ExecuteScalar();
            }
            return family.id;
        }

        private static long SaveParents(ParentModel parent, SQLiteConnection connection)
        {
            string query = "INSERT INTO parents(" +
                "fam_id, name, contact_number, bday, birth_place, baptism, hc, matrimony, obitus, role, created_by, date_created) VALUES(" +
                "@fam_id, @name, @contact_number, @bday, @birth_place, @baptism, @hc, @matrimony, @obitus, @role, @created_by, @date_created);";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fam_id", parent.famId);
                command.Parameters.AddWithValue("@name", parent.name);
                command.Parameters.AddWithValue("@contact_number", parent.contactNumber);
                command.Parameters.AddWithValue("@bday", parent.bday);
                command.Parameters.AddWithValue("@birth_place", parent.birthPlace);
                command.Parameters.AddWithValue("@baptism", parent.baptism);
                command.Parameters.AddWithValue("@hc", parent.hc);
                command.Parameters.AddWithValue("@matrimony", parent.matrimony);
                command.Parameters.AddWithValue("@obitus", parent.obitus);
                command.Parameters.AddWithValue("@role", parent.role);
                command.Parameters.AddWithValue("@created_by", parent.createdBy);
                command.Parameters.AddWithValue("@date_created", parent.dateCreated);

                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand("SELECT last_insert_rowid()", connection))
            {
                parent.id = (long)command.ExecuteScalar();
            }
            return parent.id;
        }

        private static void UpdateFamilyHusbandWifeId(long famId, long husbandId, long wifeId, SQLiteConnection connection)
        {
            string query = "UPDATE families SET " +
                "husband = @husband," +
                "wife = @wife " +
                "WHERE id = @id AND is_deleted = 0;";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@husband", husbandId);
                command.Parameters.AddWithValue("@wife", wifeId);
                command.Parameters.AddWithValue("@id", famId);

                command.ExecuteNonQuery();
            }
        }
        #endregion SAVE_NEW_FAMILY
    }
}
