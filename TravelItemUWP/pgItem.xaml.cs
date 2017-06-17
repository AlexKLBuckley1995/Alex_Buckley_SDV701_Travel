using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace TravelItemUWP
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This page displays details of the item and lets the user place an order. It contains an embedded user controller, and polymorphism 
    // is used to display the item specific information to the user (e.g. map details such as map type, and item dimensions). 
    // This page uses input validation; only allowing the user to enter numbers into the quantity field for the order to be placed, and 
    // forcing the user to fill in all four fields. 

    // The updated availability of the item is retrieved from the database when the user clicks the btnItemOrder so it is up to date if another
    // user bought all the remaining stock of that item between the current user opening this page and clicking the btnItemOrder.

    // If a user tries to purchase more stock than is available then a message informing there is insufficient stock available is displayed. 
       
    public sealed partial class pgItem : Page
    {
        private clsAllItem _Item;
        private clsLocation _Location;
        private clsAllItem _UpdatedItem;
        private clsOrder _Order;

        public pgItem()
        {
            this.InitializeComponent();
            _ItemContent = new Dictionary<char, Delegate>
            {
                { 'M', new LoadWorkControlDelegate(RunMap) },
                { 'B', new LoadWorkControlDelegate(RunBook) }
            };
        }

        private void btnItemCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void updatePage(clsAllItem prItem)
        {
            _Item = prItem;
            txbItemName.Text = _Item.Name;
            txbItemPriceValue.Text = _Item.Price.ToString();
            txbItemBrandValue.Text = _Item.PublisherName.ToString();
            (ctcItemSpecs.Content as IItemControl).UpdateControl(prItem);
        }

        private void pushData(clsAllItem prUpdatedItem)
        {
            try
            {
                _Order = new clsOrder();
                _Order.QuantityPurchase = int.Parse(txtOrderQuantity.Text);
                _Order.FirstName = txtFirstName.Text;
                _Order.Surname = txtSurname.Text;
                _Order.CustomerEmail = txtEmailAddress.Text;
                _Order.OrderDate = DateTime.Today;
                _Order.ItemID = _Item.ItemID;
                _Order.ValueOfOrder = _Item.Price;
                reduceItemQuantity(prUpdatedItem);
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        private void RunMap(clsAllItem prItem)
        {
            ctcItemSpecs.Content = new ucMap();
        }

        private void RunBook(clsAllItem prItem)
        {
            ctcItemSpecs.Content = new ucBook();
        }

        private delegate void LoadWorkControlDelegate(clsAllItem prItem);
        private Dictionary<char, Delegate> _ItemContent;
        private void dispatchItemContent(clsAllItem prItem)
        {
            _ItemContent[prItem.Category].DynamicInvoke(prItem);
            updatePage(prItem);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dispatchItemContent(e.Parameter as clsAllItem);
        }

        private async void btnItemOrder_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            string inputtedQuantity = txtOrderQuantity.Text;
            if ((regex.IsMatch(inputtedQuantity)) && txtFirstName.Text != "" && txtSurname.Text != "" && txtEmailAddress.Text != "")
            {
                _Location = new clsLocation();
                _Location = await ServiceClient.GetLocationAsync(_Item.LocationName);
                _UpdatedItem = new clsAllItem();
                _UpdatedItem = _Location.ItemsList.SingleOrDefault(x => x.ItemID == _Item.ItemID);
                pushData(_UpdatedItem);
            }
            else
            {
                txbMessage.Text = "Please enter a number in the quantity field and/or fill in all fields";
            }
        }

        private async void reduceItemQuantity(clsAllItem prUpdatedItem)
        {
            try
            {
                int lcNewItemStock = prUpdatedItem.QuantityAvailable - _Order.QuantityPurchase;
                if ( lcNewItemStock >= 0)
                {
                    _Item.QuantityAvailable = lcNewItemStock;
                    txbMessage.Text += await ServiceClient.UpdateOrderItemAsync(_Item);
                    placeOrder();
                } else
                {
                    txbMessage.Text = "There is insufficient stock available for your order. Please enter a quantity for purchase less than " + _Item.QuantityAvailable;
                }              
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        private async void placeOrder()
        {
            try
            {
                txbMessage.Text += await ServiceClient.InsertOrderAsync(_Order);
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }
    }
}
