﻿using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Children.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.Children.Controls
{
    public partial class ChildUserControl : UserControl
    {
        private ChildModel child = new ChildModel();
        public ChildUserControl(ChildModel child)
        {
            InitializeComponent();
            this.child = child;

            lblName.Text = child.name;
            lblBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);

            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            ViewChildDialog viewChild = new ViewChildDialog(child);

            viewChild.ShowDialog(this);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {

        }
    }
}