using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;

namespace TonerTracker.Infrastructure.Contracts
{
   public interface ITonerDeliveryRepository : IRepository<TonerDelivery>
   {
      Task<List<SideMenuCompany>> DeliveryNCountSideMenu();
   }
}