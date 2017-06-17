using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used for the user to view all orders, and if neccessary delete any of them. 

    public partial class frmPendingOrders : Form
    {
        private clsOrder _Order;

        public frmPendingOrders()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmPendingOrders_Load(object sender, EventArgs e)
        {
            refreshFormFromDB();
        }

        private async void refreshFormFromDB()
        {
            try
            {
                UpdateDisplay(await ServiceClient.GetOrdersAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmPendingOrders could not be updated");
            }
        }

        public void UpdateDisplay(clsOrder prOrder)
        {
            _Order = prOrder;
            decimal lcTotalOrderValue = _Order.OrderList.Select(_Order => _Order.ValueOfOrder).Sum();
            lblValueAmount.Text = "$" + lcTotalOrderValue.ToString();
            lstOrders.DataSource = null;
            if (_Order.OrderList != null)
                lstOrders.DataSource = _Order.OrderList;
        }

        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int lcIndex = lstOrders.SelectedIndex;

                if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lstOrders.SelectedItem as clsOrder));
                    refreshFormFromDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
