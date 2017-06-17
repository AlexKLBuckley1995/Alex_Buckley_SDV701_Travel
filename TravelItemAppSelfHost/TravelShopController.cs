using System;
using System.Collections.Generic;
using System.Data;

namespace TravelItemAppSelfHost
{

    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This class is where service calls are recieved, the call is processed with sql queries run against the database and the resulting datatable stored in either a List<object> or 
    // List<string> which are returned. 

    public class TravelShopController : System.Web.Http.ApiController
    {
        public List<string> GetLocationNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT LocationName FROM Location", null);
            List<string> lcLocationNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcLocationNames.Add((string)dr[0]);
            return lcLocationNames;
        }

        public clsLocation GetLocation(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
                clsDbConnection.GetDataTable("SELECT * FROM Location WHERE LocationName = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsLocation()
                {
                    LocationName = (string)lcResult.Rows[0]["LocationName"],
                    LocationDescription = (string)lcResult.Rows[0]["LocationDescription"],
                    LocationImage =  (Byte[])lcResult.Rows[0]["LocationImage"],
                    ItemsList = getLocationItems(Name),
                };
            else
                return null;
        }

        public List<clsAllItem> getLocationItems(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Item WHERE LocationName = @Name", par);
            List<clsAllItem> lcWorks = new List<clsAllItem>();
            foreach (DataRow dr in lcResult.Rows)
                lcWorks.Add(dataRow2AllItems(dr));
            return lcWorks;
        }
        public List<int> GetItemQuantity(int ItemID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ItemID", ItemID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT QuantityAvailable FROM Item WHERE ItemID=@ItemID", par);
            List<int> lcQuantityAvailable = new List<int>();
            foreach (DataRow dr in lcResult.Rows)
                lcQuantityAvailable.Add((int)dr[0]);
            return lcQuantityAvailable;
        }

        private clsAllItem dataRow2AllItems(DataRow prDataRow)
        {
            return new clsAllItem()
            {
                ItemID = Convert.ToInt16(prDataRow["ItemID"]),
                LocationName = Convert.ToString(prDataRow["LocationName"]),
                PublisherName = Convert.ToString(prDataRow["PublisherName"]),
                Name = Convert.ToString(prDataRow["Name"]),
                Price = Convert.ToDecimal(prDataRow["Price"]),
                LastModification = Convert.ToDateTime(prDataRow["LastModification"]),
                QuantityAvailable = Convert.ToInt16(prDataRow["QuantityAvailable"]),
                MapType = prDataRow["MapType"] is DBNull ? null : Convert.ToString(prDataRow["MapType"]),
                ItemDimensions = prDataRow["ItemDimensions"] is DBNull ? null : Convert.ToString(prDataRow["ItemDimensions"]),
                ISBNNumber = prDataRow["ISBNNumber"] is DBNull ? null : Convert.ToString(prDataRow["ISBNNumber"]),
                GuideWeight = prDataRow["GuideWeight"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["GuideWeight"]),
                Category = Convert.ToChar(prDataRow["Category"]),
            };
        }

        public string PutOrderItem(clsAllItem prItem)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE Item SET QuantityAvailable = @QuantityAvailable WHERE ItemID = @ItemID",
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "Order item successfully reduced";
                else
                    return "Unexpected order item reduction count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutItem(clsAllItem prItem)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE Item SET LocationName= @LocationName, PublisherName = @PublisherName, Name = @Name, Price = @Price, LastModification = @LastModification, QuantityAvailable = @QuantityAvailable, MapType = @MapType, ItemDimensions = @ItemDimensions, ISBNNumber = @ISBNNumber, GuideWeight = @GuideWeight, Category = @Category WHERE ItemID = @ItemID",
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One item updated";
                else
                    return "Unexpected item update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostItem(clsAllItem prItem)
        { 
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Item " + 
                    "(LocationName, PublisherName, Name, Price, LastModification, QuantityAvailable, MapType, ItemDimensions, ISBNNumber, GuideWeight, Category) " + 
                    "VALUES (@LocationName, @PublisherName, @Name, @Price, @LastModification, @QuantityAvailable, @MapType, @ItemDimensions, @ISBNNumber, @GuideWeight, @Category)", 
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One item inserted";
                else
                    return "Unexpected item insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteItem(int ItemID, string LocationName)
        { 
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM Item WHERE ItemID = @ItemID AND LocationName = @LocationName",
                prepareItemDeletionParameters(ItemID, LocationName));
                if (lcRecCount == 1)
                    return "One item deleted";
                else
                    return "Unexpected item deletion count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public clsOrder GetOrders()
        {
            return new clsOrder()
            { 
                OrderList = GetOrderItems(),
            };
        }

        public List<clsOrder> GetOrderItems()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM [Order]", null);
            List<clsOrder> lcOrder = new List<clsOrder>();
            foreach (DataRow dr in lcResult.Rows)
                lcOrder.Add(dataRow2AllOrders(dr));
            return lcOrder;
        }

       

