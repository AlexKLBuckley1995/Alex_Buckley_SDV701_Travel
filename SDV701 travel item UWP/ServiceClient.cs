using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SDV701_travel_item_UWP
{
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
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
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
    }
}
