using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            List <TonerDelivery> tonerDeliveries = await new DeliveryNCountHttpclientt(client).TonerDevliveriesByMachineId(machineId);
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

   }
}
