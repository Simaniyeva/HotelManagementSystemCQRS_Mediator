using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;
    private readonly IMapper _mapper;

    public RoomTypeController(IRoomTypeService RoomTypeService, IMapper mapper)
    {
        _roomTypeService = RoomTypeService;
        _mapper = mapper;
    }
    [HttpGet("GetRoomTypes")]
    public async Task<IActionResult> GetRoomTypes()
    {
        IDataResult<List<RoomTypeGetDto>> result = await _roomTypeService.GetAllAsync(true, Includes.RoomTypeIncludes);
        return Ok(result);

    }
    [HttpGet("GetRoomTypeById/{id}")]
    public async Task<IActionResult> GetRoomTypeById(int id)
    {
        IDataResult<RoomTypeGetDto> result = await _roomTypeService.GetByIdAsync(id, Includes.RoomTypeIncludes);
        return Ok(result);
    }

    [HttpPost("AddRoomType")]
    public async Task<IActionResult> AddRoomType(RoomTypePostDto dto)
    {
        IResult result = await _roomTypeService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(RoomTypeUpdateDto dto)
    {
        await _roomTypeService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        RoomTypeGetDto result = (await _roomTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomTypeService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        RoomTypeGetDto result = (await _roomTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomTypeService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        RoomTypeGetDto result = (await _roomTypeService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomTypeService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
