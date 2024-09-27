using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Children.Controls;
using FamilySprout.Features.Children.DB;
using FamilySprout.Features.Children.Dialog;
using FamilySprout.Features.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Children
{
    public partial class ChildrenMainForm : Form
    {
        private List<ChildModel> children = new List<ChildModel>();
        private long famId;
        public ChildrenMainForm(long famId)
        {
            InitializeComponent();
            SetupPopupPanel();

            this.famId = famId;
            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;

            // user role check
            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                btnNewChild.Visible = false;
                lblNotice.Visible = true;
            }

            FetchChildren();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyDetailsMainForm(famId);
            }
        }

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }


        #region GET_ALL_CHILDRENS
        public void FetchChildren()
        {
            children.Clear();
            children = DBChildren.GetAllChildren(famId);
            listPanel.Controls.Clear();
            listPanel.AutoScroll = true;
            int currentY = 10;

            if (children.Count == 0)
            {
                Label label = new Label();
                label.Text = "No children found!";
                label.Font = new Font("Courier New", 14, FontStyle.Bold);
                label.AutoSize = true;

                // Calculate the position to ensure a 20-pixel padding on each side
                int labelWidth = label.Width;
                int labelHeight = label.Height;

                int panelWidth = listPanel.ClientSize.Width;
                int panelHeight = listPanel.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                listPanel.Controls.Add(label);
            }
            else
            {
                foreach (var child in children)
                {
                    ChildUserControl childUserControl = new ChildUserControl(child);

                    childUserControl.Location = new Point(10, currentY);
                    childUserControl.Width = listPanel.ClientSize.Width - 20;
                    childUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    listPanel.Controls.Add(childUserControl);
                    currentY += childUserControl.Height + 10;
                }
            }
        }
        #endregion GET_ALL_CHILDRENS

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildDialog newChild = new NewChildDialog(famId);

            if (newChild.ShowDialog(this) == DialogResult.OK)
            {
                FetchChildren();
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
