using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Dto
{
   public class PaperCountDto
   {
      [Key]
      public int ID { get; set; }

      [Required(ErrorMessage = "Machine" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Machine")]
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
   }
}
