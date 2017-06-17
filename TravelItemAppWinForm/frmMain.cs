using System;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is the first form displayed of TravelItemAppWinForm application. It displays a list of travel location names for the user 
    // to double click on to see all items associated with the travel location. It also provides access to the pending orders if the user clicks the 
    // btnPendingOrders

    public sealed partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstLocations.DataSource = null;
                lstLocations.DataSource = await ServiceClient.GetLocationNamesAsync();        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmMain could not be updated");
            }
        }

        private void lstLocations_DoubleClick(object sender, EventArgs e)
        {
            frmTravelLocation.Run(lstLocations.SelectedItem as string);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPendingOrders_Click(object sender, EventArgs e)
        {
            frmPendingOrders lcPendingOrder;
            lcPendingOrder = new frmPendingOrders();
            lcPendingOrder.Show();
        }
    }
}
