namespace TonerTracker.Utilities.Constant
{
   public static class RouteConstant
   {
      public const string BaseRoute = "toner-tracker";

      #region Company
      public const string CreateCompany = "company";
      public const string ReadCompanies = "companies";
      public const string ReadCompanyByKey = "company/key/{key}";
      public const string UpdateCompany = "company/{key}";
      public const string DeleteCompany = "company/{key}";
      #endregion Company

      #region Branch
      public const string CreateBranch = "branch";
      public const string ReadBranches = "branches";
      public const string ReadBranchByKey = "branch/key/{key}";
      public const string UpdateBranch = "branch/{key}";
      public const string DeleteBranch = "branch/{key}";
      public const string BranchesByCompanyID = "branches/company/{key}";
      #endregion Branch

      #region Machine
      public const string CreateMachine = "machine";
      public const string ReadMachines = "machines";
      public const string ReadMachineByKey = "machine/key/{key}";
      public const string UpdateMachine = "machine/{key}";
      public const string DeleteMachine = "machine/{key}";
      public const string MachinesByBranchId = "machine/branch/{key}";
      #endregion Machine

      #region DeliveryNCount
      public const string CreateDeliveryNCount = "delivery-count";
      public const string ReadDeliveriesNCounts = "deliveries-counts";
      public const string ReadDeliveryNCountByKey = "delivery-count/key/{key}";
      public const string UpdateDeliveryNCount = "delivery-count/{key}";
      public const string DeleteDeliveryNCount = "delivery-count/{key}";
      #endregion TonerDelivery

      #region TonerDelivery
      public const string CreateTonerDelivery = "toner-delivery";
      public const string ReadTonerDeliveries = "toner-deliveries";
      public const string ReadTonerDeliveryByKey = "toner-delivery/key/{key}";
      public const string UpdateTonerDelivery = "toner-delivery/{key}";
      public const string DeleteTonerDelivery = "toner-delivery/{key}";
      #endregion TonerDelivery

      #region PaperCount
      public const string CreatePaperCount = "paper-count";
      public const string ReadPaperCounts = "paper-counts";
      public const string ReadPaperCountByKey = "paper-count/key/{key}";
      public const string UpdatePaperCount = "paper-count/{key}";
      public const string DeletePaperCount = "paper-count/{key}";
      #endregion PaperCount

      #region BillGenerate
      public const string CreateBillGenerate = "bill-generate";
      public const string ReadBillGenerates = "bill-generates";
      public const string ReadBillGenerateByKey = "bill-generate/key/{key}";
      public const string UpdateBillGenerate = "bill-generate/{key}";
      public const string DeleteBillGenerate = "bill-generate/{key}";
      #endregion BillGenerate
   }
}
