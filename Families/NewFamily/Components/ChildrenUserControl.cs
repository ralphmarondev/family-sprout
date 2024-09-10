using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Components
{
    public partial class ChildrenUserControl : UserControl
    {
        public string name { get; set; }
        public string bday { get; set; }
        public string baptism { get; set; }
        public string hc { get; set; }
        public string matrimony { get; set; }
        public string obitus { get; set; }

        public ChildrenUserControl()
        {
            InitializeComponent();
        }

        public ChildrenUserControl(
            string _name, string _bday, string _baptism,
            string _hc, string _matrimony, string _obitus
            )
        {
            InitializeComponent();

            name = _name;
            bday = _bday;
            baptism = _baptism;
            hc = _hc;
            matrimony = _matrimony;
            obitus = _obitus;

            lblChildName.Text = _name;
            lblChildBirthday.Text = _bday;
        }

        public void SetChildrenDetails(string _name, string _bday)
        {
            lblChildName.Text = _name;
            lblChildBirthday.Text = _bday;

            name = _name;
            bday = _bday;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            PanelChildInfo_Click(sender, e);
        }

        private void PanelChildInfo_Click(object sender, System.EventArgs e)
        {
            if (ParentForm is NewFamilyMainScreen parentForm)
            {
                parentForm.ChildControl_Click(this);
            }
        }
    }
}
