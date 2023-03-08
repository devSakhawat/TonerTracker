using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;
using TonerTracker.Web.HttpClients;

namespace TonerTracker.Web.Controllers
{
   public class BranchController : Controller
   {
      private readonly HttpClient client;
      #region Constructor
      public BranchController(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region Create
      [HttpGet]
      public async Task<IActionResult> Create(int companyId)
      {
         var company = await new CompanyHttpClient(client).ReadCompanyByKey(companyId);
         ViewBag.CompanyName = company.CompanyName;
         ViewBag.CompanyId = companyId;
         //ViewData["CompanyID"] = new SelectList(await new CompanyHttpClient(client).ReadCompanies(), "ID", "CompanyName");
         return View(new BranchDto());
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(BranchDto model)
      {
         if (ModelState.IsValid)
         {
            var branch = await new BranchHttpClient(client).CreateBranch(model);

            if (branch.ID <= 0 || branch == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.DuplicateError;
               return View(model);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordSaved;
               return RedirectToAction("Index", new {companyId = branch.CompanyID});
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
      [HttpGet]
      public async Task<IActionResult> Index(int companyId)
      {
         try
         {
            if (companyId <= 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
               return RedirectToAction(nameof(Index));
            }

            //List<Branch> branches = await new BranchHttpClient(client).ReadBranches();
            List<Branch> branches = await new BranchHttpClient(client).BranchesByCompanyID(companyId);

            ViewBag.CompanyId = companyId;

            if(branches == null || branches.Count == 0)
            {
               //TempData[SessionConstant.Message] = MessageConstants.NoRecordError;
               TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
               return View(branches);
            }
            return View(branches);
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
         if (id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordUpdateError;
            return View();
         }

         var branch = await new BranchHttpClient(client).ReadBranchByKey(id);

         ViewData["CompanyID"] = new SelectList(await new CompanyHttpClient(client).ReadCompanies(), "ID", "CompanyName", branch.CompanyID);

         if(branch == null || branch.ID == 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordUpdateError;
            return View(branch);
         }
         return View(branch);
      }

      [HttpPost]
      public async Task<IActionResult> Update(Branch model)
      {
         if (ModelState.IsValid)
         {
            var branch = await new BranchHttpClient(client).UpdateBranch(model);
            if (branch != null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordUpdateError;
               return View();
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordUpdated;
               return RedirectToAction("Index", new { companyId = model.CompanyID });
            }
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.ModelStateInvalid;
            return View();
         }
      }
      #endregion Update

      #region Delete
      [HttpGet]
      public async Task<IActionResult> Delete(int id)
      {
         if (id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return View(nameof(Index));
         }

         var branch = await new BranchHttpClient(client).ReadBranchByKey(id);

         if(branch == null || branch.ID <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return RedirectToAction(nameof(Index));
         }
         return View(branch);
      }

      [HttpPost]
      public async Task<IActionResult> Delete(Branch model)
      {
         try
         {
            if (model == null || model.ID <= 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
               return View();
            }

            var branch = await new BranchHttpClient(client).ReadBranchByKey(model.ID);

            if (branch == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
               return View();
            }

            var delBranch = await new BranchHttpClient(client).DeleteBranch(branch);

            if (delBranch.ID == 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.IfDeleteReffereceRecord;
               return View();
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordDeleted;
               return RedirectToAction("Index", new { companyId = model.CompanyID});
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
         if(id <= 0 )
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }

         var branch = await new BranchHttpClient(client).ReadBranchByKey(id);

         if(branch.ID == 0 || branch == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return View();
         }
         return View(branch);
      }
      #endregion Detail

      //#region BranchesByCompanyID
      //[HttpGet]
      //public async Task<IActionResult> BranchesByCompanyID(int companyId)
      //{
      //   try
      //   {
      //      if (companyId <= 0)
      //      {
      //         TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
      //         return RedirectToAction(nameof(Index));
      //      }

      //      var companyBasedBranches = await new BranchHttpClient(client).BranchesByCompanyID(companyId);

      //      if(companyBasedBranches.Count() == 0 || companyBasedBranches == null)
      //      {
      //         TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
      //         return RedirectToAction(nameof(Index));
      //      }
      //      return View(companyBasedBranches);
      //   }
      //   catch (Exception ex)
      //   {
      //      TempData[SessionConstant.Message] = ex.Message.ToString();
      //      return View();
      //   }
      //}
      //#endregion BranchesByCompanyID
   }
}
