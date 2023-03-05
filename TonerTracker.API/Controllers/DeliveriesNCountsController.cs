using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using TonerTracker.Domain.Dto;
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

    #region ReadSidebars

    #endregion ReadSidebars

    //#region CreateDeliveryNCount
    //public Task<IActionResult> CreateDeliveryNCount(SidebarDto model)
    //{ 

    //}
    //#endregion CreateDeliveryNCount
   }
}
