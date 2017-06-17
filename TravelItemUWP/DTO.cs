using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelItemUWP
{
    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This class is where objects (clsLocation, clsAllItem, clsOrder) are declared so that Lists of these objects can be returned by the 
    // TravelShopController to this tier of the application 


    public class clsLocation
    {
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public List<clsAllItem> ItemsList { get; set; }
    }

    public class clsAllItem
    {
        public int ItemID { get; set; }
        public string LocationName { get; set; }
        public string Name { get; set; }
        public string PublisherName { get; set; }
        public decimal Price { get; set; }
        public DateTime LastModification { get; set; }
        public int QuantityAvailable { get; set; }
        public string MapType { get; set; }
        public string ItemDimensions { get; set; }
        public string ISBNNumber { get; set; }
        public float? GuideWeight { get; set; }
        public char Category { get; set; }

        public static readonly string FACTORY_PROMPT = "Enter M for map and B for book";

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
            return OrderID + "\t" +  FirstName + Surname + "\t" + CustomerEmail + "\t" + ItemID + "\t" + QuantityPurchase + "\t" + ValueOfOrder + "\t" + OrderDate;
        }
    }
}
