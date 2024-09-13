using FamilySprout.Core.Utils;
using FamilySprout.Features.Auth;
using System.Windows.Forms;

namespace FamilySprout
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            OpenFamilyListForm();

            if (SessionManager.CurrentUser.role == 1)
            {
                btnNewFamily.Enabled = false;
                btnTrash.Enabled = false;
                btnUsers.Enabled = false;
            }
        }

        private void OpenFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            mainPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        public void OpenNewFamilyMainForm()
        {
            OpenFormInPanel(new Features.NewFamily.NewFamilyMainForm());
        }

        public void OpenNewChildrenForm(long _famId)
        {
            OpenFormInPanel(new Features.NewFamily.Forms.NewChildForm(_famId: _famId));
        }

        public void OpenFamilyListForm()
        {
            OpenFormInPanel(new Features.FamilyList.FamilyListMainForm());
        }

        public void OpenFamilyDetailsForm(long _famId)
        {
            OpenFormInPanel(new Features.FamilyList.Forms.FamilyDetailsForm(_famId: _famId));
        }

        public void OpenFamilyChildListForm(Shared.Model.FamilyModel familyModel)
        {
            OpenFormInPanel(new Features.FamilyList.Forms.FamilyChildListForm(familyModel));
        }

        public void OpenUserMainForm()
        {
            OpenFormInPanel(new Features.User.UserMainForm());
        }

        #region NAVIGATION_BUTTON_CLICKS
        private void btnFamilies_Click(object sender, System.EventArgs e)
        {
            OpenFamilyListForm();
        }

        private void btnNewFamily_Click(object sender, System.EventArgs e)
        {
            OpenNewFamilyMainForm();
        }
        private void btnUsers_Click(object sender, System.EventArgs e)
        {
            OpenUserMainForm();
        }
        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            Close();
            AuthenticationForm authenticationForm = new AuthenticationForm();

            authenticationForm.Show();
        }
        #endregion NAVIGATION_BUTTON_CLICKS
    }
}
