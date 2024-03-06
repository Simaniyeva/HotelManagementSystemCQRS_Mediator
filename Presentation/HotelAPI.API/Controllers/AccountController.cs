//using HotelAPI.Application.DTOs;
//using HotelAPI.Domain.Entities.Identity;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace HotelAPI.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class AccountController : ControllerBase
//{
//    private readonly IMapper _mapper;
//    #region Auth
//    private readonly IAccountService _accountService;


//    public AccountController(IAccountService accountService, IMapper mapper)
//    {
//        _accountService = accountService;
//        _mapper = mapper;
//    }

//    [HttpPost("RegisterUser")]
//    public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
//    {
//        var result = await _accountService.Register(registerDto);

//        if (!result.Success)
//        {
//            return BadRequest(result);
//        }
//        return Ok(result);
//    }


//    [HttpGet("GetAllUsers")]
//    public async Task<IActionResult> GetAllUsers()
//    {
//        var result =await  _accountService.GetAllUser();
//        return Ok(result);
//    }

//    [HttpGet("GetUserById")]
//    public async Task<IActionResult> GetUserById(string id)
//    {
//        var result = await _accountService.GetUserById(id);
//        return Ok(result);
        
//    }
//    [HttpPost("Login")]
//    public async Task<IActionResult> Login(LoginDto loginDto)
//    {
//        var result = await _accountService.Login(loginDto);

//        if (!result.Success)
//        {
//            return BadRequest(result);
//        }
//        // Map UserGetDto to AppUser
//        var user = _mapper.Map<AppUser>(result.Data);
//        return Ok();
//        #endregion
//    }
//}