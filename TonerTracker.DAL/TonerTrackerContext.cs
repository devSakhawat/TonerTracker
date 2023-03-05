using Microsoft.EntityFrameworkCore;
using TonerTracker.Domain.Entity;

namespace TonerTracker.DAL
{
   public class TonerTrackerContext : DbContext
   {
      public TonerTrackerContext(DbContextOptions<TonerTrackerContext> options) : base(options)
      {
      }

      public DbSet<Company> Companies { get; set; }
      public DbSet<Branch> Branches { get; set; }
      public DbSet<Machine> Machines { get; set; }
      public DbSet<TonerDelivery> TonerDeliveries { get; set; }
      public DbSet<PaperCount> PaperCounts { get; set; }
      public DbSet<BillGenerate> BillGenerates { get; set; }
   }
}