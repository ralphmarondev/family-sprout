using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Controls
{
    public partial class FamilyRestoreUserControl : UserControl
    {
        public long famId { get; set; }
        public string husband { get; set; }
        public string wife { get; set; }

        public FamilyRestoreUserControl(
            long _famId,
            string _husband,
            string _wife)
        {
            InitializeComponent();

            famId = _famId;
            husband = _husband;
            wife = _wife;

            lblHusband.Text = husband;
            lblWife.Text = wife;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // show 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
