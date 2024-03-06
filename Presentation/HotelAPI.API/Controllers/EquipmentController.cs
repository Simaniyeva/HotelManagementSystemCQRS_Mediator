
using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
using HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;
using HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;
using HotelAPI.Application.Features.Commands.EquipmentCommands.CreateEquipment;
using HotelAPI.Application.Features.Commands.EquipmentCommands.DeleteEquipment;
using HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;
using HotelAPI.Application.Features.Queries.CityQueries.GetAllCities;
using HotelAPI.Application.Features.Queries.CityQueries.GetCityById;
using HotelAPI.Application.Features.Queries.EquipmentQueries.GetAllEquipments;
using HotelAPI.Application.Features.Queries.EquipmentQueries.GetEquipmentById;
using MediatR;
using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _equipmentService;
    private readonly IMediator _mediator;


    public EquipmentController(IEquipmentService EquipmentService, IMediator mediator)
    {
        _equipmentService = EquipmentService;
        _mediator = mediator;
    }
    [HttpGet("GetEquipments")]
    public async Task<IActionResult> GetEquipments([FromQuery] GetAllEquipmentsQueryRequest getAllEquipmentsQueryRequest)
    {
        GetAllEquipmentsQueryResponse response = await _mediator.Send(getAllEquipmentsQueryRequest);

        return Ok(response);

    }
    [HttpGet("GetEquipmentById/{id}")]
    public async Task<IActionResult> GetEquipmentById([FromQuery] GetEquipmentByIdQueryRequest getEquipmentByIdQueryRequest)
    {
        GetEquipmentByIdQueryResponse response = await _mediator.Send(getEquipmentByIdQueryRequest);
        return Ok(response);
    }

    [HttpPost("AddEquipment")]
    public async Task<IActionResult> AddEquipment(CreateEquipmentCommandRequest equipmentCommandRequest)
    {
        CreateEquipmentCommandResponse response = await _mediator.Send(equipmentCommandRequest);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateEquipmentCommandRequest updateEquipmentCommandRequest)
    {
        UpdateEquipmentCommandResponse response = await _mediator.Send(updateEquipmentCommandRequest);
        return Ok(response);
    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteEquipmentCommandRequest deleteEquipmentCommandRequest)
    {
        DeleteEquipmentCommandResponse response = await _mediator.Send(deleteEquipmentCommandRequest);
        if (response.Success)
        {
            return Ok(new { isSuccess = true });

        }
        else
        {
            return BadRequest(new { isSuccess = false, errorMessage = response.ErrorMessage });
        }



    }
}
