using FamilySprout.Core.Model;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Families.Dialog
{
    public partial class PermanentlyDeleteFamilyDialog : Form
    {
        private FamilyModel family;
        public PermanentlyDeleteFamilyDialog(FamilyModel family)
        {
            InitializeComponent();
            this.family = family;

            tbHusband.Text = family.husbandName;
            tbWife.Text = family.wifeName;
            tbChildCount.Text = $"{family.childCount}";
            tbHometown.Text = family.hometown;
            tbRemarks.Text = family.remarks;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                     "Are your sure you want to permanently delete this family\nand everyone related to it?",
                     "Last Warning!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning
                 );

            if (result == DialogResult.Yes)
            {
                if (DBTrash.PermanentlyDeleteFamily(family.id))
                {
                    MessageBox.Show("This family and all related to it,\nhas been deleted permanently.");
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
