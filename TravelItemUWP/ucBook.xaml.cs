using System;
using Windows.UI.Xaml.Controls;


namespace TravelItemUWP
{

    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This user control contains all item information specific to books to be displayed polymorhphically when the user views a book
    // in pgItem

    public sealed partial class ucBook : UserControl, IItemControl
    {
        public ucBook()
        {
            this.InitializeComponent();
        }

        public void PushData(clsAllItem prItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateControl(clsAllItem prItem)
        {
            txbWeightValue.Text = prItem.GuideWeight.ToString();
            txbISBNValue.Text = prItem.ISBNNumber;
        }
    }
}
