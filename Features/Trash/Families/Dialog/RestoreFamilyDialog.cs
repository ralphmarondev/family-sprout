using FamilySprout.Core.Model;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Families.Dialog
{
    public partial class RestoreFamilyDialog : Form
    {
        private FamilyModel family;
        public RestoreFamilyDialog(FamilyModel family)
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

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (DBTrash.RestoreFamily(family.id))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
