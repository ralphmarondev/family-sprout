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
            if (count > 1)
            {
                lblCopyright.Text = $"© {DateTime.Now.Year} RALPH MARON A. EDA. All Rights Reserved.";
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
    }
}
