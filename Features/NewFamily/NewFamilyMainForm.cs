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
    }
}
