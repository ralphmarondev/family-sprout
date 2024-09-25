using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Children.Dialog
{
    public partial class RestoreChildDialog : Form
    {
        private ChildModel child;
        public RestoreChildDialog(ChildModel child)
        {
            InitializeComponent();

            this.child = child;

            tbName.Text = child.name;
            tbBirthday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(child.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(child.hc);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(child.matrimony);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(child.obitus);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (DBTrash.RestoreChild(child.id, child.famId))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
