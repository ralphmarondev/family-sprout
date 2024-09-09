using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Components
{
    public partial class ParentUserControl : UserControl
    {
        public ParentUserControl()
        {
            InitializeComponent();
        }

        public void SetParentDetails(string _name, string _from)
        {
            lblParentName.Text = _name;
            lblParentFrom.Text = _from;
        }
    }
}
