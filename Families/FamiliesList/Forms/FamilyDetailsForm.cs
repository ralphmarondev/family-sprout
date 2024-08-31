using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class FamilyDetailsForm : Form
    {
        private int id;
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

        }
    }
}
