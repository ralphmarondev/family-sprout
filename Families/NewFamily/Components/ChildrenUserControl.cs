using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Components
{
    public partial class ChildrenUserControl : UserControl
    {
        public ChildrenUserControl()
        {
            InitializeComponent();
        }

        public void SetChildrenDetails(string _name, string _bday)
        {
            lblChildName.Text = _name;
            lblChildBirthday.Text = _bday;
        }
    }
}
