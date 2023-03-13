using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TonerTracker.Domain.Entity;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.Domain.Dto
{
  public class DeliveryNCountDto
  {
      public List<TonerDelivery>? TonerDeliveries { get; set; }
      public List<PaperCount>? PaperCounts { get; set; }
      public TonerDelivery? TonerDelivery { get; set; }
      public PaperCount? PaperCount { get; set; }

      public List<Machine> Machines { get; set; }

      //public Machine Machine { get; set; }

      //public Branch Branch { get; set; }

      //public Company company { get; set; }


      public string? TonerErrorMessage { get; set; }
      public string? PaperErrorMessage { get; set; }
      public string? MachineErrorMessage { get; set; }
      public string? ExceptionError { get; set; }

    //// Toner Delivery
    //public int DeliveryID { get; set; }

    //[Required(ErrorMessage = "Machine" + ModelValidationConstant.ValidationConstant)]
    //[Display(Name = "Machine")]
    //public int MachineID { get; set; }

    //public int PaperID { get; set; }

    //[Display(Name = "InHouse BW")]
    //public int? InHouseBW { get; set; }

    //[Display(Name = "InHouse Cyan")]
    //public int? InHouseCyan { get; set; }

    //[Display(Name = "InHouse Magenta")]
    //public int? InHouseMagenta { get; set; }

    //[Display(Name = "InHouse Yellow")]
    //public int? InHouseYellow { get; set; }

    //[Display(Name = "InHouse Black")]
    //public int? InHouseBlack { get; set; }

    //[Display(Name = "Machine BW")]
    //public decimal? MachineBW { get; set; }

    //[Display(Name = "Machine Cyan")]
    //public decimal? MachineCyan { get; set; }

    //[Display(Name = "Machine Magenta")]
    //public decimal? MachineMagenta { get; set; }

    //[Display(Name = "Machine Yellow")]
    //public decimal? MachineYellow { get; set; }

    //[Display(Name = "Machine Black")]
    //public decimal? MachineBlack { get; set; }

    //[Display(Name = "Delivery BW")]
    //public int? DeliveryBW { get; set; }

    //[Display(Name = "Delivery Cyan")]
    //public int? DeliveryCyan { get; set; }

    //[Display(Name = "Delivery Magenta")]
    //public int? DeliveryMagenta { get; set; }

    //[Display(Name = "Delivery Yellow")]
    //public int? DeliveryYellow { get; set; }

    //[Display(Name = "Delivery Black")]
    //public int? DeliveryBlack { get; set; }

    //[Display(Name = "Stock BW")]
    //public decimal? StockBW { get; set; }

    //[Display(Name = "Stock Cyan")]
    //public decimal? StockCyan { get; set; }

    //[Display(Name = "Stock Magenta")]
    //public decimal? StockMagenta { get; set; }

    //[Display(Name = "Stock Yellow")]
    //public decimal? StockYellow { get; set; }

    //[Display(Name = "Stock Black")]
    //public decimal? StockBlack { get; set; }

    //// Paper Count

    ////[Required(ErrorMessage = "Previous count" + ModelValidationConstant.ValidationConstant)]
    //[Display(Name = "Previous Count")]
    //public int? PreviousCount { get; set; }

    //[Required(ErrorMessage = "Current count" + ModelValidationConstant.ValidationConstant)]
    //[Display(Name = "Current Count")]
    //public int CurrentCount { get; set; }

    ////[Required(ErrorMessage = "Total paper" + ModelValidationConstant.ValidationConstant)]
    //[Display(Name = "Total Paper")]
    //public int? TotalPaper { get; set; }

    //// Extra property for dropdown
    //public int? CompanyId { get; set; }
    //public int? BranchId { get; set; }

    ////public List<SidebarDto> SidebarDtos { get; set; }

    //// List for dropdown
    //public List<Company?> Companies { get; set; }
    ////public List<Branch?> Branches { get; set; }

    //public virtual Machine? Machine { get; set; }
  }
}
