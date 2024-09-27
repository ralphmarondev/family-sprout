using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard.Controls
{
    public partial class TotalCountUserControl : UserControl
    {
        public TotalCountUserControl(string header, long value)
        {
            InitializeComponent();

            lblHeader.Text = header;
            lblValue.Text = value.ToString();
        }
    }
}
