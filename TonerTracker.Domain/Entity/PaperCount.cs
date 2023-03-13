using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Entity
{
   public class PaperCount : BaseModel
   {
      [Key]
      public int ID { get; set; }

      [Required(ErrorMessage = "Machine" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Machine")]
      [ForeignKey("MachineID")]
      public int MachineID { get; set; }

      //[Required(ErrorMessage = "Previous count" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Previous Count")]
      public int? PreviousCount { get; set; }

      [Required(ErrorMessage = "Current count" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Current Count")]
      public int CurrentCount { get; set; }

      //[Required(ErrorMessage = "Total paper" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Total Paper")]
      public int? TotalPaper { get; set; }

      [ValidateNever]
      public virtual Machine Machine { get; set; }
      //public virtual IEnumerable<BillGenerate> BillGenerates { get; set; }
   }
}
