using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class TonerDeliveriesController : ControllerBase
   {
      private readonly IUnitOfWork context;
      #region Constructor
      public TonerDeliveriesController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region CreateTonerDelivery
      [Route(RouteConstant.CreateTonerDelivery)]
      [HttpPost]
      public async Task<IActionResult> CreateTonerDelivery(TonerDelivery model)
      {
         try
         {
            if (model.ID < 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            if (await IfTonerDeliveryDuplicate(model) == true)
               return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

            var tonerDelivery = context.TonerDeliveryRepository.Add(model);

            if (tonerDelivery.ID <= 0 || tonerDelivery == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            await context.SaveChangesAsync();

            return CreatedAtAction("ReadTonerDeliveryByKey", new { id = model.ID }, tonerDelivery);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion CreateDeliveryToner

      #region ReadTonerDeliveries
      [Route(RouteConstant.ReadTonerDeliveries)]
      [HttpGet]
      public async Task<IActionResult> ReadTonerDeliveries()
      {
         try
         {
            var tonerDeliveries = await context.TonerDeliveryRepository.QueryAsync(td => td.IsDeleted == false);

            if (tonerDeliveries == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(tonerDeliveries);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadTonerDeliveries

      #region ReadTonerDeliveryByKey
      [Route(RouteConstant.ReadTonerDeliveryByKey)]
      [HttpGet]
      public async Task<IActionResult> ReadTonerDeliveryByKey(int id)
      {
         try
         {
            if (id == 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var tonerDelivery = await context.TonerDeliveryRepository.FirstOrDefaultAsync(td => td.ID == id, m => m.Machine );

            if (tonerDelivery == null || tonerDelivery.ID == 0)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            return Ok(tonerDelivery);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadTonerDeliveryByKey

      #region UpdateTonerDelivery
      [Route(RouteConstant.UpdateTonerDelivery)]
      [HttpPut]
      public async Task<IActionResult> UpdateTonerDelivery(int id, TonerDelivery model)
      {
         try
         {
            if (id != model.ID || model.ID == 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            context.TonerDeliveryRepository.Update(model);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion UpdateTonerDelivery

      #region DeleteTonerDelivery
      [Route(RouteConstant.DeleteTonerDelivery)]
      [HttpPatch]
      public async Task<IActionResult> DeleteTonerDelivery(int id)
      {
         try
         {
            if (id <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var tonerDelivery = await context.TonerDeliveryRepository.FirstOrDefaultAsync(td => td.ID == id);

            if (tonerDelivery == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            return Ok(tonerDelivery);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion DeleteTonerDelivery

      #region TonerDevliveriesByMachineId
      [Route(RouteConstant.TonerDevliveriesByMachineId)]
      [HttpGet]
      public async Task<IActionResult> TonerDevliveriesByMachineId(int key)
      {
         try
         {
            if (key <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            IEnumerable<TonerDelivery> tonerDeliveries = await context.TonerDeliveryRepository.QueryAsync(td => td.MachineID == key && td.IsDeleted == false, m => m.Machine);

            if (tonerDeliveries == null || tonerDeliveries.Count() == 0)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            return Ok(tonerDeliveries);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }

      }
      #endregion TonerDevliveriesByMachineId

      #region IfTonerDeliveryDuplicate
      private async Task<bool> IfTonerDeliveryDuplicate(TonerDelivery model)
      {
         var tonerDelivery = await context.TonerDeliveryRepository.FirstOrDefaultAsync(td => td.DateCreated.Value.Year == model.DateCreated.Value.Year && td.DateCreated.Value.Month == model.DateCreated.Value.Month && td.IsDeleted == false);

         if (tonerDelivery != null)
            return true;

         return false;
      }
      #endregion IfTonerDeliveryDuplicate
   }
}
