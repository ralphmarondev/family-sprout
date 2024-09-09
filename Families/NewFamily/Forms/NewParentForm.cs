using System;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class NewParentForm : Form
    {
        public NewParentForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
