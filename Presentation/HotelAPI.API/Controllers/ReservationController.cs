using HotelAPI.API;
using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace ReservationAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationController(IReservationService ReservationService, IMapper mapper)
    {
        _reservationService = ReservationService;
        _mapper = mapper;
    }
    [HttpGet("GetReservations")]
    public async Task<IActionResult> GetReservations()
    {
        IDataResult<List<ReservationGetDto>> result = await _reservationService.GetAllAsync(true, Includes.ReservationIncludes);
        return Ok(result);

    }
    [HttpGet("GetReservationById/{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        IDataResult<ReservationGetDto> result = await _reservationService.GetByIdAsync(id, Includes.ReservationIncludes);
        return Ok(result);
    }

    [HttpPost("AddReservation")]
    public async Task<IActionResult> AddReservation(ReservationPostDto dto)
    {
        IResult result = await _reservationService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(ReservationUpdateDto dto)
    {
        await _reservationService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        ReservationGetDto result = (await _reservationService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservationService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        ReservationGetDto result = (await _reservationService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservationService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        ReservationGetDto result = (await _reservationService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reservationService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
