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
      public string? BWSerialNo { get; set; }

      //[Required(ErrorMessage = "Toner Cyan SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Cyan SerialNo")]
      public string? CyanSerialNo { get; set; }

      //[Required(ErrorMessage = "Toner Magenta SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Magenta SerialNo")]
      public string? MagentaSerialNo { get; set; }

      //[Required(ErrorMessage = "Toner Yellow SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Yellow SerialNo")]
      public string? YellowSerialNo { get; set; }

      //[Required(ErrorMessage = "Toner Black SerialNo" + ModelValidationConstant.ValidationConstant)]
      [StringLength(100)]
      [Display(Name = "Black SerialNo")]
      public string? BlackSerialNo { get; set; }

      // for generate bill.
      //[Required(ErrorMessage = "Paper rate" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "BW Paper Rate")]
      public decimal? BWPaperRate { get; set; }
      [Display(Name = "Colour Paper Rate")]
      public decimal? ColourPaperRate { get; set; }

      [ForeignKey("BranchID")]
      public virtual Branch Branch { get; set; }

      //public virtual IEnumerable<PaperCount> PaperCounts { get; set; }
      //public virtual IEnumerable<TonerDelivery> TonerDeliveries { get; set; }
   }
}
