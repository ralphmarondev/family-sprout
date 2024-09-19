using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class DeleteChildDialog : Form
    {
        private ChildModel child;
        public DeleteChildDialog(ChildModel child)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            child.name = tbName.Text.Trim();
            child.bday = tbBday.Text.Trim();
            child.baptism = tbBaptism.Text.Trim();
            child.hc = tbHc.Text.Trim();
            child.obitus = tbObitus.Text.Trim();
            child.matrimony = tbMatrimony.Text.Trim();

            try
            {
                DBChildren.DeleteChild(child.id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
