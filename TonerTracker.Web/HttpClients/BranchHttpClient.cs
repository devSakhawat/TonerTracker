using Newtonsoft.Json;
using System.Text;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;

namespace TonerTracker.Web.HttpClients
{
   public class BranchHttpClient
   {
  
      private readonly string baseApi = "https://localhost:7252/toner-tracker/";
      private readonly HttpClient client;

      #region Constructor
      public BranchHttpClient(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region CreateBranch
      public async Task<Branch> CreateBranch(Branch model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"{baseApi}branch", content);
         if (!response.IsSuccessStatusCode)
            return new Branch();
         var result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<Branch>(result);
         return branch;
      }
      #endregion CreateBranch

      #region ReadBranches
      public async Task<List<Branch>> ReadBranches()
      {
         var response = await client.GetAsync($"{baseApi}branches");
         if (!response.IsSuccessStatusCode)
            return new List<Branch>();
         var result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<List<Branch>>(result);
         List<Branch> branches = new List<Branch>(branch.ToList());
         return branches;
      }
      #endregion  ReadBranches

      #region ReadBranchByKey
      public async Task<Branch> ReadBranchByKey(int id)
      {
         var response = await client.GetAsync($"{baseApi}branch/key/" + id + "");
         if (!response.IsSuccessStatusCode)
            return new Branch();
         var result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<Branch>(result);
         return branch;
      }
      #endregion ReadBranchByKey

      #region UpdateBranch
      public async Task<Branch> UpdateBranch(Branch model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PutAsync($"{baseApi}branch/" + model.ID, content);
         if (!response.IsSuccessStatusCode)
            return new Branch();
         string result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<Branch>(result);
         return branch;
      }
      #endregion UpdateBranch

      #region DeleteBranch
      public async Task<Branch> DeleteBranch(Branch model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PatchAsync($"{baseApi}branch/" + model.ID, content);
         if (!response.IsSuccessStatusCode)
            return new Branch();
         string result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<Branch>(result);
         return branch;
      }
      #endregion DeleteBranch

      #region BranchesByCompanyID
      public async Task<List<Branch>> BranchesByCompanyID(int companyId)
      {
         //var response = await client.GetAsync($"{baseApi}branches/company/" + companyId + "");
         var response = await client.GetAsync($"{baseApi}branches/company/" + companyId);

         if (!response.IsSuccessStatusCode)
            return new List<Branch>();

         string result = await response.Content.ReadAsStringAsync();
         var branch = JsonConvert.DeserializeObject<List<Branch>>(result);
         List<Branch> branches = new List<Branch>(branch.ToList());
         return branches;
      }
      #endregion BranchesByCompanyID
   }
}
