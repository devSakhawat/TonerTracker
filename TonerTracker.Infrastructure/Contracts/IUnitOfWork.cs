namespace TonerTracker.Infrastructure.Contracts
{
   public interface IUnitOfWork
   {
      Task<int> SaveChangesAsync();

      ICompanyRepository CompanyRepository { get; }

      IBranchRepository BranchRepository { get; }

      IMachineRepository MachineRepository { get; }

      ITonerDeliveryRepository TonerDeliveryRepository { get; }

      IPaperCountRepository PaperCountRepository { get; }

      IBillGenerateRepository BillGenerateRepository { get; }
   }
}
