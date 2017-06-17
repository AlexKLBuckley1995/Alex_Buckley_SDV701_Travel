using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace TravelItemUWP
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This page displays all the items associated with a particular location. 

    public sealed partial class pgTravelLocation : Page
    {
        private clsLocation _Location;

        public pgTravelLocation()
        {
            this.InitializeComponent();
        }

        private void UpdateDisplay()
        {

            txbLocationName.Text = _Location.LocationName;
            txbLocationDescription.Text = _Location.LocationDescription;
            lstLocationItems.ItemsSource = null;
            if (_Location.ItemsList != null)
                lstLocationItems.ItemsSource = _Location.ItemsList;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                if (e.Parameter != null)
                {
                    string lcName = e.Parameter.ToString();
                    _Location = await ServiceClient.GetLocationAsync(lcName);
                    UpdateDisplay();
                }
                else 
                    _Location = new clsLocation();
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        private void lstLocationItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editItem(lstLocationItems.SelectedItem as clsAllItem);
        }

        private void editItem(clsAllItem prItem)
        {
            if (prItem != null)
                Frame.Navigate(typeof(pgItem), prItem);
        }
    }
}
