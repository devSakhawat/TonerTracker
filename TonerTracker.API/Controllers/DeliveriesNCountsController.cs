using Microsoft.AspNetCore.Mvc;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class DeliveriesNCountsController : ControllerBase
   {
      private readonly IUnitOfWork context;
      #region constructor
      public DeliveriesNCountsController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion constructor

      #region DeliveryNCountSideMenu
      [Route(RouteConstant.ReadDeliveriesNCounts)]
      [HttpGet]
      public async Task<IActionResult> DeliveryNCountSideMenu()
      {
         try
         {
            var sideMenus = await context.TonerDeliveryRepository.DeliveryNCountSideMenu();

            if (sideMenus.Count() < 0 || sideMenus == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(sideMenus);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion DeliveryNCountSideMenu

      #region CreateDeliveryNCount
      //public Task<IActionResult> CreateDeliveryNCount(SidebarDto model)
      //{

      //}
      #endregion CreateDeliveryNCount
   }
}
