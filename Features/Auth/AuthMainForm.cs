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
            MainForm mainForm = new MainForm();

            Hide();
            mainForm.Show();
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
