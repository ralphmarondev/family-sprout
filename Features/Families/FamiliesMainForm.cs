using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Families.DB;
using FamilySprout.Features.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Families
{
    public partial class FamiliesMainForm : Form
    {
        private List<FamilyModel> families = new List<FamilyModel>();
        public FamiliesMainForm()
        {
            InitializeComponent();

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
            SetupDataGridView();
            FetchFamilies();
        }

        private void SetupDataGridView()
        {
            dataGridViewFamilies.Columns.Add("FamilyId", "Family ID");
            dataGridViewFamilies.Columns["FamilyId"].Visible = false;

            dataGridViewFamilies.Columns.Add("HusbandName", "Husband");
            dataGridViewFamilies.Columns.Add("WifeName", "Wife");
            dataGridViewFamilies.Columns.Add("ChildCount", "Child");

            // Create an action column with buttons
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.Text = "Action";
            actionColumn.UseColumnTextForButtonValue = true;
            dataGridViewFamilies.Columns.Add(actionColumn);

            // Set the relative widths using FillWeight
            dataGridViewFamilies.Columns["HusbandName"].FillWeight = 35; // 35% for Husband
            dataGridViewFamilies.Columns["WifeName"].FillWeight = 35;    // 35% for Wife
            dataGridViewFamilies.Columns["ChildCount"].FillWeight = 15;  // 15% for Child Count
            dataGridViewFamilies.Columns["Action"].FillWeight = 15;      // 15% for Action buttons

            // General settings
            dataGridViewFamilies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFamilies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFamilies.AllowUserToAddRows = false;
            dataGridViewFamilies.AllowUserToDeleteRows = false;
            dataGridViewFamilies.ReadOnly = true;
            dataGridViewFamilies.Margin = new Padding(0);
            dataGridViewFamilies.Padding = new Padding(0);

            dataGridViewFamilies.DefaultCellStyle.Font = new Font("Courier New", 14);
            dataGridViewFamilies.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 14, FontStyle.Bold);
            dataGridViewFamilies.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
            dataGridViewFamilies.EnableHeadersVisualStyles = false; // Ensure the custom style is applied

            dataGridViewFamilies.RowHeadersWidth = 30;  // Adjust this to match the size of the drag indicator
            dataGridViewFamilies.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5); // Top, Left, Bottom, Right

            // Set padding around action buttons
            foreach (DataGridViewColumn column in dataGridViewFamilies.Columns)
            {
                if (column is DataGridViewButtonColumn)
                {
                    column.DefaultCellStyle.Padding = new Padding(5);
                }
            }

            dataGridViewFamilies.RowTemplate.Height = 60;
            dataGridViewFamilies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFamilies.CellClick += dataGridViewFamilies_CellContentClick;
        }

        private void FetchFamilies()
        {
            families.Clear();
            families = DBFamilyList.GetAllFamilies();

            if (families.Count > 0)
            {
                lblEmpty.Visible = false;
                dataGridViewFamilies.Rows.Clear();

                foreach (var family in families)
                {
                    dataGridViewFamilies.Rows.Add(
                        family.id,
                        family.husbandName,
                        family.wifeName,
                        family.childCount
                        );
                }
            }
            else
            {
                lblEmpty.Visible = true;
            }
        }

        private void dataGridViewFamilies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewFamilies.Columns["Action"].Index)
            {
                string famId = dataGridViewFamilies.Rows[e.RowIndex].Cells["FamilyId"].Value.ToString();

                MainForm mainForm = this.ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamilyDetailsMainForm(Convert.ToInt64(famId));
                }
            }
        }

        private List<FamilyModel> GetSampleFamilies()
        {
            return new List<FamilyModel>
            {
                new FamilyModel
                {
                    id = 1,
                    husband = 101,
                    husbandName = "John Doe",
                    wife = 102,
                    wifeName = "Jane Doe",
                    childCount = 3,
                    hometown = "Springfield",
                    remarks = "No Remarks.",
                    createdBy = "System",
                    dateCreated = "2023-08-01",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 2,
                    husband = 103,
                    husbandName = "Michael Smith",
                    wife = 104,
                    wifeName = "Anna Smith",
                    childCount = 2,
                    hometown = "Shelbyville",
                    remarks = "No Remarks.",
                    createdBy = "admin",
                    dateCreated = "2023-08-05",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 3,
                    husband = 105,
                    husbandName = "Robert Johnson",
                    wife = 106,
                    wifeName = "Emily Johnson",
                    childCount = 4,
                    hometown = "Ogdenville",
                    remarks = "Family loves hiking.",
                    createdBy = "admin",
                    dateCreated = "2023-08-10",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 4,
                    husband = 107,
                    husbandName = "William Brown",
                    wife = 108,
                    wifeName = "Olivia Brown",
                    childCount = 1,
                    hometown = "Capital City",
                    remarks = "Recently moved to town.",
                    createdBy = "System",
                    dateCreated = "2023-09-01",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 5,
                    husband = 109,
                    husbandName = "James Wilson",
                    wife = 110,
                    wifeName = "Sophia Wilson",
                    childCount = 2,
                    hometown = "North Haverbrook",
                    remarks = "Children attending local school.",
                    createdBy = "System",
                    dateCreated = "2023-09-05",
                    isDeleted = true // This family is marked as deleted
                },
                new FamilyModel
                {
                    id = 6,
                    husband = 107,
                    husbandName = "William Brown",
                    wife = 108,
                    wifeName = "Olivia Brown",
                    childCount = 1,
                    hometown = "Capital City",
                    remarks = "Recently moved to town.",
                    createdBy = "System",
                    dateCreated = "2023-09-01",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 7,
                    husband = 109,
                    husbandName = "James Wilson",
                    wife = 110,
                    wifeName = "Sophia Wilson",
                    childCount = 2,
                    hometown = "North Haverbrook",
                    remarks = "Children attending local school.",
                    createdBy = "System",
                    dateCreated = "2023-09-05",
                    isDeleted = true // This family is marked as deleted
                },
                new FamilyModel
                {
                    id = 8,
                    husband = 107,
                    husbandName = "William Brown",
                    wife = 108,
                    wifeName = "Olivia Brown",
                    childCount = 1,
                    hometown = "Capital City",
                    remarks = "Recently moved to town.",
                    createdBy = "System",
                    dateCreated = "2023-09-01",
                    isDeleted = false
                },
                new FamilyModel
                {
                    id = 9,
                    husband = 109,
                    husbandName = "James Wilson",
                    wife = 110,
                    wifeName = "Sophia Wilson",
                    childCount = 2,
                    hometown = "North Haverbrook",
                    remarks = "Children attending local school.",
                    createdBy = "System",
                    dateCreated = "2023-09-05",
                    isDeleted = true // This family is marked as deleted
                }
            };
        }
    }
}
