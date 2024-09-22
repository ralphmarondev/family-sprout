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


        #region POPULATING_DATAGRIDVIEW
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
            actionColumn.Text = "More";
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
        #endregion POPULATING_DATAGRIDVIEW


        #region SEARCH
        private void tbSearchHusband_TextChanged(object sender, EventArgs e)
        {
            tbSearchWife.Text = string.Empty;
            if (tbSearchHusband.Text.Trim() == string.Empty)
            {
                FetchFamilies();
                return;
            }

            families = DBFamilyList.UpdateDisplayedFamiliesByHusbandName(tbSearchHusband.Text.Trim());

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
                lblEmpty.BringToFront();
                dataGridViewFamilies.Rows.Clear();
            }
        }

        private void tbSearchWife_TextChanged(object sender, EventArgs e)
        {
            tbSearchHusband.Text = string.Empty;
            if (tbSearchWife.Text.Trim() == string.Empty)
            {
                FetchFamilies();
                return;
            }

            families = DBFamilyList.UpdateDisplayedFamiliesByWifeName(tbSearchWife.Text.Trim());

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
                lblEmpty.BringToFront();
                dataGridViewFamilies.Rows.Clear();
            }
        }

        private void tbSelectedHometown_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion SEARCH

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }
    }
}
