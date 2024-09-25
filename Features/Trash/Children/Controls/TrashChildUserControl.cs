using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Children.Controls
{
    public partial class TrashChildUserControl : UserControl
    {
        private ChildModel child;
        public TrashChildUserControl(ChildModel child)
        {
            InitializeComponent();
            this.child = child;

            lblName.Text = child.name;
            lblBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
        }
    }
}
