using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class ServiceTypeController : ControllerBase
{
    private readonly IServiceTypeService _serviceTypeService;
    private readonly IMapper _mapper;

    public ServiceTypeController(IServiceTypeService ServiceTypeService, IMapper mapper)
    {
        _serviceTypeService = ServiceTypeService;
        _mapper = mapper;
    }
    [HttpGet("GetServiceTypes")]
    public async Task<IActionResult> GetServiceTypes()
    {
        IDataResult<List<ServiceTypeGetDto>> result = await _serviceTypeService.GetAllAsync(true, Includes.ServiceTypeIncludes);
        return Ok(result);

    }
    [HttpGet("GetServiceTypeById/{id}")]
    public async Task<IActionResult> GetServiceTypeById(int id)
    {
        IDataResult<ServiceTypeGetDto> result = await _serviceTypeService.GetByIdAsync(id, Includes.ServiceTypeIncludes);
        return Ok(result);
    }

    [HttpPost("AddServiceType")]
    public async Task<IActionResult> AddServiceType(ServiceTypePostDto dto)
    {
        IResult result = await _serviceTypeService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(ServiceTypeUpdateDto dto)
    {
        await _serviceTypeService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ServiceTypeGetDto result = (await _serviceTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceTypeService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        ServiceTypeGetDto result = (await _serviceTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceTypeService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        ServiceTypeGetDto result = (await _serviceTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceTypeService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
