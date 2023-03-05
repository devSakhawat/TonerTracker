using TonerTracker.DAL;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly TonerTrackerContext context;

      #region constructor
      public UnitOfWork(TonerTrackerContext context)
      {
         this.context = context;
      }
      #endregion constructor

      #region SaveChangesAsync
      public async Task<int> SaveChangesAsync()
      {
         return await context.SaveChangesAsync();
      }
      #endregion SaveChangesAsync

      #region Company
      ICompanyRepository companyRepository;
      public ICompanyRepository CompanyRepository
      {
         get
         {
            if (companyRepository == null)
               companyRepository = new CompanyRepository(context);

            return companyRepository;
         }
      }
      #endregion Company

      #region Branch
      IBranchRepository branchRepository;
      public IBranchRepository BranchRepository
      {
         get
         {
            if (branchRepository == null)
               branchRepository = new BranchRepository(context);

            return branchRepository;
         }
      }
      #endregion Branch

      #region Machine
      IMachineRepository machineRepository;
      public IMachineRepository MachineRepository
      {
         get
         {
            if (machineRepository == null)
               machineRepository = new MachineRepository(context);

            return machineRepository;
         }
      }
      #endregion Machine

      #region TonerDelivery
      ITonerDeliveryRepository tonerDeliveryRepository;
      public ITonerDeliveryRepository TonerDeliveryRepository
      {
         get
         {
            if (tonerDeliveryRepository == null)
               tonerDeliveryRepository = new TonerDeliveryRepository(context);

            return TonerDeliveryRepository;
         }
      }
      #endregion TonerDelivery

      #region PaperCount
      IPaperCountRepository paperCount;
      public IPaperCountRepository PaperCountRepository
      {
         get
         {
            if (paperCount == null)
               paperCount = new PaperCountRepository(context);

            return paperCount;
         }
      }
      #endregion PaperCount

      #region BillGenerate
      IBillGenerateRepository billGenerate;
      public IBillGenerateRepository BillGenerateRepository
      {
         get
         {
            if (billGenerate == null)
               billGenerate = new BillGenerateRepository(context);
            return billGenerate;
         }
      }
      #endregion BillGenerate
   }
}
