using FamilySprout.Core.Utils;
using FamilySprout.Features.Auth.DB;
using FamilySprout.Features.Home;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Auth
{
    public partial class AuthMainForm : Form
    {
        public AuthMainForm()
        {
            InitializeComponent();
            SetupPopupPanel();
        }

        #region APPLICATION_LOGIC

        #region BUTTON_LOGIN
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (username == string.Empty && password == string.Empty)
            {
                MessageBox.Show("Username and Password cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (username == string.Empty && password != string.Empty)
            {
                MessageBox.Show("Username cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (username != string.Empty && password == string.Empty)
            {
                MessageBox.Show("Password cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DBAuth.IsUserExists(username, password))
            {
                SessionManager.CurrentUser = DBAuth.GetUserDetailByUsername(username);

                MainForm mainForm = new MainForm();

                Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password!", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion BUTTON_LOGIN


        #region BUTTON_CLOSE
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        #endregion BUTTON_CLOSE

        #endregion APPLICATION_LOGIC



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
                Text = "Version 1.2 (Build 2024-09-30)",
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
        private void btnInfo_MouseHover(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }

        private void btnInfo_MouseLeave(object sender, System.EventArgs e)
        {
            HidePopUp();
        }
        #endregion BUTTON_INFO

        #endregion USER_INTERFACE

        private int count = 0;
        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            count++;
            switch (count)
            {
                case 1:
                    lblCopyright.Text = "Build: 2024-09-30 10:12PM";
                    break;
                case 2:
                    lblCopyright.Text = "Developed by: Ralph Maron Eda";
                    break;
                case 3:
                    lblCopyright.Text = "Version 1.2";
                    count = 0;
                    break;
            }
        }
    }
}
