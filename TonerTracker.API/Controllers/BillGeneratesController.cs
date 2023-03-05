using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class BillGeneratesController : ControllerBase
   {
      private readonly IUnitOfWork context;
      #region Constructor
      public BillGeneratesController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region CreateBillGenerate
      [Route(RouteConstant.CreateBillGenerate)]
      [HttpPost]
      public async Task<IActionResult> CreateBillGenerate(BillGenerate model)
      {
         try
         {
            if (model.ID != 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            if (await IfBillGenerateDuplicate(model) == true)
               return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

            var billGenerate = context.BillGenerateRepository.Add(model);

            if (billGenerate.ID == 0 || billGenerate == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            await context.SaveChangesAsync();

            return CreatedAtAction("ReadBillGenerateByKey", new { id = billGenerate.ID }, billGenerate);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion CreateBillGenerate

      #region ReadBillGenerates
      [Route(RouteConstant.ReadBillGenerates)]
      [HttpGet]
      public async Task<IActionResult> ReadBillGenerates()
      {
         try
         {
            var billGenerates = await context.BillGenerateRepository.QueryAsync(bg => bg.IsDeleted == false);

            if (billGenerates.Count() < 0 || billGenerates == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(billGenerates);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadBillGenerates

      #region ReadBillGenerateByKey
      [Route(RouteConstant.ReadBillGenerateByKey)]
      [HttpGet]
      public async Task<IActionResult> ReadBillGenerateByKey(int id)
      {
         try
         {
            if (id <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var billGenerate = await context.BillGenerateRepository.FirstOrDefaultAsync(bg => bg.ID == id);

            if (billGenerate == null || billGenerate.ID <= 0)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            return Ok(billGenerate);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadBillGenerate

      #region UpdateBillGenerate
      [Route(RouteConstant.UpdateBillGenerate)]
      [HttpPut]
      public async Task<IActionResult> UpdateBillGenerate(int id, BillGenerate model)
      {
         try
         {
            if (id != model.ID || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            context.BillGenerateRepository.Update(model);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion UpdateBillGenerate

      #region DeleteBillGenerate
      [Route(RouteConstant.DeleteBillGenerate)]
      [HttpPatch]
      public async Task<IActionResult> DeleteBillGenerate(int id)
      {
         try
         {
            if (id <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var billGenerate = await context.BillGenerateRepository.FirstOrDefaultAsync(bg => bg.ID == id);

            if (billGenerate.ID <= 0 || billGenerate == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            context.BillGenerateRepository.Delete(billGenerate);
            await context.SaveChangesAsync();

            return Ok(billGenerate);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion DeleteBillGenerate

      #region IfBillGenerateDuplicate
      private async Task<bool> IfBillGenerateDuplicate(BillGenerate model)
      {
         var billGenerate = await context.BillGenerateRepository.FirstOrDefaultAsync
            (bg => bg.DateCreated.Value.Year == model.DateCreated.Value.Year && bg.DateCreated.Value.Month == model.DateCreated.Value.Month || bg.IsDeleted == false);

         if (billGenerate != null)
            return true;

         return false;
      }
      #endregion IfBillGenerateDuplicate
   }
}
