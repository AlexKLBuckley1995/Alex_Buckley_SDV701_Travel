using System.Windows.Forms;

namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used for the user to edit or add new books. It inherits from frmItem.  

    public sealed partial class frmBookItem : TravelItemAppWinForm.frmItem
    {
        private static readonly frmBookItem Instance = new frmBookItem();
        public frmBookItem()
        {
            InitializeComponent();
        }

        public static void Run(clsAllItem prBook)
        {
            Instance.SetDetails(prBook);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtBookWeight.Text = _Item.GuideWeight.ToString();
            txtISBNNumber.Text = _Item.ISBNNumber;
        }

        protected override void pushData()
        {
            base.pushData();
            _Item.GuideWeight = float.Parse(txtBookWeight.Text);
            _Item.ISBNNumber = txtISBNNumber.Text;
        }

        private void txtBookWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar =='.' || e.KeyChar == (char)Keys.Back);
        }
    }
}

