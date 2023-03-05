using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;
using TonerTracker.Web.HttpClients;

namespace TonerTracker.Web.Controllers
{
   public class CompanyController : Controller
   {
      private readonly HttpClient client;
      #region Constructor
      public CompanyController(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region Create
      [HttpGet]
      public IActionResult Create()
      {
         return View(new CompanyDto());
      }

      [ValidateAntiForgeryToken]
      [HttpPost]
      public async Task<IActionResult> Create(CompanyDto model)
      {
         if (ModelState.IsValid)
         {
            var company = await new CompanyHttpClient(client).CreateCompany(model);

            if (company.ID == 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.DuplicateError;
               return View(model);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordSaved;
               return RedirectToAction(nameof(Index));
            }
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.ModelStateInvalid;
            return View();
         }
      }
      #endregion Create

      #region Index
      public async Task<IActionResult> Index()
      {
         try
         {
            var companies = await new CompanyHttpClient(client).ReadCompanies();

            if(companies.Count() == 0 || companies == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.NoRecordError;
               return View(companies);
            }

            return View(companies);
         }
         catch (Exception ex)
         {
            TempData[SessionConstant.Message] = ex.Message.ToString();
            return View();
         }
      }
      #endregion Index

      #region Update
      [HttpGet]
      public async Task<IActionResult> Update(int id)
      {
         if (id == 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return View();
         }

         var company = await new CompanyHttpClient(client).ReadCompanyByKey(id);

         if (company.ID == 0 || company == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return View();
         }
         else
         {
            return View(company);
         }
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Update(CompanyDto model)
      {
         if(ModelState.IsValid)
         {
            var company = await new CompanyHttpClient(client).UpdateCompany(model);

            if(company != null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordUpdateError;
               return View(company);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordUpdated;
               return View(model);
            }
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.ModelStateInvalid;
            return RedirectToAction(nameof(Index));
         }
      }
      #endregion Update

      #region Delete
      [HttpGet]
      public async Task<IActionResult> Delete(int id)
      {
         try
         {
            if(id == 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
               return View();
            }

            var company = await new CompanyHttpClient(client).ReadCompanyByKey(id);

            if(company.ID == 0 || company == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
               return RedirectToAction(nameof(Index));
            }
            return View(company);
         }
         catch (Exception ex)
         {
            TempData[SessionConstant.Message] = ex.Message.ToString();
            return View();
         }
      }

      [HttpPost]
      public async Task<IActionResult> Delete(CompanyDto model)
      {
         try
         {
            if(model.ID == 0 || model == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
               return RedirectToAction(nameof(Index));
            }

            var company = await new CompanyHttpClient(client).ReadCompanyByKey(model.ID);

            if (company.ID == 0 || company == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
               return RedirectToAction(nameof(Index));
            }

            var companyDel = await new CompanyHttpClient(client).DeleteCompany(company);

            if(companyDel.ID == 0 || company == companyDel)
            {
               TempData[SessionConstant.Message] = MessageConstants.IfDeleteReffereceRecord;
               return View(companyDel);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordDeleted;
               return RedirectToAction(nameof(Index));
            }

         }
         catch (Exception ex)
         {
            TempData[SessionConstant.Message] = ex.Message.ToString();
            return View();
         }
      }
      #endregion Delete

      #region Detail
      [HttpGet]
      public async Task<IActionResult> Detail(int id)
      {
         if(id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return RedirectToAction(nameof(Index));
         }

         var company = await new CompanyHttpClient(client).ReadCompanyByKey(id);

         if(company.ID == 0 || company == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return RedirectToAction(nameof(Index));
         }
         return View(company);
      }
      #endregion Detail
   }
}
