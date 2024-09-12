using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class ViewChildDialog : Form
    {
        public ViewChildDialog(
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _obitus,
            string _matrimony
            )
        {
            InitializeComponent();

            tbName.Text = _name;
            tbBday.Text = _bday;
            tbBaptism.Text = _baptism;
            tbHc.Text = _hc;
            tbObitus.Text = _obitus;
            tbMatrimony.Text = _matrimony;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
