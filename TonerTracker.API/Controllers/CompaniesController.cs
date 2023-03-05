using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
   [Route(RouteConstant.BaseRoute)]
   [ApiController]
   public class CompaniesController : ControllerBase
   {
      private readonly IUnitOfWork context;

      #region Constructor
      public CompaniesController(IUnitOfWork context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region CreateCompany
      [Route(RouteConstant.CreateCompany)]
      [HttpPost]
      public async Task<IActionResult> CreateCompany(CompanyDto model)
      {
         try
         {
            if (model.ID != 0 || model == null)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            if (await IsCompanyDuplicate(model) == true)
               return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

            Company company = new Company
            {
               ID = model.ID,
               CompanyName = model.CompanyName,
               Address = model.Address,
               DateCreated = DateTime.UtcNow
            };

            var companyInDb = context.CompanyRepository.Add(company);

            if (companyInDb.ID != 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

            await context.SaveChangesAsync();

            return CreatedAtAction("ReadCompanyByKey", new { key = companyInDb.ID }, companyInDb);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion CreateCompany

      #region ReadCompanies
      [Route(RouteConstant.ReadCompanies)]
      [HttpGet]
      public async Task<IActionResult> ReadCompanies()
      {
         try
         {
            var companies = await context.CompanyRepository.QueryAsync(c => c.IsDeleted == false);

            if (companies.Count() < 0 || companies == null)
               return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

            return Ok(companies);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadCompanies

      #region ReadCompanyByKey
      [Route(RouteConstant.ReadCompanyByKey)]
      [HttpGet]
      public async Task<IActionResult> ReadCompanyByKey(int key)
      {
         try
         {
            if (key <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

            var company = await context.CompanyRepository.FirstOrDefaultAsync(c => c.ID == key);

            if (company == null || company.ID == 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.NoMatchFoundError);

            return Ok(company);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion ReadCompanyByKey

      #region UpdateCompany
      [Route(RouteConstant.UpdateCompany)]
      [HttpPut]
      public async Task<IActionResult> UpdateCompany(int key, CompanyDto model)
      {
         try
         {
            if (key != model.ID)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            Company company = new Company
            {
               ID = model.ID,
               CompanyName = model.CompanyName,
               Address = model.Address,
               DateModified = DateTime.UtcNow
            };

            if (company == null || company.ID == 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

            context.CompanyRepository.Update(company);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion UpdateCompany

      #region DeleteCompany
      [Route(RouteConstant.DeleteCompany)]
      [HttpPatch]
      public async Task<IActionResult> DeleteCompnay(CompanyDto model)
      {
         try
         {
            if (model.ID <= 0)
               return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordDeleteError);

            //if ((await context.CompanyRepository.QueryAsync(c => c.IsDeleted == false && c.Branches.Count() > 0)).Count() > 0 )
            if ((await context.BranchRepository.QueryAsync(c => c.IsDeleted == false && c.CompanyID == model.ID)).Count() > 0)
               return StatusCode(StatusCodes.Status405MethodNotAllowed, MessageConstants.DependencyError);

            var company = await context.CompanyRepository.FirstOrDefaultAsync(c => c.ID == model.ID);

            context.CompanyRepository.Delete(company);
            await context.SaveChangesAsync();

            return Ok(company);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
         }
      }
      #endregion DeleteCompany

      #region IsCompanyDuplicate
      private async Task<bool> IsCompanyDuplicate(CompanyDto model)
      {
         var company = await context.CompanyRepository.FirstOrDefaultAsync(b => b.CompanyName == model.CompanyName && b.IsDeleted == false);
         if (company != null)
            return true;

         return false;
      }
      #endregion IsCompanyDuplicate
   }
}