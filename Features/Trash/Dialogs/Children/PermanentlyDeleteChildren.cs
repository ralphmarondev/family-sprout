using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.Children
{
    public partial class PermanentlyDeleteChildren : Form
    {
        private ChildModel child;
        public PermanentlyDeleteChildren(ChildModel _child)
        {
            InitializeComponent();

            child = _child;
            tbName.Text = child.name;
            tbBirthday.Text = child.bday;
            tbBaptism.Text = child.baptism;
            tbHc.Text = child.hc;
            tbMatrimony.Text = child.matrimony;
            tbObitus.Text = child.obitus;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPermanentlyDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                        "Are your sure you want to permanently delete this chlid?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    DBChildren.PermanentlyDeleteChild(child.id);
                    MessageBox.Show("This child has been permanently deleted.");
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Close();
        }
    }
}
