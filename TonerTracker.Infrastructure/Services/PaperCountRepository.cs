using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class PaperCountRepository : Repository<PaperCount>, IPaperCountRepository
   {
      public PaperCountRepository(TonerTrackerContext context) : base(context)
      {
      }
   }
}
