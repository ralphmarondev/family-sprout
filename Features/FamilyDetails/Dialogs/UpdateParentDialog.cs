using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.DB;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails.Dialogs
{
    public partial class UpdateParentDialog : Form
    {
        ParentModel parent;
        public UpdateParentDialog(ParentModel parent)
        {
            InitializeComponent();
            this.parent = parent;

            tbName.Text = parent.name;
            tbContactNumber.Text = parent.contactNumber;
            tbBirthPlace.Text = parent.birthPlace;
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(parent.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(parent.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(parent.hc);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(parent.matrimony);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(parent.obitus);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (DBFamilyDetails.UpdateParentDetails(parent))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
