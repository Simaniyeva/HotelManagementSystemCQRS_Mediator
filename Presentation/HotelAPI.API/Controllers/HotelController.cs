using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;
    private readonly IMapper _mapper;

    public HotelController(IHotelService HotelService, IMapper mapper)
    {
        _hotelService = HotelService;
        _mapper = mapper;
    }
    [HttpGet("GetHotels")]
    public async Task<IActionResult> GetHotels()
    {
        IDataResult<List<HotelGetDto>> result = await _hotelService.GetAllAsync(true,Includes.HotelIncludes);
        return Ok(result);

    }
    [HttpGet("GetHotelById/{id}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        IDataResult<HotelGetDto> result = await _hotelService.GetByIdAsync(id, Includes.HotelIncludes);
        return Ok(result);
    }

    [HttpPost("AddHotel")]
    public async Task<IActionResult> AddHotel(HotelPostDto dto)
    {
        IResult result = await _hotelService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(HotelUpdateDto dto)
    {
        await _hotelService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        HotelGetDto result = (await _hotelService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _hotelService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        HotelGetDto result = (await _hotelService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _hotelService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        HotelGetDto result = (await _hotelService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _hotelService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
