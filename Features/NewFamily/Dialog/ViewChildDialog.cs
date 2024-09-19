using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class ViewChildDialog : Form
    {
        private ChildModel child = new ChildModel();
        public ViewChildDialog(ChildModel child)
        {
            InitializeComponent();
            this.child = child;

            tbName.Text = child.name;
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(child.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(child.hc);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(child.obitus);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(child.matrimony);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
