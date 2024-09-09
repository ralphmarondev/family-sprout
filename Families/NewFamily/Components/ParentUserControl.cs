using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Components
{
    public partial class ParentUserControl : UserControl
    {
        private string husband, husbandFrom, wife, wifeFrom, remarks;

        public ParentUserControl()
        {
            InitializeComponent();
        }

        public void SetParentDetails(
            string name,
            string from,
            string _husband,
            string _husbandFrom,
            string _wife,
            string _wifeFrom,
            string _remarks)
        {
            husband = _husband;
            husbandFrom = _husbandFrom;
            wife = _wife;
            wifeFrom = _wifeFrom;
            remarks = _remarks;

            lblParentName.Text = name;
            lblParentFrom.Text = from;
        }
    }
}
