using FamilySprout.Core.Helper;
using System;
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
            AddStaticRow();
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
        private void AddStaticRow()
        {
            // Static data for the first row
            string husband = "John Doe";
            string wife = "Jane Doe";
            int childrenCount = 3; // Static count for demonstration

            // Add row to DataGridView
            dataGridView1.Rows.Add(husband, wife, childrenCount);
            dataGridView1.Rows.Add(wife, husband, 2);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Action" column
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                // Fetch data as needed and show a form
                MessageBox.Show("View Details clicked for " + dataGridView1.Rows[e.RowIndex].Cells["Husband"].Value);
            }
        }
        #endregion ON_LOAD
    }
}
