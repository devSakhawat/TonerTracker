using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TonerTracker.DAL;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class CompanyRepository : Repository<Company>, ICompanyRepository
   {
      private readonly TonerTrackerContext context;
      #region Constructor
      public CompanyRepository(TonerTrackerContext context) : base(context)
      {
         this.context = context;
      }
      #endregion Constructor
   }
}
