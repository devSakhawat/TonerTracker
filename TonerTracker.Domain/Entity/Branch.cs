using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Entity
{
   public class Branch : BaseModel
   {
      [Key]
      public int ID { get; set; }
      [Required(ErrorMessage = "Branch name" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Branch Name")]
      public string BranchName { get; set; }

      [Required(ErrorMessage = "")]
      [StringLength(150)]
      [Display(Name = "Branch Address" + ModelValidationConstant.ValidationConstant)]
      public string Address { get; set; }

      [Required(ErrorMessage = "Company name" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Company Name")]
      public int CompanyID { get; set; }

      [ForeignKey("CompanyID")]
      public virtual Company Company { get; set; }

      //public virtual IEnumerable<Machine> Machines { get; set; }
   }
}
