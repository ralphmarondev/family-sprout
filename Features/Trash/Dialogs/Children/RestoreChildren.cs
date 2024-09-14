using FamilySprout.Core.DB;
using FamilySprout.Shared.Model;
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
            tbBirthday.Text = child.bday;
            tbBaptism.Text = child.baptism;
            tbHc.Text = child.hc;
            tbMatrimony.Text = child.matrimony;
            tbObitus.Text = child.obitus;
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
