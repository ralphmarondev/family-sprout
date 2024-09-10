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
    }
}
