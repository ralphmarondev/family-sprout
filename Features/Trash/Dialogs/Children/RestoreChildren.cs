using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.Children
{
    public partial class RestoreChildren : Form
    {
        private ChildModel child;
        public RestoreChildren(ChildModel _child)
        {
            InitializeComponent();

            child = _child;

            tbName.Text = child.name;
            tbBirthday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(child.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(child.hc);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(child.matrimony);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(child.obitus);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DBChildren.RestoreChild(_id: child.id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}");
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
