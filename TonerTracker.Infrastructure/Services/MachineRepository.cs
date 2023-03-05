using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class MachineRepository : Repository<Machine>, IMachineRepository
   {
      public MachineRepository(TonerTrackerContext context) : base(context)
      {
      }
   }
}
