using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Auth
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
