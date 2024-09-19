using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyList.Forms;
using FamilySprout.Features.NewFamily.Dialog;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Controls
{
    public partial class FamilyChildUserControl : UserControl
    {
        private long id;
        private ChildModel child;

        public FamilyChildUserControl(
            ChildModel _child)
        {
            InitializeComponent();

            child = _child;

            lblName.Text = child.name;
            lblBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);

            if (SessionManager.CurrentUser.role == Roles.USER)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewChildDialog viewChild = new ViewChildDialog(child);

            viewChild.ShowDialog(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateChildDialog updateChild = new UpdateChildDialog(child);

            if (updateChild.ShowDialog(this) == DialogResult.OK)
            {
                FamilyChildListForm newChild = this.ParentForm as FamilyChildListForm;

                if (newChild != null)
                {
                    newChild.PopulatePanel();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteChildDialog deleteChild = new DeleteChildDialog(child);

            if (deleteChild.ShowDialog(this) == DialogResult.OK)
            {
                FamilyChildListForm newChild = this.ParentForm as FamilyChildListForm;

                if (newChild != null)
                {
                    newChild.PopulatePanel();
                }
            }
        }
    }
}
