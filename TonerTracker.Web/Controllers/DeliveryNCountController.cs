using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;
using TonerTracker.Web.HttpClients;

namespace TonerTracker.Web.Controllers
{
   public class DeliveryNCountController : Controller
   {
      private readonly HttpClient client;
      #region Constructor
      public DeliveryNCountController(HttpClient client)
      {
         this.client = client;
      }
      #endregion Constructor

      #region Create
      [HttpGet]
      public async Task<IActionResult> Create(int machineId)
      {
         if (machineId <= 0)
         {
            TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
            return RedirectToAction("Index", new { machineId = machineId });
         }

         var tonerDelivery = await new TonerDeliveryHttpClient(client).ReadTonerDeliveryByKey(machineId);
         DeliveryNCountDto deliveryNCountDto = new DeliveryNCountDto();

         //var machines = await new MachineHttpClient(client).ReadMachineByKey(machineId);
         //ViewData["MachineId"] = new SelectList(await new MachineHttpClient(client).MachinesByBranchId(machines.BranchID), "ID", "MachineSerialNo");
         //ViewBag.BranchId = machine.BranchID;

         return View(new DeliveryNCountDto());
      }
      #endregion Create

      #region Index
      [HttpGet]
      public async Task<IActionResult> Index(int machineId)
      {
         try
         {
            if (machineId <= 0)
            {
               TempData[SessionConstant.Message] = MessageConstants.InvalidParameterError;
               return View();
            }

            DeliveryNCountDto deliveryNCountDto = new DeliveryNCountDto();

            // Machine with company for sidebar menu
            List<Machine> machines = await new MachineHttpClient(client).ReadMachines();
            if (machines.Count() == 0 || machines == null)
               deliveryNCountDto.MachineErrorMessage = MessageConstants.NoMatchFoundError;
            deliveryNCountDto.Machines = machines;

            List<TonerDelivery> tonerDeliveries = await new DeliveryNCountHttpclientt(client).TonerDevliveriesByMachineId(machineId);
            if (tonerDeliveries == null || tonerDeliveries.Count() == 0)
               deliveryNCountDto.TonerErrorMessage = MessageConstants.NoMatchFoundError;
            deliveryNCountDto.TonerDeliveries = tonerDeliveries;

            List<PaperCount> paperCounts = await new DeliveryNCountHttpclientt(client).PaperCountByMachineId(machineId);
            if (paperCounts == null || paperCounts.Count() == 0)
               deliveryNCountDto.PaperErrorMessage = MessageConstants.NoMatchFoundError;
            deliveryNCountDto.PaperCounts = paperCounts;

            return View(deliveryNCountDto);
         }
         catch (Exception ex)
         {
            DeliveryNCountDto deliveryNCountDto = new DeliveryNCountDto();
            deliveryNCountDto.ExceptionError = ex.Message.ToString();
            return View(deliveryNCountDto);
         }
      }
      #endregion

      #region DeliveryNCountSideMenu
      public async Task<IActionResult> DeliveryNCountSideMenu()
      {
         try
         {
            DliveryNCount deliveryNCount = new DliveryNCount();
            List<SideMenuCompany> sideMenuCompanies = await new DeliveryNCountHttpclientt(client).DeliveryNCountSideMenu();

            deliveryNCount.SideMenuCompanies = sideMenuCompanies;
            var branches = sideMenuCompanies.Select(b => b.Branches).ToList();
            var machines = sideMenuCompanies.Select(b => b.Branches.Select(m => m.Machines)).ToList();

            if (deliveryNCount.SideMenuCompanies.Count() == 0 || sideMenuCompanies == null)
            {
               deliveryNCount.ErrorMessage = MessageConstants.NoRecordError;
               return View(deliveryNCount);
            }
            else if (branches.Count() == 0 || branches == null)
            {
               deliveryNCount.ErrorMessage = "Branch record not found!";
               return View(deliveryNCount);
            }
            else if (machines.Count() == 0 || machines == null)
            {
               deliveryNCount.ErrorMessage = "Machine record not found!";
               return View(deliveryNCount);
            }
            else
            {

               return View(deliveryNCount);
            }
            
         }
         catch (Exception ex)
         {
            DliveryNCount deliveryNCount = new DliveryNCount();
            deliveryNCount.ErrorMessage = ex.Message.ToString();
            return View(deliveryNCount);
         }
      }
      #endregion DeliveryNCountSideMenu
   }
}
