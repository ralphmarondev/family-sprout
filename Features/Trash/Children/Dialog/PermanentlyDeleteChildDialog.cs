using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Children.Dialog
{
    public partial class PermanentlyDeleteChildDialog : Form
    {
        private ChildModel child;
        public PermanentlyDeleteChildDialog(ChildModel child)
        {
            InitializeComponent();

            this.child = child; tbName.Text = child.name;
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

        private void btnPermanentlyDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                      "Are your sure you want to permanently delete this chlid?",
                      "Last Warning!",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning
                  );

            if (result == DialogResult.Yes)
            {
                if (DBTrash.PermanentlyDeleteChild(child.id))
                {
                    MessageBox.Show("This child has been permanently deleted.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}
