using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;
using TonerTracker.Web.HttpClients;

namespace TonerTracker.Web.Controllers
{
   public class MachineController : Controller
   {
      private readonly HttpClient client;
      #region Constructor
      public MachineController(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region Create
      [HttpGet]
      public async Task<IActionResult> Create(int branchId)
      {
         if (branchId <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }
        
         var branch = await new BranchHttpClient(client).ReadBranchByKey(branchId);

         ViewBag.BranchName = branch.BranchName ;
         ViewBag.BranchId = branchId;

         return View(new MachineDto());
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(MachineDto model)
      {
         if (ModelState.IsValid)
         {
            var machine = await new MachineHttpClient(client).CreateMachine(model);


            if (machine.ErrorMessage != null)
            {
               TempData[SessionConstant.Message] = machine.ErrorMessage;
               return View(model);
            }
            else if (machine.ID == 0 || machine == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordInsert;
               return View(model);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordSaved;
               return RedirectToAction(nameof(Index), new {branchId = model.BranchID});
            }
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.ModelStateInvalid;
            return View(model);
         }
      }
      #endregion Create

      #region Index
      [HttpGet]
      public async Task<IActionResult> Index(int branchId)
      {
         if(branchId == 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }

         var branch = await new BranchHttpClient(client).ReadBranchByKey(branchId);
         ViewBag.CompanyId = branch.CompanyID;
         ViewBag.BranchId = branchId;

         List<Machine> machines = await new MachineHttpClient(client).MachinesByBranchId(branchId);

         if (machines.Count == 0 || machines == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return View(machines);
         }
         return View(machines);
      }
      #endregion

      #region Update
      [HttpGet]
      public async Task<IActionResult> Update(int id)
      {
         if (id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }

         var machine = await new MachineHttpClient(client).ReadMachineByKey(id);
         ViewBag.BranchName = machine.Branch.BranchName;
         ViewBag.BranchId = machine.BranchID;

         //ViewData["BranchId"] = new SelectList(await new BranchHttpClient(client).ReadBranches(), "ID", "BranchName", machine.BranchID);
         //ViewBag.BranchId = branchId;

         if (machine.ID == 0 || machine == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return RedirectToAction(nameof(Index), new { branchId = machine.BranchID });
         }
         return View(machine);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Update(MachineDto model)
      {
         if(ModelState.IsValid)
         {
            var machine = await new MachineHttpClient(client).UpdateMachine(model);
            if(machine.ID != model.ID || machine == null)
            {
               TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordUpdateError;
               return View(machine);
            }
            else
            {
               TempData[SessionConstant.Message] = MessageConstants.RecordUpdated;
               return RedirectToAction(nameof(Index), new {branchId = machine.BranchID});
            }
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.ModelStateInvalid;
            return RedirectToAction(nameof(Index), new {branchId = model.BranchID});
         }
      }
      #endregion Update

      #region Detail
      public async Task<IActionResult> Detail(int id)
      {
         if(id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }

         var machine = await new MachineHttpClient(client).ReadMachineByKey(id);

         if(machine.ID != id && machine == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return View();
         }
         return View(machine);
      }
      #endregion Detail

      #region Delete
      [HttpGet]
      public async Task<IActionResult> Delete(int id)
      {
         if (id <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return View();
         }

         var machine = await new MachineHttpClient(client).ReadMachineByKey(id);

         if(machine.ID != id || machine == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.NoMatchFoundError;
            return View();
         }
         return View(machine);
      }

      [HttpPost]
      public async Task<IActionResult> Delete(MachineDto model)
      {
         if (model.ID <= 0 || model == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return View();
         }

         var machine = await new MachineHttpClient(client).ReadMachineByKey(model.ID);

         var machineInDb = await new MachineHttpClient(client).DeleteMachine(machine);

         if (machineInDb.ID == 0 || model == null)
         {
            TempData[SessionConstant.Message] = MessageConstants.UnauthorizedAttemptOfRecordDeleteError;
            return View();
         }
         else
         {
            TempData[SessionConstant.Message] = MessageConstants.RecordDeleted;
            return RedirectToAction(nameof(Index), new { branchId = machineInDb.BranchID });
         }
      }
      #endregion Delete
   }
}