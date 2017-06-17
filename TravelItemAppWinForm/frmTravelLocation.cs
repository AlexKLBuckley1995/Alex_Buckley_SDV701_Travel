using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used for the user to display all items associated with a particular travel location. 
    // A database driven media component has been implemented because the varbinary value in the LocationImage field in the database
    // is retrieved in the GetLocation() function in TravelShopController and returned to this winform application to be deserialized and 
    // displayed on this form as an image of the location. 

    public partial class frmTravelLocation : Form
    {
        private clsLocation _Location;
        private static Dictionary<string, frmTravelLocation> _TravelLocationFormList = new Dictionary<string, frmTravelLocation>();

        public frmTravelLocation()
        {
            InitializeComponent();
        }

        public static void Run(string prName)
        {
            try
            {
                frmTravelLocation lcTravelLocationForm;
                if (string.IsNullOrEmpty(prName) ||
                        !_TravelLocationFormList.TryGetValue(prName, out lcTravelLocationForm))
                {
                    lcTravelLocationForm = new frmTravelLocation();
                    if (string.IsNullOrEmpty(prName))
                        lcTravelLocationForm.SetDetails(new clsLocation());
                    else
                    {
                        _TravelLocationFormList.Add(prName, lcTravelLocationForm);
                        lcTravelLocationForm.refreshFormFromDB(prName);
                    }
                }
                else
                {
                    lcTravelLocationForm.Show();
                    lcTravelLocationForm.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        async private void refreshFormFromDB(string prName)
        {
            SetDetails(await ServiceClient.GetLocationAsync(prName));
        }

        public void SetDetails(clsLocation prLocation)
        {
            _Location = prLocation;
            UpdateForm();
            UpdateDisplay();
            Show();
        }

        public void UpdateForm()
        {
            lblLocationName.Text = _Location.LocationName;
            lblLocationDescriptionValue.Text = _Location.LocationDescription;
            Image LocationImage = (Bitmap)((new ImageConverter()).ConvertFrom(_Location.LocationImage));
            pbLocation.Image = LocationImage;
        }

        private void UpdateDisplay()
        {
            lstLocationItems.DataSource = null;
            if (_Location.ItemsList != null)
                lstLocationItems.DataSource = _Location.ItemsList;
        }

        private void lstLocationItems_DoubleClick(object sender, EventArgs e)
        {
            frmItem.DispatchItemForm(lstLocationItems.SelectedValue as clsAllItem);
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
          try
            {
                string lcReply = new InputBox(clsAllItem.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply))
                {
                    clsAllItem lcItem = clsAllItem.NewItem(lcReply[0], _Location.LocationName); //Parameterising both the category (either B or M) and LocationName (foreign key) to place in new clsAllItem
                    if (lcItem != null) 
                    {
                        frmItem.DispatchItemForm(lcItem);
                        if (!string.IsNullOrEmpty(lcItem.Name)) 
                        {
                            refreshFormFromDB(_Location.LocationName);
                            UpdateDisplay();
                        }
                    } else
                    {
                        MessageBox.Show("Please only enter an M or B");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            int lcIndex = lstLocationItems.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteItemAsync(lstLocationItems.SelectedItem as clsAllItem));
                refreshFormFromDB(_Location.LocationName);
                UpdateDisplay();
            }
        }

        private void btnCategoryClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
