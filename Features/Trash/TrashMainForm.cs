using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash
{
    public partial class TrashMainForm : Form
    {
        public TrashMainForm()
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
        }
    }
}
