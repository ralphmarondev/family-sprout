using FamilySprout.Core.DB;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList
{
    public partial class FamilyListMainForm : Form
    {
        public FamilyListMainForm()
        {
            InitializeComponent();
        }

        private void FamilyListMainForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadFamilyData();
        }

        private void SetupDataGridView()
        {
            // Create columns for the DataGridView
            dataGridViewFamilies.Columns.Add("FamilyId", "Family ID");
            dataGridViewFamilies.Columns["FamilyId"].Visible = false;
            dataGridViewFamilies.Columns.Add("HusbandName", "Husband");
            dataGridViewFamilies.Columns.Add("WifeName", "Wife");
            dataGridViewFamilies.Columns.Add("ChildCount", "Child Count");

            // Create an action column with buttons
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.Text = "Action";
            actionColumn.UseColumnTextForButtonValue = true;
            dataGridViewFamilies.Columns.Add(actionColumn);

            // Set properties
            dataGridViewFamilies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFamilies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFamilies.AllowUserToAddRows = false;
            dataGridViewFamilies.AllowUserToDeleteRows = false;
            dataGridViewFamilies.ReadOnly = true;
            dataGridViewFamilies.Margin = new Padding(0);
            dataGridViewFamilies.Padding = new Padding(0);

            // Set font size for cells
            dataGridViewFamilies.DefaultCellStyle.Font = new Font("Courier New", 16);

            // Set font size for headers (optional)
            dataGridViewFamilies.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 16, FontStyle.Bold);

            // Set padding for cells (adjusting row height indirectly)
            dataGridViewFamilies.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5); // Top, Left, Bottom, Right

            // Set padding around action buttons
            foreach (DataGridViewColumn column in dataGridViewFamilies.Columns)
            {
                if (column is DataGridViewButtonColumn)
                {
                    column.DefaultCellStyle.Padding = new Padding(5); // Adjust the padding around the button
                }
            }

            dataGridViewFamilies.RowTemplate.Height = 60; // Increase height as needed
            dataGridViewFamilies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFamilies.CellClick += dataGridViewFamilies_CellContentClick;
        }

        private void LoadFamilyData()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    // Query to get family data and child count
                    string query = @"
                        SELECT 
                            f.id AS FamilyId, 
                            h.name AS HusbandName,
                            w.name AS WifeName,
                            (SELECT COUNT(*) FROM children WHERE fam_id = f.id AND is_deleted = 0) AS ChildCount
                        FROM families f
                        LEFT JOIN parents h ON f.husband = h.id
                        LEFT JOIN parents w ON f.wife = w.id
                        WHERE f.is_deleted = 0;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long familyId = reader.GetInt64(0);
                                string husbandName = reader.GetString(1);
                                string wifeName = reader.GetString(2);
                                int childCount = reader.GetInt32(3);

                                // Add a row to the DataGridView
                                dataGridViewFamilies.Rows.Add(familyId, husbandName, wifeName, childCount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridViewFamilies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the click is in a valid row and the action column
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewFamilies.Columns["Action"].Index)
            {
                string famId = dataGridViewFamilies.Rows[e.RowIndex].Cells["FamilyId"].Value.ToString();
                string husband = dataGridViewFamilies.Rows[e.RowIndex].Cells["HusbandName"].Value.ToString();
                string wife = dataGridViewFamilies.Rows[e.RowIndex].Cells["WifeName"].Value.ToString();

                Console.WriteLine($"Family ID: {famId},Husband: {husband}, wife: {wife}");

                MainForm mainForm = this.ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamilyDetailsForm(_famId: Convert.ToInt64(famId));
                }
            }
        }
    }
}
