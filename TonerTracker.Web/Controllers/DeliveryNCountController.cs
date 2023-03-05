using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Web.HttpClients;

namespace TonerTracker.Web.Controllers
{
  public class DeliveryNCountController : Controller
  {
    private readonly HttpClient client;
    #region Constructor
    public DeliveryNCountController(HttpClient client)
    {
      this.client = client;
    }
    #endregion Constructor

    #region Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
      //ViewData["Company"] = new SelectList(await new MachineHttpClient(client).ReadMachines(), "ID", "MachineSerialNo");

      DeliveryNCountDto deliveryNCountDto = new DeliveryNCountDto
      {
        Companies = await new CompanyHttpClient(client).ReadCompanies()
      };

      return View(new DeliveryNCountDto());
    }
    #endregion Create

    #region Index
    //public Task<IActionResult> Index()
    //{

    //   return View();
    //}
    #endregion

  }
}
