using System;
using System.Collections.Generic;

namespace TravelItemAppSelfHost
{

    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This class is where objects (clsLocation, clsAllItem, clsOrder) are declared so that Lists of these objects can be returned by the 
    // TravelShopController

    public class clsLocation
    {
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public Byte[] LocationImage { get; set; }
        public List<clsAllItem> ItemsList { get; set; }

    }

    public class clsOrder
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string CustomerEmail { get; set; }
        public int QuantityPurchase { get; set; }
        public decimal ValueOfOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public List<clsOrder> OrderList { get; set; }

        public override string ToString()
        {
            return OrderID + "\t" + FirstName + Surname + "\t" + CustomerEmail + "\t" + ItemID + "\t" + QuantityPurchase + "\t" + ValueOfOrder + "\t" + OrderDate;
        }
    }

    public class clsAllItem
    {
        public int ItemID;
        public string LocationName;
        public string Name;
        public string PublisherName;
        public decimal Price;
        public DateTime LastModification;
        public int QuantityAvailable;
        public string MapType;
        public string ItemDimensions;
        public string ISBNNumber;
        public float? GuideWeight;
        public char Category;

        public static clsAllItem NewItem(char prCategory, string prLocation)
        {
            switch (char.ToUpper(prCategory))
            {
                case 'M': return new clsAllItem { Category = 'M', LocationName = prLocation, LastModification = DateTime.Today };
                case 'B': return new clsAllItem { Category = 'B', LocationName = prLocation, LastModification = DateTime.Today };
                default: return null;
            }
        }

        public override string ToString()
        {
            return Name + "\t" + "\t" + "\t" + Category + "\t" + "\t" + "\t" + LocationName;
        }
    }
}
