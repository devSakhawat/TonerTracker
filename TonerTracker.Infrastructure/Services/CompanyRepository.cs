using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class CompanyRepository : Repository<Company>, ICompanyRepository
   {
      #region Constructor
      public CompanyRepository(TonerTrackerContext context) : base(context)
      {
      }
      #endregion Constructor
   }
}
