using FamilySprout.Core.Model;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Families.Controls
{
    public partial class TrashFamilyUserControl : UserControl
    {
        private FamilyModel family;
        public TrashFamilyUserControl(FamilyModel family)
        {
            InitializeComponent();
            this.family = family;

            lblHusband.Text = family.husbandName;
            lblWife.Text = family.wifeName;
        }
    }
}
