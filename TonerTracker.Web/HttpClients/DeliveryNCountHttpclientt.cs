using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;
using System.Text;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Web.HttpClients
{
   public class DeliveryNCountHttpclientt
   {
      private readonly string baseApi = "https://localhost:7252/toner-tracker/";
      private readonly HttpClient client;

      #region Constructor
      public DeliveryNCountHttpclientt(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region DeliveryNCountSideMenu
      public async Task<List<SideMenuCompany>> DeliveryNCountSideMenu()
      {
         var response = await client.GetAsync($"{baseApi}deliveries-counts");

         if(!response.IsSuccessStatusCode)
            return new List<SideMenuCompany>();
         string result = await response.Content.ReadAsStringAsync();
         var sidebarMenuCompany = JsonConvert.DeserializeObject<List<SideMenuCompany>>(result);
         List<SideMenuCompany> sidebarMenuCompanies = new List<SideMenuCompany>(sidebarMenuCompany.ToList());
         return sidebarMenuCompanies;
      }
      #endregion DeliveryNCountSideMenu

      #region CreateTonerDelivery
      public async Task<DeliveryNCountDto> CreateTonerDelivery(DeliveryNCountDto model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"{baseApi}toner-delivery", content);

         if (response.ReasonPhrase == "Conflict")
         {
            return new DeliveryNCountDto
            {
               TonerErrorMessage = MessageConstants.DuplicateError
            };
         }
         if (!response.IsSuccessStatusCode)
         {
            return new DeliveryNCountDto();
         }

         string result = await response.Content.ReadAsStringAsync();
         var deliveryNCount = JsonConvert.DeserializeObject<DeliveryNCountDto>(result);
         return deliveryNCount;
      }
      #endregion CreateDeliveryNCount

      #region TonerDeliveryByMachineId
      public async Task<List<TonerDelivery>> TonerDevliveriesByMachineId(int machineId)
      {
         var response = await client.GetAsync($"{baseApi}toner-delivery/machine/" + machineId);

         if (!response.IsSuccessStatusCode)
            return new List<TonerDelivery>();

         string result = await response.Content.ReadAsStringAsync();
         var tonerDelivery = JsonConvert.DeserializeObject<List<TonerDelivery>>(result);
         List<TonerDelivery> tonerDeliveries = new List<TonerDelivery>(tonerDelivery.ToList());
         return tonerDeliveries;
      }
      #endregion TonerDeliveryByMachineId

      #region PaperCountByMachineId
      public async Task<List<PaperCount>> PaperCountByMachineId(int machineId)
      {
         var response = await client.GetAsync($"{baseApi}paper-count/machine/" + machineId);

         if (!response.IsSuccessStatusCode)
            return new List<PaperCount>();

         string result = await response.Content.ReadAsStringAsync();
         var paperCount = JsonConvert.DeserializeObject<List<PaperCount>>(result);
         List<PaperCount> paperCounts = new List<PaperCount>(paperCount.ToList());
         return paperCounts;
      }
      #endregion PaperCountByMachineId
   }
}
