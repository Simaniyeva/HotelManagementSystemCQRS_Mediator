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
    public async Task<IActionResult> GetEquipments([FromQuery] GetAllEquipmentsQueryRequest request)
    {
        GetAllEquipmentsQueryResponse response = await _mediator.Send(request);

        return Ok(response);

    }
    [HttpGet("GetEquipmentById/{id}")]
    public async Task<IActionResult> GetEquipmentById([FromQuery] GetEquipmentByIdQueryRequest request)
    {
        GetEquipmentByIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("AddEquipment")]
    public async Task<IActionResult> AddEquipment(CreateEquipmentCommandRequest request)
    {
        CreateEquipmentCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateEquipmentCommandRequest request)
    {
        UpdateEquipmentCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteEquipmentCommandRequest request)
    {
        DeleteEquipmentCommandResponse response = await _mediator.Send(request);
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
