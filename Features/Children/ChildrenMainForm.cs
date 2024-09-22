using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using System.Windows.Forms;

namespace FamilySprout.Features.Children
{
    public partial class ChildrenMainForm : Form
    {
        private long famId;
        public ChildrenMainForm(long famId)
        {
            InitializeComponent();

            this.famId = famId;
            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyDetailsMainForm(famId);
            }
        }

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }
    }
}
