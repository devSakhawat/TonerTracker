using Newtonsoft.Json;
using System.Text;
using TonerTracker.Domain.Entity;

namespace TonerTracker.Web.HttpClients
{
   public class TonerDeliveryHttpClient
   {
      private readonly string baseApi = "https://localhost:7252/toner-tracker/";
      private readonly HttpClient client;
      #region Constructor
      public TonerDeliveryHttpClient(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region CreateTonerDelivery
      public async Task<TonerDelivery> CreateTonerDelivery(TonerDelivery model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"{baseApi}toner-delivery", content);

         if (!response.IsSuccessStatusCode)
            return new TonerDelivery();
         string reuslt = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<TonerDelivery>(reuslt);
         return machine;
      }
      #endregion CreateTonerDelivery

      #region ReadTonerDeliveries
      public async Task<List<TonerDelivery>> ReadTonerDeliveries()
      {
         var response = await client.GetAsync($"{baseApi}toner-deliveries");
         if (!response.IsSuccessStatusCode)
            return new List<TonerDelivery>();

         string result = await response.Content.ReadAsStringAsync();
         var tonerDelivery = JsonConvert.DeserializeObject<List<TonerDelivery>>(result);
         List<TonerDelivery> tonerDeliveries = new List<TonerDelivery>(tonerDelivery.ToList());
         return tonerDeliveries;
      }
      #endregion ReadTonerDeliveries

      #region ReadTonerDeliveryByKey
      public async Task<Machine> ReadTonerDeliveryByKey(int id)
      {
         var response = await client.GetAsync($"{baseApi}toner-delivery/key/" + id + "");

         if(!response.IsSuccessStatusCode)
            return new Machine();

         string result = await response.Content.ReadAsStringAsync();
         var tonerDelivery = JsonConvert.DeserializeObject<Machine>(result);
         return tonerDelivery;
      }
      #endregion ReadTonerDeliveryByKey

      #region UpdateTonerDelivery
      public async Task<TonerDelivery> UpdateTonerDelivery(TonerDelivery model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PutAsync($"{baseApi}toner-delivery/" + model.ID, content);

         if (!response.IsSuccessStatusCode)
            return new TonerDelivery();

         string result = await response.Content.ReadAsStringAsync();
         var tonerDelivery = JsonConvert.DeserializeObject<TonerDelivery>(result);
         return tonerDelivery;
      }
      #endregion UpdateTonerDelivery

      #region DeleteTonerDelivery
      public async Task<TonerDelivery> DeleteTonerDelivery(TonerDelivery model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PatchAsync($"{baseApi}toner-delivery/" + model.ID, content);

         if (!response.IsSuccessStatusCode)
            return new TonerDelivery();

        string result = await response.Content.ReadAsStringAsync();
         var tonerDelivery = JsonConvert.DeserializeObject<TonerDelivery>(result);
         return tonerDelivery;
      }
      #endregion DeleteTonerDelivery
   }
}
