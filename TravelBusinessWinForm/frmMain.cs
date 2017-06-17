using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    public sealed partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        public frmMain()
        {
            InitializeComponent();
        }

        async public void UpdateDisplay()
        {
            try
            {
                lstItemType.DataSource = null;
                lstItemType.DataSource = await ServiceClient.GetLocationNamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not update");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
    }
}
