using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Dto
{
   public class BranchDto
   {
      public int ID { get; set; }
      [Required(ErrorMessage = "Branch name" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Branch Name")]
      public string BranchName { get; set; }

      [Required(ErrorMessage = "Branch Address" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Branch Address")]
      public string Address { get; set; }

      [Required(ErrorMessage = "Company name" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Company Name")]
      public int CompanyID { get; set; }

      public string? CompanyName { get; set; }
   }
}
