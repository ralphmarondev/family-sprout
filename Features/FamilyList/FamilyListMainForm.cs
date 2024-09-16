using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
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
            SetupPopupPanel();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
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
            dataGridViewFamilies.DefaultCellStyle.Font = new Font("Courier New", 14);

            // Set font size for headers (optional)
            dataGridViewFamilies.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 14, FontStyle.Bold);

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
                            bool hasResults = false;
                            while (reader.Read())
                            {
                                hasResults = true;
                                long familyId = reader.GetInt64(0);
                                string husbandName = reader.GetString(1);
                                string wifeName = reader.GetString(2);
                                int childCount = reader.GetInt32(3);

                                // Add a row to the DataGridView
                                dataGridViewFamilies.Rows.Add(familyId, husbandName, wifeName, childCount);
                            }
                            lblEmpty.Visible = !hasResults;
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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim().Length > 0)
            {
                dataGridViewFamilies.Rows.Clear();
                UpdateDataGridView(tbSearch.Text.Trim());
            }
            else
            {
                dataGridViewFamilies.Rows.Clear();
                LoadFamilyData();
            }
        }

        private void UpdateDataGridView(string _searchText)
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    // Update query to filter by husband's name based on search text
                    string query = @"
                SELECT 
                    f.id AS FamilyId, 
                    h.name AS HusbandName,
                    w.name AS WifeName,
                    (SELECT COUNT(*) FROM children WHERE fam_id = f.id AND is_deleted = 0) AS ChildCount
                FROM families f
                LEFT JOIN parents h ON f.husband = h.id
                LEFT JOIN parents w ON f.wife = w.id
                WHERE f.is_deleted = 0
                AND h.name LIKE @searchText;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Add parameter for search text
                        command.Parameters.AddWithValue("@searchText", $"{_searchText}%");

                        using (var reader = command.ExecuteReader())
                        {
                            // Clear existing rows
                            dataGridViewFamilies.Rows.Clear();
                            bool hasResults = false;
                            while (reader.Read())
                            {
                                hasResults = true;
                                long familyId = reader.GetInt64(0);
                                string husbandName = reader.GetString(1);
                                string wifeName = reader.GetString(2);
                                int childCount = reader.GetInt32(3);

                                // Add a row to the DataGridView
                                dataGridViewFamilies.Rows.Add(familyId, husbandName, wifeName, childCount);
                            }
                            lblEmpty.Visible = !hasResults;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                MainForm mainScreen = this.ParentForm as MainForm;

                if (mainScreen != null)
                {
                    mainScreen.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            }
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;
        }
        #endregion DRAG_AND_DROP

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
                popupPanel.Visible = false;
            }
        }


        private Panel popupPanel;
        private void SetupPopupPanel()
        {
            // Initialize the panel
            popupPanel = new Panel();
            popupPanel.Size = new Size(340, 100);
            popupPanel.BackColor = Color.Lavender;

            // You can add controls inside the popup panel if needed
            Label lblInfo = new Label
            {
                Text = SessionManager.CurrentUser.fullName,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = SessionManager.CurrentUser.username,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            string role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? "SUPERUSER" : "USER";
            Label lblInfo3 = new Label
            {
                Text = role,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo2.Bottom + 5)
            };

            popupPanel.Controls.Add(lblInfo);
            popupPanel.Controls.Add(lblInfo2);
            popupPanel.Controls.Add(lblInfo3);

            // Initially hide the panel
            popupPanel.Visible = false;

            // Add the panel to the form's controls
            this.Controls.Add(popupPanel);
        }
        private void btnCurrentUserInfo_Click(object sender, System.EventArgs e)
        {
            // Toggle popup visibility
            popupPanel.Visible = !popupPanel.Visible;

            // Set the location of the popup panel below the button
            var buttonLocation = btnCurrentUserInfo.PointToScreen(Point.Empty);
            popupPanel.Location = this.PointToClient(new Point(buttonLocation.X, buttonLocation.Y + btnCurrentUserInfo.Height));
            popupPanel.BringToFront();
        }

    }
}
