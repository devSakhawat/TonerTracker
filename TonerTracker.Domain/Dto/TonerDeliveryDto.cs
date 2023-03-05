using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Dto
{
   public class TonerDeliveryDto
   {
      public int ID { get; set; }

      [Required(ErrorMessage =  "Machine" + ModelValidationConstant.ValidationConstant)]
      [Display(Name = "Machine")]
      public int MachineID { get; set; }

      [Display(Name = "InHouse BW")]
      public int? InHouseBW { get; set; }

      [Display(Name = "InHouse Cyan")]
      public int? InHouseCyan { get; set; }

      [Display(Name = "InHouse Magenta")]
      public int? InHouseMagenta { get; set; }

      [Display(Name = "InHouse Yellow")]
      public int? InHouseYellow { get; set; }

      [Display(Name = "InHouse Black")]
      public int? InHouseBlack { get; set; }

      [Display(Name = "Machine BW")]
      public decimal? MachineBW { get; set; }

      [Display(Name = "Machine Cyan")]
      public decimal? MachineCyan { get; set; }

      [Display(Name = "Machine Magenta")]
      public decimal? MachineMagenta { get; set; }

      [Display(Name = "Machine Yellow")]
      public decimal? MachineYellow { get; set; }

      [Display(Name = "Machine Black")]
      public decimal? MachineBlack { get; set; }

      [Display(Name = "Delivery BW")]
      public int? DeliveryBW { get; set; }

      [Display(Name = "Delivery Cyan")]
      public int? DeliveryCyan { get; set; }

      [Display(Name = "Delivery Magenta")]
      public int? DeliveryMagenta { get; set; }

      [Display(Name = "Delivery Yellow")]
      public int? DeliveryYellow { get; set; }

      [Display(Name = "Delivery Black")]
      public int? DeliveryBlack { get; set; }

      [Display(Name = "Stock BW")]
      public decimal? StockBW { get; set; }

      [Display(Name = "Stock Cyan")]
      public decimal? StockCyan { get; set; }

      [Display(Name = "Stock Magenta")]
      public decimal? StockMagenta { get; set; }

      [Display(Name = "Stock Yellow")]
      public decimal? StockYellow { get; set; }

      [Display(Name = "Stock Black")]
      public decimal? StockBlack { get; set; }
   }
}
