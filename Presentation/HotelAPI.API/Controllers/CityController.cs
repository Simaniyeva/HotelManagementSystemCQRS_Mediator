using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
using HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;
using HotelAPI.Application.Features.Queries.CityQueries.GetAllCities;
using HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;
using HotelAPI.Application.Features.Queries.CityQueries.GetCityById;
using MediatR;
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
    public async Task<IActionResult> GetAllCities([FromQuery] GetAllCitiesQueryRequest getAllCityQueryRequest)
    {
        GetAllCitiesQueryResponse response = await _mediator.Send(getAllCityQueryRequest);
        return Ok(response);

    }
    [HttpGet("GetAllCitiesDetails")]
    public async Task<IActionResult> GetAllCitiesDetails([FromQuery] GetAllDetailsOfCitiesQueryRequest getAllDetailsOfCityQueryRequest)
    {
        GetAllDetailsOfCitiesQueryResponse response = await _mediator.Send(getAllDetailsOfCityQueryRequest);
        return Ok(response);

    }
    [HttpGet("GetCityById")]
    public async Task<IActionResult> GetCityById([FromQuery] GetCityByIdQueryRequest getCityByIdQueryRequest)
    {
        GetCityByIdQueryResponse response = await _mediator.Send(getCityByIdQueryRequest);
        return Ok(response);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(CreateCityCommandRequest createCityCommandRequest)
    {
        CreateCityCommandResponse response = await _mediator.Send(createCityCommandRequest);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCityCommandRequest updateCityCommandRequest)
    {

        UpdateCityCommandResponse response = await _mediator.Send(updateCityCommandRequest);
        return Ok(response);

    }
    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete(DeleteCityCommandRequest deleteCityCommandRequest)
    {
        var response=await _mediator.Send(deleteCityCommandRequest);
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
