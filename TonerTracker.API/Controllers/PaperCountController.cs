using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class PaperCountController : ControllerBase
   {
      private readonly IUnitOfWork context;

      #region Constructor
      public PaperCountController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region CreatePaperCount
      [Route(RouteConstant.CreatePaperCount)]
      [HttpPost]
      public async Task<IActionResult> CreatePaperCount(PaperCount model)
      {
         try
         {
            if (model.ID < 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            if (await IfPaperCountDuplicate(model) == true)
               return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

            var paperCount = context.PaperCountRepository.Add(model);
            await context.SaveChangesAsync();

            return CreatedAtAction("ReadPaperCreateByKey", new { id = paperCount.ID }, paperCount);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion CreatePaperCount

      #region ReadPaperCounts
      [Route(RouteConstant.ReadPaperCounts)]
      [HttpGet]
      public async Task<IActionResult> ReadPaperCounts()
      {
         try
         {
            var paperCounts = await context.PaperCountRepository.QueryAsync(pc => pc.IsDeleted == false);

            if (paperCounts.Count() <= 0 || paperCounts == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(paperCounts);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadPaperCounts

      #region ReadPaperCountByKey
      [Route(RouteConstant.ReadPaperCountByKey)]
      [HttpGet]
      public async Task<IActionResult> ReadPaperCountByKey(int id)
      {
         try
         {
            if (id <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var paperCount = await context.PaperCountRepository.FirstOrDefaultAsync(pc => pc.ID == id);

            if (paperCount.ID <= 0 || paperCount == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);
            return Ok(paperCount);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadPaperCountByKey

      #region UpdatePaperCount
      [Route(RouteConstant.UpdatePaperCount)]
      [HttpPut]
      public async Task<IActionResult> UpdatePaperCount(int id, PaperCount model)
      {
         try
         {
            if (id != model.ID || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            context.PaperCountRepository.Update(model);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion UpdatePaperCount

      #region DeletePaperCount
      [Route(RouteConstant.DeletePaperCount)]
      [HttpPatch]
      public async Task<IActionResult> DeletePaperCount(int id)
      {
         try
         {
            if (id <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var paperCount = await context.PaperCountRepository.FirstOrDefaultAsync(pc => pc.ID == id);

            if (paperCount.ID <= 0 || paperCount == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordDeleteError);

            context.PaperCountRepository.Delete(paperCount);
            await context.SaveChangesAsync();

            return Ok(paperCount);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion DeletePaperCount

      #region PaperCountByMachineId
      [Route(RouteConstant.PaperCountByMachineId)]
      [HttpGet]
      public async Task<IActionResult> PaperCountByMachineId(int key)
      {
         try
         {
            if (key <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);
            IEnumerable<PaperCount> paperCounts = await context.PaperCountRepository.QueryAsync(pc => pc.MachineID == key && pc.IsDeleted == false, p => p.Machine);

            if (paperCounts == null || paperCounts.Count() == 0)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);
            return Ok(paperCounts);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError);
         }
         
      }
      #endregion PaperCountByMachineId

      #region IfPaperCountDuplicate
      private async Task<bool> IfPaperCountDuplicate(PaperCount model)
      {
         var paperCount = await context.PaperCountRepository.FirstOrDefaultAsync(pc => pc.ID == model.ID);

         if (paperCount != null)
            return true;
         return false;
      }
      #endregion IfPaperCountDuplicate
   }
}
