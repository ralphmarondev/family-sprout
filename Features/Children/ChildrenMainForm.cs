using FamilySprout.Core.Utils;
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
    }
}
