using System.ComponentModel.DataAnnotations;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Dto
{
   public class CompanyDto
   {
      public int ID { get; set; }
      [Required(ErrorMessage = "Company name" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name ="Company Name")]
      public string CompanyName { get; set; }
      [Required(ErrorMessage = "Company address" + ModelValidationConstant.ValidationConstant)]
      [StringLength(150)]
      [Display(Name = "Company Address")]
      public string Address { get; set; }
   }
}
