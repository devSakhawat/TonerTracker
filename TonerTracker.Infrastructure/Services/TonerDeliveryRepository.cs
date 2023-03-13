using Microsoft.EntityFrameworkCore;
using TonerTracker.DAL;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class TonerDeliveryRepository : Repository<TonerDelivery>, ITonerDeliveryRepository
   {
      private readonly TonerTrackerContext context;

      public TonerDeliveryRepository(TonerTrackerContext context) : base(context)
      {
         this.context = context;
      }
      public async Task<List<SideMenuCompany>> DeliveryNCountSideMenu()
      {
         var companies = await context.Companies.Where(c => c.IsDeleted == false).ToListAsync();
         List<SideMenuCompany> sideMenuCompanies = new List<SideMenuCompany>();

         foreach (var company in companies)
         {
            var branches = await context.Branches.Where(b => b.IsDeleted == false && b.CompanyID == company.ID).ToListAsync();
            List<SideMenuBranch> sideMenuBranches = new List<SideMenuBranch>();
            foreach (var branch in branches)
            {
               var machines = await context.Machines.Where(m => m.IsDeleted == false && m.BranchID == branch.ID).ToListAsync();
               List<SideMenuMachine> sideMenuMachines = new List<SideMenuMachine>();
               foreach (var machine in machines)
               {
                  sideMenuMachines.Add(new SideMenuMachine { ID = machine.ID, MachineSerialNo = machine.MachineSerialNo, BranchId = machine.BranchID });
               }

               sideMenuBranches.Add(new SideMenuBranch { ID = branch.ID, BranchName = branch.BranchName, CompanyId = branch.CompanyID, Machines = sideMenuMachines });
            }
            sideMenuCompanies.Add(new SideMenuCompany { ID = company.ID, CompanyName = company.CompanyName, Branches = sideMenuBranches });
         }
         return sideMenuCompanies;
      }
   }
}
