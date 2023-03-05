using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Entity
{
   public class BillGenerate : BaseModel
   {
      [Key]
      public int ID { get; set; }

      [Required(ErrorMessage = "Paper count" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Paper Count")]
      public int PaperCountID { get; set; }

      [Required(ErrorMessage ="Monthly bill" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Monthly Bill")]
      public decimal MonthlyBill { get; set; }

      [ForeignKey("PaperCountID")]
      public virtual PaperCount PaperCount { get; set; }
   }
}
