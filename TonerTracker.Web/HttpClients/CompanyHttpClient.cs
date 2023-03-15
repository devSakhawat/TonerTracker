using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using static System.Net.WebRequestMethods;

namespace TonerTracker.Web.HttpClients
{
   public class CompanyHttpClient
   {
      private readonly string baseApi = "https://localhost:7252/toner-tracker/";
      private readonly HttpClient client;

      #region Constructor
      public CompanyHttpClient(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region CreateCompany
      public async Task<Company> CreateCompany(Company model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PostAsync($"{baseApi}company", content);

         if (!response.IsSuccessStatusCode)
            return new Company();
         string result = await response.Content.ReadAsStringAsync();
         var company = JsonConvert.DeserializeObject<Company>(result);
         return company;
      }
      #endregion CreateCompany

      #region ReadCompanies
      public async Task<List<Company>> ReadCompanies()
      {
         var response = await client.GetAsync($"{baseApi}companies");
         if (!response.IsSuccessStatusCode)
            return new List<Company>();
         var result = await response.Content.ReadAsStringAsync();
         var company = JsonConvert.DeserializeObject<List<Company>>(result);
         List<Company> companies = new List<Company>(company.ToList());
         return companies;
      }
      #endregion ReadCompanies

      #region ReadCompanyByKey
      public async Task<Company> ReadCompanyByKey(int id)
      {
         var response = await client.GetAsync($"{baseApi}company/key/" + id + "");
         if (!response.IsSuccessStatusCode)
            return new Company();
         var result = await response.Content.ReadAsStringAsync();
         var company = JsonConvert.DeserializeObject<Company>(result);
         return company;
      }
      #endregion ReadCompanyByKey

      #region UpdateCompany
      public async Task<Company> UpdateCompany(Company model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PutAsync($"{baseApi}company/" + model.ID, content);

         if (response.ReasonPhrase == "BadRequest" || !response.IsSuccessStatusCode)
            return new Company();

         var result = await response.Content.ReadAsStringAsync();
         var company = JsonConvert.DeserializeObject<Company>(result);
         return company;
      }
      #endregion UpdateCompany

      #region DeleteCompany
      public async Task<Company> DeleteCompany(Company model)
      {
         var data = JsonConvert.SerializeObject(model);
         var content = new StringContent(data, Encoding.UTF8, "application/json");
         var response = await client.PatchAsync($"{baseApi}company/" + model.ID, content);

         if (!response.IsSuccessStatusCode)
            return new Company();

         var result = await response.Content.ReadAsStringAsync();
         var company = JsonConvert.DeserializeObject<Company>(result);
         return company;
      }
      #endregion DeleteCompany
   }
}
