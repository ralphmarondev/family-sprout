using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard.Controls
{
    public partial class TotalCountUserControl : UserControl
    {
        public TotalCountUserControl(string header, int value)
        {
            InitializeComponent();

            lblHeader.Text = header;
            lblValue.Text = value.ToString();
        }
    }
}
