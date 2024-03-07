namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;
    readonly IMediator _mediator;

    public CityController(ICityService CityService, IMapper mapper, IMediator mediator)
    {
        _cityService = CityService;
        _mediator = mediator;
    }

    [HttpGet("GetAllCities")]
    public async Task<IActionResult> GetAllCities([FromQuery] GetAllCitiesQueryRequest request)
    {
        GetAllCitiesQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpGet("GetAllCitiesDetails")]
    public async Task<IActionResult> GetAllCitiesDetails([FromQuery] GetAllDetailsOfCitiesQueryRequest request)
    {
        GetAllDetailsOfCitiesQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpGet("GetCityById")]
    public async Task<IActionResult> GetCityById([FromQuery] GetCityByIdQueryRequest request)
    {
        GetCityByIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(CreateCityCommandRequest request)
    {
        CreateCityCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCityCommandRequest request)
    {

        UpdateCityCommandResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteCityCommandRequest request)
    {
        var response=await _mediator.Send(request);
        if (response.Success)
        {
        return Ok(new {isSuccess=true});

        }
        else
        {
            return BadRequest(new { isSuccess = false, errorMessage = response.ErrorMessage });
        }
    }

}
