using TonerTracker.Domain.Entity;

namespace TonerTracker.Infrastructure.Contracts
{
   public interface IMachineRepository : IRepository<Machine>
   {
      Task<IEnumerable<Machine>> MachineWithCompany();
   }
}
