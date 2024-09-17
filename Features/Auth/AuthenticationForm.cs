using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Auth
{
    public partial class AuthenticationForm : Form
    {
        private int count;
        public AuthenticationForm()
        {
            InitializeComponent();
            SetupPopupPanel();

            count = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldsEmpty()) return;

            if (
                DBUsers.IsUserExists(
                _username: tbUsername.Text.Trim(),
                _password: tbPassword.Text.Trim()
                ))
            {
                SessionManager.CurrentUser = DBUsers.GetUserDetailsByUsername(_username: tbUsername.Text.Trim());

                MainForm mainForm = new MainForm();
                Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Username and Password does not match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsRequiredFieldsEmpty()
        {
            if (tbUsername.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show("Username and Password cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbUsername.Text == "" && tbPassword.Text != "")
            {
                MessageBox.Show("Username cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
            else if (tbUsername.Text != "" && tbPassword.Text == "")
            {
                MessageBox.Show("Password cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            count++;
            switch (count)
            {
                case 1:
                    lblCopyright.Text = $"© {DateTime.Now.Year} RALPH MARON A. EDA. All Rights Reserved.";
                    break;
                case 2:
                    lblCopyright.Text = "Build: 2024-09-17";
                    break;
                case 3:
                    lblCopyright.Text = "Version 1.0";
                    count = 0;
                    break;
            }
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

                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void OnMouseDown()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
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
                Text = "Family Sprout",
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = "Version 1.0 (Build 2024-09-17)",
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            Label lblInfo3 = new Label
            {
                Text = "Developed by: Ralph Maron Eda",
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

            var buttonLocation = btnInfo.PointToScreen(Point.Empty);
            int popUpX = buttonLocation.X + btnInfo.Width - popupPanel.Width;
            int popUpY = buttonLocation.Y + btnInfo.Height;

            popupPanel.Location = this.PointToClient(new Point(popUpX, popUpY));
            popupPanel.BringToFront();
        }

        private void HidePopUp()
        {
            popupPanel.Visible = false;
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


        #region BUTTON_INFO
        private void btnInfo_Click(object sender, EventArgs e)
        {
            HidePopUp();
        }

        private void btnInfo_MouseHover(object sender, EventArgs e)
        {
            TogglePopUp();
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            HidePopUp();
        }
        #endregion BUTTON_INFO
    }
}
