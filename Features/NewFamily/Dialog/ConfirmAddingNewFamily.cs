using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class ConfirmAddingNewFamily : Form
    {
        public ConfirmAddingNewFamily()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
