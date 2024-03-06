using IResult = HotelAPI.Application.Utilities.Results.IResult;

namespace HotelAPI.API.Controllers;

//[Authorize(Roles = "Admin,SuperAdmin")]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleSevice, IMapper mapper)
    {
        _roleService = roleSevice;
        _mapper = mapper;
    }

    [HttpGet("GetRoles")]
    public async Task<IActionResult> GetRoles()
    {
        IDataResult<List<RoleGetDto>> result = await _roleService.GetAllAsync();
        return Ok(result);

    }

    [HttpGet("GetCityById/{id}")]
    public async Task<IActionResult> GetRoleById(string id)
    {
        IDataResult<RoleGetDto> result = await _roleService.GetByIdAsync(id);
        return Ok(result);
    }


    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole(RolePostDto dto)
    {
        IResult result = await _roleService.CreateAsync(dto);
        return Ok(result);
    }


    [HttpPost("Update")]
    public async Task<IActionResult> Update(RoleUpdateDto dto)
    {
        await _roleService.UpdateAsync(dto);
        return Ok();
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(string id)
    {
        RoleGetDto result = (await _roleService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _roleService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
