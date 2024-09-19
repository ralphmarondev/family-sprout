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

            dataGridViewFamilies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFamilies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFamilies.AllowUserToAddRows = false;
            dataGridViewFamilies.AllowUserToDeleteRows = false;
            dataGridViewFamilies.ReadOnly = true;
            dataGridViewFamilies.Margin = new Padding(0);
            dataGridViewFamilies.Padding = new Padding(0);

            dataGridViewFamilies.DefaultCellStyle.Font = new Font("Courier New", 14);
            dataGridViewFamilies.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 14, FontStyle.Bold);
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

        private void LoadFamilyData()
        {
            try
            {
                using (var connection = new SQLiteConnection(DBConfig.connectionString))
                {
                    connection.Open();

                    string query = "SELECT f.id AS FamilyId, " +
                        "(SELECT COUNT(*) FROM children WHERE fam_id = f.id AND is_deleted = 0) AS ChildCount " +
                        "FROM families f " +
                        "WHERE f.is_deleted = 0;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            bool hasResults = false;
                            int familyIdOrdinal = reader.GetOrdinal("FamilyId");
                            int childCountOrdinal = reader.GetOrdinal("ChildCount");

                            while (reader.Read())
                            {
                                hasResults = true;
                                long familyId = reader.GetInt64(familyIdOrdinal);
                                int childCount = reader.GetInt32(childCountOrdinal);

                                string husbandQuery = @"
                            SELECT p.name 
                            FROM parents p
                            WHERE p.fam_id = @FamilyId AND p.role = 0;";

                                string husbandName = null;
                                using (var husbandCommand = new SQLiteCommand(husbandQuery, connection))
                                {
                                    husbandCommand.Parameters.AddWithValue("@FamilyId", familyId);
                                    using (var husbandReader = husbandCommand.ExecuteReader())
                                    {
                                        if (husbandReader.Read())
                                        {
                                            int nameOrdinal = husbandReader.GetOrdinal("name");
                                            husbandName = husbandReader.GetString(nameOrdinal);
                                        }
                                    }
                                }

                                string wifeQuery = @"
                            SELECT p.name 
                            FROM parents p
                            WHERE p.fam_id = @FamilyId AND p.role = 1;";

                                string wifeName = null;
                                using (var wifeCommand = new SQLiteCommand(wifeQuery, connection))
                                {
                                    wifeCommand.Parameters.AddWithValue("@FamilyId", familyId);
                                    using (var wifeReader = wifeCommand.ExecuteReader())
                                    {
                                        if (wifeReader.Read())
                                        {
                                            int nameOrdinal = wifeReader.GetOrdinal("name");
                                            wifeName = wifeReader.GetString(nameOrdinal);
                                        }
                                    }
                                }

                                dataGridViewFamilies.Rows.Add(familyId, husbandName, wifeName, childCount);
                            }
                            lblEmpty.Visible = !hasResults;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void dataGridViewFamilies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewFamilies.Columns["Action"].Index)
            {
                string famId = dataGridViewFamilies.Rows[e.RowIndex].Cells["FamilyId"].Value.ToString();
                string husband = dataGridViewFamilies.Rows[e.RowIndex].Cells["HusbandName"].Value.ToString();
                string wife = dataGridViewFamilies.Rows[e.RowIndex].Cells["WifeName"].Value.ToString();

                Console.WriteLine($"Family ID: {famId},Husband: {husband}, wife: {wife}");

                MainForm mainForm = this.ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamilyDetailsForm(Convert.ToInt64(famId));
                }
            }
        }


        #region SEARCH
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

                    string query = @"
                SELECT 
                    f.id AS FamilyId, 
                    h.name AS HusbandName,
                    w.name AS WifeName,
                    (SELECT COUNT(*) FROM children WHERE fam_id = f.id AND is_deleted = 0) AS ChildCount
                FROM families f
                LEFT JOIN parents h ON f.id = h.fam_id AND h.role = 0  -- Husband role
                LEFT JOIN parents w ON f.id = w.fam_id AND w.role = 1  -- Wife role
                WHERE f.is_deleted = 0
                AND h.name LIKE @searchText;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Use wildcard for partial matching
                        command.Parameters.AddWithValue("@searchText", $"{_searchText}%");

                        using (var reader = command.ExecuteReader())
                        {
                            dataGridViewFamilies.Rows.Clear();
                            bool hasResults = false;

                            while (reader.Read())
                            {
                                hasResults = true;
                                long familyId = reader.GetInt64(reader.GetOrdinal("FamilyId"));
                                string husbandName = reader.IsDBNull(reader.GetOrdinal("HusbandName"))
                                                     ? "Unknown"
                                                     : reader.GetString(reader.GetOrdinal("HusbandName"));
                                string wifeName = reader.IsDBNull(reader.GetOrdinal("WifeName"))
                                                  ? "Unknown"
                                                  : reader.GetString(reader.GetOrdinal("WifeName"));
                                int childCount = reader.GetInt32(reader.GetOrdinal("ChildCount"));

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
        #endregion SEARCH


        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void OnMouseUp()
        {
            dragging = false;
        }

        private void OnMouseMove()
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

        private void OnMouseDown()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;
        }
        #endregion DRAG_AND_DROP


        #region POP_UP
        private Panel popupPanel;
        private void SetupPopupPanel()
        {
            popupPanel = new Panel();
            popupPanel.Size = new Size(340, 100);
            popupPanel.BackColor = Color.Lavender;

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
            string role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? Roles.SUPERUSER_LABEL : Roles.USER_LABEL;
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
            this.Controls.Add(popupPanel);
        }

        private void TogglePopUp()
        {
            popupPanel.Visible = !popupPanel.Visible;

            var buttonLocation = btnCurrentUserInfo.PointToScreen(Point.Empty);
            popupPanel.Location = this.PointToClient(new Point(buttonLocation.X, buttonLocation.Y + btnCurrentUserInfo.Height));
            popupPanel.BringToFront();
        }

        private void HidePopUp()
        {
            popupPanel.Visible = false;
        }

        private void DashboardMainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (popupPanel.Visible)
            {
                Point clickLocation = this.PointToClient(Cursor.Position);

                if (!popupPanel.Bounds.Contains(clickLocation))
                {
                    popupPanel.Visible = false;
                }
            }
        }
        #endregion POP_UP


        #region PANEL_TITLE
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion PANEL_TITLE


        #region LABEL_DESTINATION
        private void lblDestination_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblDestination_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblDestination_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_DESTINATION


        #region LABEL_ADMIN_NAME
        private void lblAdminName_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblAdminName_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblAdminName_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }

        private void lblAdminName_Click(object sender, System.EventArgs e)
        {
            lblAdminName_MouseHover(sender, e);
        }
        private void lblAdminName_MouseHover(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }

        private void lblAdminName_MouseLeave(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }
        #endregion LABEL_ADMIN_NAME


        #region BUTTON_CURRENT_USER
        private void btnCurrentUserInfo_Click(object sender, System.EventArgs e)
        {
            HidePopUp();
        }
        private void btnCurrentUserInfo_MouseHover(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }

        private void btnCurrentUserInfo_MouseLeave(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }
        #endregion BUTTON_CURRENT_USER


        #region BUTTON_FULL_SCREEN
        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
                popupPanel.Visible = false;
            }
        }
        #endregion BUTTON_FULL_SCREEN


        #region LABEL_SEARCH_TEXT
        private void lblSearchText_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblSearchText_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblSearchText_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_SEARCH_TEXT
    }
}
