using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class BranchRepository : Repository<Branch>, IBranchRepository
   {
      public BranchRepository(TonerTrackerContext context) : base(context)
      {
      }
   }
}
