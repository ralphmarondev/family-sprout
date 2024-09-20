using FamilySprout.Core.Utils;
using FamilySprout.Features.Auth.DB;
using FamilySprout.Features.Home;
using System.Windows.Forms;

namespace FamilySprout.Features.Auth
{
    public partial class AuthMainForm : Form
    {
        public AuthMainForm()
        {
            InitializeComponent();
        }


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
    }
}
