using HotelAPI.API;
using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace ReservatorAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservatorController : ControllerBase
{
    private readonly IReservatorService _reservatorService;
    private readonly IMapper _mapper;

    public ReservatorController(IReservatorService ReservatorService, IMapper mapper)
    {
        _reservatorService = ReservatorService;
        _mapper = mapper;
    }
    [HttpGet("GetReservators")]
    public async Task<IActionResult> GetReservators()
    {
        IDataResult<List<ReservatorGetDto>> result = await _reservatorService.GetAllAsync(true,Includes.ReservatorIncludes);
        return Ok(result);

    }
    [HttpGet("GetReservatorById/{id}")]
    public async Task<IActionResult> GetReservatorById(int id)
    {
        IDataResult<ReservatorGetDto> result = await _reservatorService.GetByIdAsync(id, Includes.ReservatorIncludes);
        return Ok(result);
    }

    [HttpPost("AddReservator")]
    public async Task<IActionResult> AddReservator(ReservatorPostDto dto)
    {
        IResult result = await _reservatorService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(ReservatorUpdateDto dto)
    {
        await _reservatorService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ReservatorGetDto result = (await _reservatorService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservatorService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        ReservatorGetDto result = (await _reservatorService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservatorService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        ReservatorGetDto result = (await _reservatorService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservatorService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
