using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TravelItemAppWinForm
{

    // Author: Alex Buckley
    // Date: 16/06/2017
    // Summary: This class is the interface to the server, so the winform can call and receive from database queries in the TravelShopController 

    public static class ServiceClient
    {
        internal async static Task<List<string>> GetLocationNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/TravelShop/GetLocationNames/"));
        }

        internal async static Task<clsLocation> GetLocationAsync(string prName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsLocation>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/TravelShop/GetLocation?Name=" + prName));
        }

        internal async static Task<string> InsertItemAsync(clsAllItem prItem)
        {
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/TravelShop/PostItem", "POST");
        }

        internal async static Task<string> UpdateItemAsync(clsAllItem prItem)
        {
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/TravelShop/PutItem", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> DeleteItemAsync(clsAllItem prItem)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/TravelShop/DeleteItem?ItemID={prItem.ItemID}&LocationName={prItem.LocationName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<clsOrder> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/TravelShop/GetOrders/"));
        }

        internal async static Task<string> DeleteOrderAsync(clsOrder prOrder)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/TravelShop/DeleteOrder?ItemID={prOrder.ItemID}&FirstName={prOrder.FirstName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<List<int>> GetItemQuantityAsync(int prItemID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<int>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/TravelShop/GetItemQuantity?ItemID=" + prItemID));
        }
    }
}
