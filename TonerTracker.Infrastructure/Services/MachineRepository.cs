using Microsoft.EntityFrameworkCore;
using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class MachineRepository : Repository<Machine>, IMachineRepository
   {
      private readonly TonerTrackerContext context;
      public MachineRepository(TonerTrackerContext context) : base(context)
      {
         this.context = context;
      }

      public async Task<IEnumerable<Machine>> MachineWithCompany()
      {
         List<Machine> machines = await context.Machines.AsQueryable().AsNoTracking().Where(m => m.IsDeleted == false).Include(b => b.Branch).ThenInclude(c => c.Company).ToListAsync();
         return machines;
      }

   }
}
