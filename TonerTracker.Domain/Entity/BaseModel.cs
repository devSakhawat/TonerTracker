using System.ComponentModel.DataAnnotations;

namespace TonerTracker.Domain.Entity
{
   public class BaseModel
   {
      public int? CreatedBy { get; set; }
      [DataType(DataType.Date)]
      public DateTime? DateCreated { get; set; }
      public int? ModifiedBy { get; set; }
      [DataType(DataType.Date)]
      public DateTime? DateModified { get; set; }
      public bool IsDeleted { get; set; }
   }
}
