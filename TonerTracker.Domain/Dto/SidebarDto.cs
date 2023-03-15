using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TonerTracker.Domain.Entity;

namespace TonerTracker.Domain.Dto
{
   public class DliveryNCount 
   {
      public string? ErrorMessage { get; set; }
      public List<SideMenuCompany> SideMenuCompanies { get; set; }
   }
   public class SideMenuCompany
   {
      public int? ID { get; set; }
      public string? CompanyName { get; set; }

      public List<SideMenuBranch>? Branches { get; set; }
   }

   public class SideMenuBranch
   {
      public int? ID { get; set; }
      public string? BranchName { get; set; }
      public int? CompanyId { get; set; }

      public List<SideMenuMachine>? Machines { get; set; }
   }

   public class SideMenuMachine
   {
      public int? ID { get; set; }
      public string? MachineSerialNo { get; set; }
      public ColourType ColourType { get; set; }
      public int? BranchId { get; set; }
      public List<SideMenuTonerDelivery>? TonerDeliveryDtos { get; set; }
   }

   public class SideMenuTonerDelivery
   {
      public int ID { get; set; }
      public int MachineID { get; set; }
      public string? BWSerialNo { get; set; }
      public string? CyanSerialNo { get; set; }
      public string? MagentaSerialNo { get; set; }
      public string? YellowSerialNo { get; set; }
      public string? BlackSerialNo { get; set; }



      public List<TonerDelivery>? TonerDeliveries { get; set; }

      public string? ErrorMessage { get; set; }
   }

}
