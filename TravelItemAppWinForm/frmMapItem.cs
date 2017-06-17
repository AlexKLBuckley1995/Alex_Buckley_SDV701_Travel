namespace TravelItemAppWinForm
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This form is used for the user to edit or add new maps. It inherits from frmItem.

    public sealed partial class frmMapItem : TravelItemAppWinForm.frmItem
    {
        private static readonly frmMapItem Instance = new frmMapItem();

        public frmMapItem()
        {
            InitializeComponent();
        }

        public static void Run(clsAllItem prMap)
        {
            Instance.SetDetails(prMap);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtMapDimensions.Text = _Item.ItemDimensions;
            txtMapType.Text = _Item.MapType;   
        }

        protected override void pushData()
        {
            base.pushData();
            _Item.ItemDimensions = txtMapDimensions.Text;
            _Item.MapType = txtMapType.Text;
        }
    }
}
