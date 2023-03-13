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
      public int? BranchId { get; set; }
   }

}
