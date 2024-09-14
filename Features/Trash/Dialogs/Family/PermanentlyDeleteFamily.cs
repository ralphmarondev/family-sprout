using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.Family
{
    public partial class PermanentlyDeleteFamily : Form
    {
        public PermanentlyDeleteFamily()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPermanentlyDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
