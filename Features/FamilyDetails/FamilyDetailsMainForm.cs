using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.DB;
using FamilySprout.Features.FamilyDetails.Dialogs;
using FamilySprout.Features.Home;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails
{
    public partial class FamilyDetailsMainForm : Form
    {
        private FamilyModel family = new FamilyModel();
        private ParentModel husband = new ParentModel();
        private ParentModel wife = new ParentModel();
        public FamilyDetailsMainForm(long famId)
        {
            InitializeComponent();
            SetupPopupPanel();
            family.id = famId;
            Console.WriteLine($"FamId: {famId}");

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;

            // user role check
            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                btnUpdateFamily.Visible = false;
                btnDeleteFamily.Visible = false;

                btnUpdateHusband.Visible = false;
                btnUpdateWife.Visible = false;

                // change button location
                btnViewHusband.Location = new Point(763, 15);
                btnViewWife.Location = new Point(763, 15);

                lblNotice.Visible = true;
            }

            FetchData();
        }

        private void FetchData()
        {
            family = DBFamilyDetails.GetFamilyDetails(family.id);
            husband = DBFamilyDetails.GetParentDetails(family.id, family.husband);
            wife = DBFamilyDetails.GetParentDetails(family.id, family.wife);

            lblHusbandName.Text = husband.name;
            lblHusbandBday.Text = DateUtils.ConvertToUserReaderFormat(husband.bday);

            lblWifeName.Text = wife.name;
            lblWifeBday.Text = DateUtils.ConvertToUserReaderFormat(wife.bday);

            tbRemarks.Text = family.remarks;
            tbHometown.Text = family.hometown;

            Console.WriteLine($"HusbandName: {husband.name}, bday: {husband.bday}");
            Console.WriteLine($"WifeName: {wife.name}, bday: {wife.bday}");
            Console.WriteLine($"Remarks: {family.remarks}, hometown: {family.hometown}");
        }

        #region LABEL_BACK
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamiliesMainForm();
            }
        }
        #endregion LABEL_BACK

        private void btnNext_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenChildrenMainForm(family.id);
            }
        }

        private void btnUpdateFamily_Click(object sender, EventArgs e)
        {
            UpdateFamilyDialog update = new UpdateFamilyDialog(family);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                FetchData();
            }
        }

        private void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            DeleteFamilyDialog delete = new DeleteFamilyDialog(family);

            if (delete.ShowDialog(this) == DialogResult.OK)
            {
                MainForm mainForm = ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamiliesMainForm();
                }
            }
        }


        #region HUSBAND
        private void btnViewHusband_Click(object sender, EventArgs e)
        {
            ViewParentDetailsDialog view = new ViewParentDetailsDialog(husband);

            view.ShowDialog(this);
        }

        private void btnUpdateHusband_Click(object sender, EventArgs e)
        {
            UpdateParentDialog update = new UpdateParentDialog(husband);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                FetchData();
            }
        }
        #endregion HUSBAND


        #region WIFE
        private void btnViewWife_Click(object sender, EventArgs e)
        {
            ViewParentDetailsDialog view = new ViewParentDetailsDialog(wife);

            view.ShowDialog(this);
        }

        private void btnUpdateWife_Click(object sender, EventArgs e)
        {
            UpdateParentDialog update = new UpdateParentDialog(wife);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                FetchData();
            }
        }
        #endregion WIFE

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }



        #region USER_INTERFACE

        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void OnMouseUp()
        {
            dragging = false;
        }

        private void OnMouseMove()
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                MainForm mainScreen = this.ParentForm as MainForm;

                if (mainScreen != null)
                {
                    mainScreen.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            }
        }

        private void OnMouseDown()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;
        }
        #endregion DRAG_AND_DROP


        #region POP_UP
        private Panel popupPanel;
        private void SetupPopupPanel()
        {
            popupPanel = new Panel();
            popupPanel.Size = new Size(340, 100);
            popupPanel.BackColor = Color.Lavender;

            Label lblInfo = new Label
            {
                Text = SessionManager.CurrentUser.fullName,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = SessionManager.CurrentUser.username,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            string role = (SessionManager.CurrentUser.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
            Label lblInfo3 = new Label
            {
                Text = role,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo2.Bottom + 5)
            };

            popupPanel.Controls.Add(lblInfo);
            popupPanel.Controls.Add(lblInfo2);
            popupPanel.Controls.Add(lblInfo3);

            // Initially hide the panel
            popupPanel.Visible = false;
            this.Controls.Add(popupPanel);
        }

        private void TogglePopUp()
        {
            popupPanel.Visible = !popupPanel.Visible;

            var buttonLocation = btnCurrentUserInfo.PointToScreen(Point.Empty);
            popupPanel.Location = this.PointToClient(new Point(buttonLocation.X, buttonLocation.Y + btnCurrentUserInfo.Height));
            popupPanel.BringToFront();
        }

        private void HidePopUp()
        {
            popupPanel.Visible = false;
        }

        private void DashboardMainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (popupPanel.Visible)
            {
                Point clickLocation = this.PointToClient(Cursor.Position);

                if (!popupPanel.Bounds.Contains(clickLocation))
                {
                    popupPanel.Visible = false;
                }
            }
        }
        #endregion POP_UP


        #region PANEL_TITLE
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion PANEL_TITLE


        #region DESTINATION
        private void lblDestination_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblDestination_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblDestination_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion DESTINATION


        #region LABEL_CURRENT_USER
        private void lblCurrentUser_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblCurrentUser_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblCurrentUser_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_CURRENT_USER


        #region BUTTON_CURRENT_USER_INFO
        private void btnCurrentUserInfo_MouseHover(object sender, EventArgs e)
        {

            TogglePopUp();
        }

        private void btnCurrentUserInfo_MouseLeave(object sender, EventArgs e)
        {
            HidePopUp();
        }
        #endregion BUTTON_CURRENT_USER_INFO

        #endregion USER_INTERFACE
    }
}
