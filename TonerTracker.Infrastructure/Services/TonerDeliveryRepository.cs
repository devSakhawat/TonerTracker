using TonerTracker.DAL;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class TonerDeliveryRepository : Repository<TonerDelivery>, ITonerDeliveryRepository
   {
      public TonerDeliveryRepository(TonerTrackerContext context) : base(context)
      {
      }
   }
}
