using HotelAPI.API;
using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace RoomAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IEquipmentService _equipmentService;
    private readonly IMapper _mapper;

    public RoomController(IRoomService RoomService, IMapper mapper, IEquipmentService equipmentService)
    {
        _roomService = RoomService;
        _mapper = mapper;
        _equipmentService = equipmentService;
    }
    [HttpGet("GetRooms")]
    public async Task<IActionResult> GetRooms()
    {
        IDataResult<List<RoomGetDto>> result = await _roomService.GetAllAsync(true, Includes.RoomIncludes);
        return Ok(result);

    }
    [HttpGet("GetRoomById/{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        IDataResult<RoomGetDto> result = await _roomService.GetByIdAsync(id, Includes.RoomIncludes);
        return Ok(result);
    }

    [HttpPost("AddRoom")]
    public async Task<IActionResult> AddRoom(RoomPostDto dto)
    {
        IDataResult<List<EquipmentGetDto>> equipments = await _equipmentService.GetAllAsync(false);
        IResult result = await _roomService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(RoomUpdateDto dto)
    {
        await _roomService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        RoomGetDto result = (await _roomService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        RoomGetDto result = (await _roomService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        RoomGetDto result = (await _roomService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roomService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
