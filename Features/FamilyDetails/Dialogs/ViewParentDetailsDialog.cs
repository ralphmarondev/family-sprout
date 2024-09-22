using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails.Dialogs
{
    public partial class ViewParentDetailsDialog : Form
    {
        public ViewParentDetailsDialog(ParentModel parent)
        {
            InitializeComponent();

            tbName.Text = parent.name;
            tbContactNumber.Text = parent.contactNumber;
            tbBirthPlace.Text = parent.birthPlace;
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(parent.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(parent.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(parent.hc);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(parent.matrimony);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(parent.obitus);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
