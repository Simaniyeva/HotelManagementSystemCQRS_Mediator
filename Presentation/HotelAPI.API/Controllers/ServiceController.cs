using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServiceController(IServiceService ServiceService, IMapper mapper)
    {
        _serviceService = ServiceService;
        _mapper = mapper;
    }
    [HttpGet("GetServices")]
    public async Task<IActionResult> GetServices()
    {
        IDataResult<List<ServiceGetDto>> result = await _serviceService.GetAllAsync(true, Includes.ServiceIncludes);
        return Ok(result);

    }
    [HttpGet("GetServiceById/{id}")]
    public async Task<IActionResult> GetServiceById(int id)
    {
        IDataResult<ServiceGetDto> result = await _serviceService.GetByIdAsync(id, Includes.ServiceIncludes);
        return Ok(result);
    }

    [HttpPost("AddService")]
    public async Task<IActionResult> AddService(ServicePostDto dto)
    {
        IResult result = await _serviceService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(ServiceUpdateDto dto)
    {
        await _serviceService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ServiceGetDto result = (await _serviceService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        ServiceGetDto result = (await _serviceService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        ServiceGetDto result = (await _serviceService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _serviceService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
