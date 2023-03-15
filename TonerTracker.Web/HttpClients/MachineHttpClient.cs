using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Web.HttpClients
{
   public class MachineHttpClient
   {
      private readonly HttpClient client;
      private readonly string baseApi = "https://localhost:7252/toner-tracker/";

      #region Constructor
      public MachineHttpClient(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region CreateMachine
      public async Task<Machine> CreateMachine(Machine model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"{baseApi}machine", content);

         //if (response.ReasonPhrase == "Conflict")
         //{
         //   Machine machineObj = new Machine
         //   {
         //      ErrorMessage = MessageConstants.DuplicateError
         //   };
         //   return machineObj;
         //}

         if (!response.IsSuccessStatusCode)
            return new Machine();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<Machine>(result);
         return machine;
      }
      #endregion CreateMachine

      #region ReadMachines
      public async Task<List<Machine>> ReadMachines()
      {
         var response = await client.GetAsync($"{baseApi}machines");

         if (!response.IsSuccessStatusCode)
            return new List<Machine>();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<List<Machine>>(result);
         List<Machine> machines = new List<Machine>(machine.ToList());
         return machines;
      }
      #endregion ReadMachines

      #region ReadMachineByKey
      public async Task<Machine> ReadMachineByKey(int id)
      {
         var response = await client.GetAsync($"{baseApi}machine/key/" + id + "");

         if (!response.IsSuccessStatusCode)
            return new Machine();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<Machine>(result);
         return machine;
      }
      #endregion ReadMachineByKey

      #region UpdateMachine
      public async Task<Machine> UpdateMachine(Machine model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PutAsync($"{baseApi}machine/" + model.ID, content);

         if (!response.IsSuccessStatusCode)
            return new Machine();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<Machine>(result);
         return machine;
      }
      #endregion UpdateMachine

      #region DeleteMachine
      public async Task<Machine> DeleteMachine(Machine model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PatchAsync($"{baseApi}machine/" + model.ID, content);

         if (!response.IsSuccessStatusCode)
            return new Machine();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<Machine>(result);
         return machine;
      }
      #endregion DeleteMachine

      #region MachinesByBranchId
      public async Task<List<Machine>> MachinesByBranchId(int branchId)
      {
         var response = await client.GetAsync($"{baseApi}machine/branch/" + branchId);

         if (!response.IsSuccessStatusCode)
            return new List<Machine>();

         string result = await response.Content.ReadAsStringAsync();
         var machine = JsonConvert.DeserializeObject<List<Machine>>(result);
         List<Machine> machines = new List<Machine>(machine.ToList());
         return machines;
      }
      #endregion MachinesByBranchId
   }
}