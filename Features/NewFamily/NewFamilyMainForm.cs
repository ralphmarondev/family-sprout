using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using FamilySprout.Features.NewFamily.Dialog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily
{
    public partial class NewFamilyMainForm : Form
    {
        public NewFamilyMainForm()
        {
            InitializeComponent();
            SetupPopupPanel();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldEmpty()) return;

            try
            {
                long familyId = DBFamily.CreateNewFamily(
                    _husband: tbHusbandFullName.Text.Trim(),
                    _husbandFrom: tbHusbandFrom.Text.Trim(),
                    _wife: tbWifeFullName.Text.Trim(),
                    _wifeFrom: tbWifeFrom.Text.Trim(),
                    _remarks: tbRemarks.Text.Trim()
                    );

                MainForm mainForm = this.ParentForm as MainForm;
                ConfirmAddingNewFamily confirmAddingNewFamily = new ConfirmAddingNewFamily();

                if (confirmAddingNewFamily.ShowDialog(this) == DialogResult.OK)
                {
                    if (mainForm != null)
                    {
                        mainForm.OpenNewChildrenForm(_famId: familyId);
                    }
                }
                else
                {
                    if (mainForm != null)
                    {
                        mainForm.OpenFamilyListForm();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private bool IsRequiredFieldEmpty()
        {
            if (tbHusbandFullName.Text == "" || tbWifeFullName.Text == "" || tbHusbandFrom.Text == "" || tbWifeFrom.Text == "" || tbRemarks.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
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
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = SessionManager.CurrentUser.username,
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            string role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? "SUPERUSER" : "USER";
            Label lblInfo3 = new Label
            {
                Text = role,
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
