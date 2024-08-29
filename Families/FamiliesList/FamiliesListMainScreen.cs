using FamilySprout.Core.Helper;
using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList
{
    public partial class FamiliesListMainScreen : Form
    {
        public FamiliesListMainScreen()
        {
            InitializeComponent();
        }

        private void FamiliesListMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();
        }


        #region FETCH_DATA
        private void FetchData()
        {

        }
        #endregion FETCH_DATA
    }
}