        private clsOrder dataRow2AllOrders(DataRow prDataRow)
        {
            return new clsOrder()
            {
                OrderID = Convert.ToInt16(prDataRow["OrderID"]),
                ItemID = Convert.ToInt16(prDataRow["ItemID"]),
                FirstName = Convert.ToString(prDataRow["FirstName"]),
                Surname = Convert.ToString(prDataRow["Surname"]),
                CustomerEmail = Convert.ToString(prDataRow["CustomerEmail"]),
                QuantityPurchase = Convert.ToInt16(prDataRow["QuantityPurchase"]),
                ValueOfOrder = Convert.ToDecimal(prDataRow["ValueOfOrder"]),
                OrderDate = Convert.ToDateTime(prDataRow["OrderDate"]),
            };
        }

        private Dictionary<string, object> prepareItemDeletionParameters(int prItemID, string prLocationName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("ItemID", prItemID);
            par.Add("LocationName", prLocationName);
            return par;
        }

        private Dictionary<string, object> prepareItemParameters(clsAllItem prItem)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("ItemID", prItem.ItemID);
            par.Add("LocationName", prItem.LocationName);
            par.Add("PublisherName", prItem.PublisherName);
            par.Add("Name", prItem.Name);
            par.Add("Price", prItem.Price);
            par.Add("LastModification", prItem.LastModification);
            par.Add("QuantityAvailable", prItem.QuantityAvailable);
            par.Add("MapType", prItem.MapType);
            par.Add("ItemDimensions", prItem.ItemDimensions);
            par.Add("ISBNNumber", prItem.ISBNNumber);
            par.Add("GuideWeight", prItem.GuideWeight);
            par.Add("Category", prItem.Category);
            return par;
        }

        public string PostOrder(clsOrder prOrder)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO [Order] " +
                    "(ItemID, FirstName, Surname, CustomerEmail, QuantityPurchase, ValueOfOrder, OrderDate) " +
                    "VALUES (@ItemID, @FirstName, @Surname, @CustomerEmail, @QuantityPurchase, @ValueOfOrder, @OrderDate)",
                    prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "One order inserted";
                else
                    return "Unexpected order insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("ItemID", prOrder.ItemID);
            par.Add("FirstName", prOrder.FirstName);
            par.Add("Surname", prOrder.Surname);
            par.Add("CustomerEmail", prOrder.CustomerEmail);
            par.Add("QuantityPurchase", prOrder.QuantityPurchase);
            par.Add("ValueOfOrder", prOrder.ValueOfOrder);
            par.Add("OrderDate", prOrder.OrderDate);
            return par;
        }

        public string DeleteOrder(int ItemID, string FirstName)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM [Order] WHERE ItemID = @ItemID AND FirstName = @FirstName",
                prepareOrderDeletionParameters(ItemID, FirstName));
                if (lcRecCount == 1)
                    return "One order deleted";
                else
                    return "Unexpected order deletion count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareOrderDeletionParameters(int prItemID, string prFirstName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("ItemID", prItemID);
            par.Add("FirstName", prFirstName);
            return par;
        }
    }
}
