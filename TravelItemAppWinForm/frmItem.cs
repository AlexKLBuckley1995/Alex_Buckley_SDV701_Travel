using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used for the user to be able to edit/add items. 
    // It is overridden by the frmBookItem and frmMapItem who inherit from it. Whenever the user tries to create a item the name of the item
    // is compared against the other item names for the same location. If the name already exists then the item isn't created and 
    // a message appears giving the user the option to either amend their item or abandon creating the item. 

    public partial class frmItem : Form
    {
        protected clsAllItem _Item;
        protected clsLocation _Location;
        protected List<string> _ItemListNames;

        public frmItem()
        {
            InitializeComponent();
        }

        public void SetDetails(clsAllItem prItem)
        {
            _Item = prItem;
            updateForm();
            ShowDialog();
        }

        protected virtual void updateForm()
        {
            txtItemName.Text = _Item.Name;
            txtItemName.Enabled = string.IsNullOrEmpty(_Item.Name);
            txtItemBrand.Text = _Item.PublisherName;
            txtPrice.Text = _Item.Price.ToString();
            txtQuantityAvailable.Text = _Item.QuantityAvailable.ToString();
            lblDateModifiedValue.Text = _Item.LastModification.ToShortDateString();
        }

        protected virtual void pushData()
        {
            try
            {
                _Item.Name = txtItemName.Text;
                _Item.PublisherName = txtItemBrand.Text;
                _Item.Price = decimal.Parse(txtPrice.Text);
                _Item.QuantityAvailable = int.Parse(txtQuantityAvailable.Text);
                _Item.LastModification = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        public delegate void LoadItemFormDelegate(clsAllItem prItem);
        public static Dictionary<char, Delegate> _ItemsForm = new Dictionary<char, Delegate>
        {
            { 'M', new LoadItemFormDelegate(frmMapItem.Run) },
            { 'B', new LoadItemFormDelegate(frmBookItem.Run) },
        };
        public static void DispatchItemForm(clsAllItem prItem)
        {
            _ItemsForm[prItem.Category].DynamicInvoke(prItem);
        }

        private async void btnItemOk_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtItemName.Enabled)
                {
                    _Location = await ServiceClient.GetLocationAsync(_Item.LocationName);
                    checkIfItemExists(_Location);
                }
                else
                {
                    MessageBox.Show(await ServiceClient.UpdateItemAsync(_Item));
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter values for all inputboxes before creating the item");
            }
        }

        protected virtual bool isValid()
        {
            bool isIncomplete = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (isIncomplete)
            {
                return false;
            } else
            {
                return true;
            }  
        }

        protected virtual void checkIfItemExists(clsLocation prLocation)
        {   
            _ItemListNames = new List<string>();
            foreach (clsAllItem Item in prLocation.ItemsList)
            {
                _ItemListNames.Add(Item.Name);
            }
            getAllLocationItems();   
        }

        protected async void getAllLocationItems()
        {
            if (_ItemListNames.Contains(_Item.Name))
            {
                PreventDuplicateItem();
            }
            else
            {
                MessageBox.Show(await ServiceClient.InsertItemAsync(_Item));
                Close();
            }
        }

        protected void PreventDuplicateItem()
        {
            DialogResult result = MessageBox.Show("This is a duplicate item, click yes to amend it or no to abandon this item", "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void txtQuantityAvailable_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back);
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
