using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace TravelItemUWP
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This page shows a list of locations for the user to click on to view all the items associated with that location in prTravelLocation. 

    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lstLocations.ItemsSource = await ServiceClient.GetLocationNamesAsync();
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        private void viewLocation()
        {
            if (lstLocations.SelectedItem != null)
                Frame.Navigate(typeof(pgTravelLocation), lstLocations.SelectedItem);
        }

        private void btnLocationView_Click(object sender, RoutedEventArgs e)
        {
            viewLocation();
        }

        private void lstLocations_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            viewLocation();
        }
    }
}
