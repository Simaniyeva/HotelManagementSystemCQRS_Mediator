namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class RoomTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoomTypeController(IMapper mapper, IMediator mediator)
    { 
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("GetRoomTypes")]
    public async Task<IActionResult> GetRoomTypes([FromQuery] GetAllRoomTypesQueryRequest request)
    {
        GetAllRoomTypesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("GetRoomTypesDetails")]
    public async Task<IActionResult> GetRoomTypesDetails([FromQuery] GetAllDetailsOfRoomTypesQueryRequest request)
    {
        GetAllDetailsOfRoomTypesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("GetRoomTypeById")]
    public async Task<IActionResult> GetRoomTypeById([FromQuery] GetRoomTypeByIdQueryRequest request)
    {
        GetRoomTypeByIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("AddRoomType")]
    public async Task<IActionResult> AddRoomType(CreateRoomTypeCommandRequest request)
    {
        CreateRoomTypeCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRoomTypeCommandRequest request)
    {

        UpdateRoomTypeCommandResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteRoomTypeCommandRequest request)
    {
        var response = await _mediator.Send(request);
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
