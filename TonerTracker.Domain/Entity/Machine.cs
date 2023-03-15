using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Entity
{
   public class Machine : BaseModel
   {
      [Key]
      public int ID { get; set; }

      [Required(ErrorMessage = "Machine" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Branch")]
      [ForeignKey("BranchID")]
      public int BranchID { get; set; }

      [Required(ErrorMessage = "ModelNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Machine ModelNo")]
      public string MachineModelNo { get; set; }

      [Required(ErrorMessage = "SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Machine SerialNo")]
      public string MachineSerialNo { get; set; }

      [Required(ErrorMessage = "Colour Type" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Machine Color")]
      public ColourType ColourType { get; set; }

     // [Required(ErrorMessage = "Toner BW SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "BW SerialNo")]
      public string? BWModelNo { get; set; }

      //[Required(ErrorMessage = "Toner Cyan SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Cyan SerialNo")]
      public string? CyanModelNo { get; set; }

      //[Required(ErrorMessage = "Toner Magenta SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Magenta SerialNo")]
      public string? MagentaModelNo { get; set; }

      //[Required(ErrorMessage = "Toner Yellow SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Yellow SerialNo")]
      public string? YellowModelNo { get; set; }

      //[Required(ErrorMessage = "Toner Black SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Black SerialNo")]
      public string? BlackModelNo { get; set; }

      // for generate bill.
      //[Required(ErrorMessage = "Paper rate" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "BW Paper Rate")]
      public decimal? BWPaperRate { get; set; }
      [Display(Name = "Colour Paper Rate")]
      public decimal? ColourPaperRate { get; set; }

      [ValidateNever]
      public virtual Branch Branch { get; set; }

      //[ValidateNever]
      //public IEnumerable<PaperCount>? PaperCounts { get; set; }
      //[ValidateNever]
      //public IEnumerable<TonerDelivery>? TonerDeliveries { get; set; }
   }
}
