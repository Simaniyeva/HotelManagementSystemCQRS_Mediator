namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly IMediator _mediator;
    public CountryController(ICountryService countryService, IMediator mediator)
    {
        _countryService = countryService;
        _mediator = mediator;
    }

    [HttpGet("GetAllCountries")]
    public async Task<IActionResult> GetAllCountries([FromQuery] GetAllCountryQueryRequest request)
    {
        GetAllCountryQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpGet("GetAllDetailsOfCountries")]
    public async Task<IActionResult> GetAllDetailsOfCountries([FromQuery] GetAllDetailsOfCountriesQueryRequest request)
    {
        GetAllDetailsOfCountriesQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }

    [HttpGet("GetCountryById/{id}")]
    public async Task<IActionResult> GetCountryById([FromQuery] GetCountryByIdQueryRequest request)
    {
        GetCountryByIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpPost("AddCountry")]
    public async Task<IActionResult> AddCountry(CreateCountryCommandRequest request)
    {
        CreateCountryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCountryCommandRequest request)
    {
        UpdateCountryCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteCountryCommandRequest request)
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
