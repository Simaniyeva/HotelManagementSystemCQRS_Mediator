using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
using HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;
using HotelAPI.Application.Features.Queries.CountryQueries.GetAllCountry;
using HotelAPI.Application.Features.Queries.CountryQueries.GetAllDetailsOfCountry;
using HotelAPI.Application.Features.Queries.CountryQueries.GetCountryById;
using MediatR;
using IResult = HotelAPI.Application.Utilities.Results.IResult;
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
    public async Task<IActionResult> GetAllCountries([FromQuery] GetAllCountryQueryRequest getAllCountryQueryRequest)
    {
        GetAllCountryQueryResponse response = await _mediator.Send(getAllCountryQueryRequest);
        return Ok(response);

    }
    [HttpGet("GetAllDetailsOfCountries")]
    public async Task<IActionResult> GetAllDetailsOfCountries([FromQuery] GetAllDetailsOfCountriesQueryRequest getAllDetailsOfCountriesQueryRequest)
    {
        GetAllDetailsOfCountriesQueryResponse response = await _mediator.Send(getAllDetailsOfCountriesQueryRequest);
        return Ok(response);

    }

    [HttpGet("GetCountryById/{id}")]
    public async Task<IActionResult> GetCountryById([FromQuery] GetCountryByIdQueryRequest getCountryByIdQueryRequest)
    {
        GetCountryByIdQueryResponse response = await _mediator.Send(getCountryByIdQueryRequest);
        return Ok(response);
    }


    [HttpPost("AddCountry")]
    public async Task<IActionResult> AddCountry(CountryPostDto dto)
    {
        IResult result = await _countryService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryUpdateDto dto)
    {
        await _countryService.UpdateAsync(dto);
        return Ok();
    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteCountryCommandRequest deleteCountryCommandRequest)
    {
        var response = await _mediator.Send(deleteCountryCommandRequest);
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
