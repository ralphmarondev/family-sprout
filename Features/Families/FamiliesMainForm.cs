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
            SetupPopupPanel();

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                lblNotice.Visible = true;
            }

            SetupDataGridView();

            families.Clear();
            families = DBFamilyList.GetAllFamilies();
            FetchFamilies();

            // add items to combo-box
            tbSelectedHometown.Items.Clear();
            foreach (var item in Constants.itemsList)
            {
                tbSelectedHometown.Items.Add(item);
            }
        }


        #region POPULATING_DATAGRIDVIEW
        private void SetupDataGridView()
        {
            dataGridViewFamilies.Columns.Add("FamilyId", "Family ID");
            dataGridViewFamilies.Columns["FamilyId"].Visible = false;

            dataGridViewFamilies.Columns.Add("HusbandName", "Husband");
            dataGridViewFamilies.Columns.Add("WifeName", "Wife");
            dataGridViewFamilies.Columns.Add("HomeTown", "Town");
            dataGridViewFamilies.Columns.Add("ChildCount", "Child");

            // Create an action column with buttons
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Action";
            actionColumn.Text = "More";
            actionColumn.UseColumnTextForButtonValue = true;
            dataGridViewFamilies.Columns.Add(actionColumn);

            // Set the relative widths using FillWeight
            dataGridViewFamilies.Columns["HusbandName"].FillWeight = 25; // 25% for Husband
            dataGridViewFamilies.Columns["WifeName"].FillWeight = 25;    // 25% for Wife
            dataGridViewFamilies.Columns["HomeTown"].FillWeight = 20;    // 20% for Home Town
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
                        family.hometown,
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
            // clear searchWife
            // check if hometown is empty
            // if not empty: populate by husband and hometown
            // if empty: populate by husband
            // if husband.isEmpty: getAllFamilies
            // if husband.isEmpty and hometown.isNotEmpty: populate by hometown
            // 
            tbSearchWife.Text = string.Empty;
            string search = tbSearchHusband.Text.Trim();
            string hometown = tbSelectedHometown.Text.Trim();
            if (search == string.Empty && hometown == string.Empty)
            {
                families = DBFamilyList.GetAllFamilies();
            }
            else if (search == string.Empty && hometown != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHometown(hometown);
            }
            else if (search != string.Empty && hometown == string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHusbandName(search);
            }
            else if (search != string.Empty && hometown != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHusbandNameAndHometown(search, hometown);
            }
            else
            {
                families = DBFamilyList.GetAllFamilies();
            }
            FetchFamilies();
        }

        private void tbSearchWife_TextChanged(object sender, EventArgs e)
        {
            tbSearchHusband.Text = string.Empty;
            string search = tbSearchWife.Text.Trim();
            string hometown = tbSelectedHometown.Text.Trim();
            if (search == string.Empty && hometown == string.Empty)
            {
                families = DBFamilyList.GetAllFamilies();
            }
            else if (search == string.Empty && hometown != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHometown(hometown);
            }
            else if (search != string.Empty && hometown == string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByWifeName(search);
            }
            else if (search != string.Empty && hometown != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByWifeNameAndHometown(search, hometown);
            }
            else
            {
                families = DBFamilyList.GetAllFamilies();
            }
            FetchFamilies();
        }

        private void tbSelectedHometown_TextChanged(object sender, EventArgs e)
        {
            string husband = tbSearchHusband.Text.Trim();
            string wife = tbSearchWife.Text.Trim();
            string hometown = tbSelectedHometown.Text.Trim();

            if (hometown != string.Empty && husband != string.Empty && wife != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHomeTownAndHusbandAndWife(hometown, husband, wife);
            }
            else if (hometown != string.Empty && husband != string.Empty && wife == string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHusbandNameAndHometown(husband, hometown);
            }
            else if (hometown != string.Empty && husband == string.Empty && wife != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByWifeNameAndHometown(wife, hometown);
            }
            else if (hometown != string.Empty && husband == string.Empty && wife == string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHometown(hometown);
            }
            else if (hometown == string.Empty && husband != string.Empty && wife != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHusbandAndWife(husband, wife);
            }
            else if (hometown == string.Empty && husband != string.Empty && wife == string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByHusbandName(husband);
            }
            else if (hometown == string.Empty && husband == string.Empty && wife != string.Empty)
            {
                families = DBFamilyList.UpdateDisplayedFamiliesByWifeName(wife);
            }
            else
            {
                families = DBFamilyList.GetAllFamilies();
            }
            FetchFamilies();
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



        #region USER_INTERFACE

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
            string role = (SessionManager.CurrentUser.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
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


        #region DESTINATION
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
        #endregion DESTINATION


        #region LABEL_CURRENT_USER
        private void lblCurrentUser_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblCurrentUser_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblCurrentUser_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_CURRENT_USER


        #region BUTTON_CURRENT_USER_INFO
        private void btnCurrentUserInfo_MouseHover(object sender, EventArgs e)
        {

            TogglePopUp();
        }

        private void btnCurrentUserInfo_MouseLeave(object sender, EventArgs e)
        {
            HidePopUp();
        }
        #endregion BUTTON_CURRENT_USER_INFO

        #endregion USER_INTERFACE
    }
}
