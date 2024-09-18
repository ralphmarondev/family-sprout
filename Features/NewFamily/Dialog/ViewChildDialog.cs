using FamilySprout.Core.Utils;
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
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(_bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(_baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(_hc);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(_obitus);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(_matrimony);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
