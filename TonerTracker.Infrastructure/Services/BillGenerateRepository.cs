using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class BillGenerateRepository : Repository<BillGenerate>, IBillGenerateRepository
   {
      public BillGenerateRepository(TonerTrackerContext context) : base(context)
      {
      }
   }
}
