using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Children.Dialog
{
    public partial class ViewChildDialog : Form
    {
        public ViewChildDialog(ChildModel child)
        {
            InitializeComponent();

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
