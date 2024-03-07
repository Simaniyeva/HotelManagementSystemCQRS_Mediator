
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class HotelController : ControllerBase
{
    private readonly IMediator _mediator;

    public HotelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetHotels")]
    public async Task<IActionResult> GetHotels([FromQuery] GetAllHotelsQueryRequest request)
    {
        GetAllHotelsQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpGet("GetAllHotelsDetails")]
    public async Task<IActionResult> GetAllHotelsDetails([FromQuery] GetAllDetailsOfHotelsQueryRequest request)
    {
        GetAllDetailsOfHotelsQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }

    [HttpGet("GetHotelById")]
    public async Task<IActionResult> GetHotelById([FromQuery] GetHotelByIdQueryRequest request)
    {
        GetHotelByIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("AddHotel")]
    public async Task<IActionResult> AddHotel(CreateHotelCommandRequest request)
    {
        CreateHotelCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateHotelCommandRequest request)
    {
        UpdateHotelCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
  
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteHotelCommandRequest request)
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
