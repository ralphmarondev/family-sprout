using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Families.FamiliesList.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class FamilyDetailsForm : Form
    {
        private int id;
        private FamilyModel family = null;
        public FamilyDetailsForm()
        {
            InitializeComponent();
        }

        public FamilyDetailsForm(int _id)
        {
            InitializeComponent();

            this.id = _id;
        }

        private void FamilyDetailsForm_Load(object sender, EventArgs e)
        {
            family = DBFamily.GetFamilyDetailsById(id);
            GetDetailsWithId();

            PopulateChildrenListPanel();

            this.Text = "Family Details - View";
        }

        private void GetDetailsWithId()
        {
            if (family == null) return;
            tbHusbandFullName.Text = family.husband;
            tbHusbandFrom.Text = family.husbandFrom;
            tbWifeFullName.Text = family.wife;
            tbWifeFrom.Text = family.wifeFrom;
            tbRemarks.Text = family.remarks;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void PopulateChildrenListPanel()
        {
            childrenListPanel.Controls.Clear();
            childrenListPanel.AutoScroll = true;
            int currentY = 10;

            foreach (var child in family.childrens)
            {
                ChildControlFL childControl = new ChildControlFL(
                    _id: child.id,
                    _name: child.name,
                    _bday: child.bday,
                    _baptism: child.baptism,
                    _hc: child.hc,
                    _matrimony: child.matrimony,
                    _obitus: child.obitus
                    );

                childControl.Location = new Point(10, currentY);
                childrenListPanel.Controls.Add(childControl);
                currentY += childControl.Height + 10;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            family = DBFamily.GetFamilyDetailsById(id);
            GetDetailsWithId();

            PopulateChildrenListPanel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteFamilyForm deleteForm = new DeleteFamilyForm(
                _husband: family.husband,
                _husbandFrom: family.husbandFrom,
                _wife: family.wife,
                _wifeFrom: family.wifeFrom,
                _childCount: family.childCount,
                _createDate: family.createDate,
                _id: family.id
                );

            if (deleteForm.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Text = "Family Details - View";

            tbHusbandFullName.ReadOnly = true;
            tbHusbandFrom.ReadOnly = true;
            tbWifeFullName.ReadOnly = true;
            tbWifeFrom.ReadOnly = true;
            tbRemarks.ReadOnly = true;

            tbHusbandFullName.BackColor = SystemColors.Window;
            tbHusbandFrom.BackColor = SystemColors.Window;
            tbWifeFullName.BackColor = SystemColors.Window;
            tbWifeFrom.BackColor = SystemColors.Window;
            tbRemarks.BackColor = SystemColors.Window;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Text = "Family Details - Update";

            tbHusbandFullName.ReadOnly = false;
            tbHusbandFrom.ReadOnly = false;
            tbWifeFullName.ReadOnly = false;
            tbWifeFrom.ReadOnly = false;
            tbRemarks.ReadOnly = false;

            tbHusbandFullName.BackColor = SystemColors.Window;
            tbHusbandFrom.BackColor = SystemColors.Window;
            tbWifeFullName.BackColor = SystemColors.Window;
            tbWifeFrom.BackColor = SystemColors.Window;
            tbRemarks.BackColor = SystemColors.Window;
        }

        private void tbHusbandFullName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
