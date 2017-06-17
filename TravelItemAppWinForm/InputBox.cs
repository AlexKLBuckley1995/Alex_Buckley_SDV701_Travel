using System;
using System.Linq;
using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used when the user wants to create a new item allowing the user to enter either an M (for map) or B (for book), the appropriate 
    // form (either frmBookItem or frmMapItem) will be displayed depending on the users input into this InputBox

    public partial class InputBox : Form
    {
        private string _Answer;

        public InputBox(string question)
        {
            InitializeComponent();
            lblCategoryInput.Text = question;
            lblError.Text = "";
            txtItemCategory.Focus();
            ShowDialog();
        }

        private void btnOkCategory_Click(object sender, EventArgs e)
        {
            bool isIncomplete = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (isIncomplete)
            {
                lblError.Text = "Please enter a value";
            }
            else
            {
                _Answer = txtItemCategory.Text;
                DialogResult = DialogResult.OK;
            }
            
        }

        private void btnCancelCategory_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Answer
        {
            get { return _Answer; }
        }

        private void txtItemCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == 'M' || e.KeyChar == 'B');
        }
    }
}
