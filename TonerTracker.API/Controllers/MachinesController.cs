using Microsoft.AspNetCore.Mvc;
using TonerTracker.Domain.Dto;
using TonerTracker.Domain.Entity;
using TonerTracker.Infrastructure.Contracts;
using TonerTracker.Utilities.Constant;

namespace TonerTracker.API.Controllers
{
  [Route(RouteConstant.BaseRoute)]
  [ApiController]
  public class MachinesController : ControllerBase
  {
    private readonly IUnitOfWork context;
    #region Construcotr
    public MachinesController(IUnitOfWork context)
    {
      this.context = context;
    }
    #endregion Construcotr

    #region CreateMachine
    [Route(RouteConstant.CreateMachine)]
    [HttpPost]
    public async Task<IActionResult> CreateMachine(MachineDto model)
    {
      try
      {
        if (model.ID < 0 || model == null)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordInsert);

        if (await IfMachineDuplicate(model) == true)
          return StatusCode(StatusCodes.Status409Conflict, MessageConstants.DuplicateError);

        Machine machine = new Machine
        {
          ID = model.ID,
          BranchID = model.BranchID,
          MachineModelNo = model.MachineModelNo,
          MachineSerialNo = model.MachineSerialNo,
          ColourType = model.ColourType,
          DateCreated = DateTime.UtcNow
        };

        if (model.ColourType == ColourType.BW)
        {
          machine.BWSerialNo = model.BWSerialNo;
          machine.BWPaperRate = model.BWPaperRate;
        }
        else if (model.ColourType == ColourType.Colour)
        {
          machine.CyanSerialNo = model.CyanSerialNo;
          machine.MagentaSerialNo = model.MagentaSerialNo;
          machine.YellowSerialNo = model.YellowSerialNo;
          machine.BlackSerialNo = model.BlackSerialNo;
          machine.ColourPaperRate = model.ColourPaperRate;
        }

        var machineInDb = context.MachineRepository.Add(machine);
        await context.SaveChangesAsync();

        return Ok(machineInDb);
        //return CreatedAtAction("ReadMachineByKey", new { id = machineInDb.ID }, machineInDb);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion CreateMachine

    #region ReadMachines
    [Route(RouteConstant.ReadMachines)]
    [HttpGet]
    public async Task<IActionResult> ReadMachines()
    {
      try
      {
        var machines = await context.MachineRepository.QueryAsync(m => m.IsDeleted == false);

        if (machines.Count() < 0 || machines == null)
          return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoRecordError);

        return Ok(machines);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion ReadMachines

    #region ReadMachineByKey
    [Route(RouteConstant.ReadMachineByKey)]
    [HttpGet]
    public async Task<IActionResult> ReadMachineByKey(int key)
    {
      try
      {
        if (key <= 0)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

        var machine = await context.MachineRepository.FirstOrDefaultAsync(m => m.ID == key && m.IsDeleted == false, b => b.Branch);

        if (machine.ID == 0 || machine == null)
          return StatusCode(StatusCodes.Status404NotFound, MessageConstants.NoMatchFoundError);

        return Ok(machine);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion

    #region UpdateMachine
    [Route(RouteConstant.UpdateMachine)]
    [HttpPut]
    public async Task<IActionResult> UpdateMachine(int key, MachineDto model)
    {
      try
      {
        if (key != model.ID || model == null || model.ID == 0)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordUpdateError);

        Machine machine = new Machine
        {
          ID = model.ID,
          BranchID = model.BranchID,
          MachineModelNo = model.MachineModelNo,
          MachineSerialNo = model.MachineSerialNo,
          ColourType = model.ColourType,
          DateModified = DateTime.UtcNow
        };

        if (model.ColourType == ColourType.BW)
        {
          machine.BWSerialNo = model.BWSerialNo;
          machine.BWPaperRate = model.BWPaperRate;
        }
        else if (model.ColourType == ColourType.Colour)
        {
          machine.CyanSerialNo = model.CyanSerialNo;
          machine.MagentaSerialNo = model.MagentaSerialNo;
          machine.YellowSerialNo = model.YellowSerialNo;
          machine.BlackSerialNo = model.BlackSerialNo;
          machine.ColourPaperRate = model.ColourPaperRate;
        }

        context.MachineRepository.Update(machine);
        await context.SaveChangesAsync();

        //return StatusCode(StatusCodes.Status204NoContent);
        return Ok(machine);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion UpdateMachine

    #region DeleteMachine
    [Route(RouteConstant.DeleteMachine)]
    [HttpPatch]
    public async Task<IActionResult> DeleteMachine(MachineDto model)
    {
      try
      {
        if (model.ID == 0 || model == null)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.UnauthorizedAttemptOfRecordDeleteError);

        Machine machine = new Machine
        {
          ID = model.ID,
          BranchID = model.BranchID,
          MachineModelNo = model.MachineModelNo,
          MachineSerialNo = model.MachineSerialNo,
          ColourType = model.ColourType,
          IsDeleted = true
        };

        if (model.ColourType == ColourType.BW)
        {
          machine.BWSerialNo = model.BWSerialNo;
          machine.BWPaperRate = model.BWPaperRate;
        }
        else if (model.ColourType == ColourType.Colour)
        {
          machine.CyanSerialNo = model.CyanSerialNo;
          machine.MagentaSerialNo = model.MagentaSerialNo;
          machine.YellowSerialNo = model.YellowSerialNo;
          machine.BlackSerialNo = model.BlackSerialNo;
          machine.ColourPaperRate = model.ColourPaperRate;
        }

        context.MachineRepository.Delete(machine);
        await context.SaveChangesAsync();

        return Ok(machine);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion DeleteMachine

    #region IfMachineDuplicate
    private async Task<bool> IfMachineDuplicate(MachineDto model)
    {
      var machine = await context.MachineRepository.FirstOrDefaultAsync(m => m.MachineSerialNo == model.MachineSerialNo);

      if (machine != null)
        return true;
      return false;
    }
    #endregion IfMachineDuplicate

    #region MachinesByBranchId
    [Route(RouteConstant.MachinesByBranchId)]
    [HttpGet]
    public async Task<IActionResult> MachinesByBranchId(int key)
    {
      try
      {
        if (key <= 0)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.InvalidParameterError);

        var branches = await context.MachineRepository.QueryAsync(m => m.IsDeleted == false && m.BranchID == key, b => b.Branch);

        if (branches.Count() == 0 || branches == null)
          return StatusCode(StatusCodes.Status400BadRequest, MessageConstants.NoMatchFoundError);

        return Ok(branches);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, MessageConstants.ExceptionError = ex.Message.ToString());
      }
    }
    #endregion MachinesByBranchId
  }
}