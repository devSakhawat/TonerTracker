using TonerTracker.Domain.Entity;

namespace TonerTracker.Domain.Dto
{
   public class SidebarDto
   {
      public int ID { get; set; }
      public string CompanyName { get; set; }
      public string Address { get; set; }
      List<Branch> Branches { get; set; }
   }
}
