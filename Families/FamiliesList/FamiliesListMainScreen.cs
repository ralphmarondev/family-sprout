using FamilySprout.Core.DB;
using FamilySprout.Core.Helper;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList
{
    public partial class FamiliesListMainScreen : Form
    {
        public FamiliesListMainScreen()
        {
            InitializeComponent();
        }

        private void FamiliesListMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();

            InitializeDataGridView();
            AddRowsFromDatabase();
        }


        #region FETCH_DATA
        private void FetchData()
        {

        }
        #endregion FETCH_DATA


        #region ON_LOAD
        private void InitializeDataGridView()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 40; // Adjust header height

            // Add columns
            dataGridView1.Columns.Add("Husband", "Husband");
            dataGridView1.Columns.Add("Wife", "Wife");
            dataGridView1.Columns.Add("Children", "Children");

            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.HeaderText = "Action";
            actionColumn.Text = "View Details";
            actionColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(actionColumn);

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        // TODO: Refactor this, database operations should be on core/db module
        private void AddRowsFromDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT f.husband, f.wife, COUNT(c.id) AS childrenCount
                FROM families f
                LEFT JOIN childrens c ON f.id = c.fam_id
                GROUP BY f.husband, f.wife;";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        // Clear existing rows
                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            string husband = reader["husband"].ToString();
                            string wife = reader["wife"].ToString();
                            int childrenCount = Convert.ToInt32(reader["childrenCount"]);

                            // Add row to DataGridView
                            dataGridView1.Rows.Add(husband, wife, childrenCount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Action" column
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                // Fetch data as needed and show a form
                MessageBox.Show("View Details clicked for " + dataGridView1.Rows[e.RowIndex].Cells["Husband"].Value);

                string husband = dataGridView1.Rows[e.RowIndex].Cells["Husband"].Value.ToString();
                string wife = dataGridView1.Rows[e.RowIndex].Cells["Wife"].Value.ToString();

                int famId = DBFamily.GetFamilyIdByHusbandAndWife(husband: husband, wife: wife);
                Console.WriteLine($"FamID: {famId}, Husband: {husband}, Wife: {wife}");
            }
        }
        #endregion ON_LOAD
    }
}
