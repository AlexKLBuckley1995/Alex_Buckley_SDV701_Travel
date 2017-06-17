using System;
using Windows.UI.Xaml.Controls;


namespace TravelItemUWP
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This user control contains all item information specific to maps to be displayed polymorhphically when the user views a map
    // in pgItem

    public sealed partial class ucMap : UserControl, IItemControl
    {
        public ucMap()
        {
            this.InitializeComponent();
        }

        public void PushData(clsAllItem prItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateControl(clsAllItem prItem)
        {
            txbMapDimensionValue.Text = prItem.ItemDimensions;
            txbMapTypeValue.Text = prItem.MapType;
        }
    }
}
