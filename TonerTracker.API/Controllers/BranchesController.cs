using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class BranchesController : ControllerBase
   {
      private readonly IUnitOfWork context;
      #region Constructor
      public BranchesController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region CreateBranch
      [Route(RouteConstant.CreateBranch)]
      [HttpPost]
      public async Task<IActionResult> CreateBranch(BranchDto model)
      {
         try
         {
            if (model.ID < 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            if (await IfBrachDuplicate(model) == true)
               return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

            Branch branch = new Branch
            {
               ID = model.ID,
               BranchName = model.BranchName,
               Address = model.Address,
               CompanyID = model.CompanyID,
               DateCreated = DateTime.UtcNow
            };

            var branchInDb = context.BranchRepository.Add(branch);

            if (branchInDb.ID != 0 || branchInDb == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            await context.SaveChangesAsync();

            return CreatedAtAction("ReadBranchByKey", new { key = branchInDb.ID }, branchInDb);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion CreateBranch

      #region ReadBranches
      [Route(RouteConstant.ReadBranches)]
      [HttpGet]
      public async Task<IActionResult> ReadBranches()
      {
         try
         {
            var branches = await context.BranchRepository.QueryAsync(b => b.IsDeleted == false, br => br.Company);

            if (branches.Count() <= 0 || branches == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(branches);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadBranches

      #region ReadBranchByKey
      [Route(RouteConstant.ReadBranchByKey)]
      [HttpGet]
      public async Task<IActionResult> ReadBranchByKey(int key)
      {
         try
         {
            if (key <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var branch = await context.BranchRepository.FirstOrDefaultAsync(b => b.ID == key && b.IsDeleted==false, c => c.Company);

            if (branch == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            //BranchDto branchDto = new BranchDto
            //{
            //   ID = branch.ID,
            //   BranchName = branch.BranchName,
            //   Address = branch.Address,
            //   CompanyName = branch.Company.CompanyName
            //};

            return Ok(branch);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadBranchByKey

      #region UpdateBranch
      [Route(RouteConstant.UpdateBranch)]
      [HttpPut]
      public async Task<IActionResult> UpdateBranch(int key, Branch model)
      {
         try
         {
            if (key != model.ID)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            Branch branch = new Branch
            {
               ID = model.ID,
               BranchName = model.BranchName,
               Address = model.Address,
               CompanyID = model.CompanyID,
               DateModified = DateTime.UtcNow
            };

            if (branch == null || branch.ID == 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            context.BranchRepository.Update(branch);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion UpdateBranch

      #region DeleteBranch
      [Route(RouteConstant.DeleteBranch)]
      [HttpPatch]
      public async Task<IActionResult> DeleteBranch(Branch model)
      {
         try
         {
            if (model.ID <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordDeleteError);

            if ((await context.MachineRepository.QueryAsync(b => b.BranchID == model.ID && b.IsDeleted == false)).Count() > 0)
               return StatusCode(StatusCodes.Status405MethodNotAllowed, MessageConstants.DependencyError);

            var branch = await context.BranchRepository.FirstOrDefaultAsync(b => b.ID == model.ID);

            if (branch == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            context.BranchRepository.Delete(branch);
            await context.SaveChangesAsync();

            return Ok(branch);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }

      }
      #endregion DeleteBranch

      #region BranchesByCompanyID
      [Route(RouteConstant.BranchesByCompanyID)]
      [HttpGet]
      public async Task<IActionResult> BranchesByCompanyID(int key)
      {
         try
         {
            if (key <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var companyBasedbranches = await context.BranchRepository.QueryAsync(b => b.IsDeleted == false && b.CompanyID == key, br => br.Company);

            if (companyBasedbranches.Count() == 0 || companyBasedbranches == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

            return Ok(companyBasedbranches);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion BranchesByCompanyID

      #region IfBrachDuplicate
      private async Task<bool> IfBrachDuplicate(BranchDto model)
      {
         var branch = await context.BranchRepository.FirstOrDefaultAsync(b => b.BranchName.ToLower().Trim() == model.BranchName.ToLower().Trim() && b.IsDeleted == false);

         if (branch != null)
            return true;

         return false;
      }
      #endregion
   }
}