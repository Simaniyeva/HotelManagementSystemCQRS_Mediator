using HotelAPI.Application.DTOs.AccountDtos;
using HotelAPI.Application.Identity;
using HotelAPI.Application.Identity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security.Claims;
namespace HotelAPI.Application.Abstractions.Services.Concrete;
public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJWTTokenService _jwtTokenService;
    private readonly JWTOptions _jwtSettings;


    private readonly IMapper _mapper;


    public AccountService(UserManager<AppUser> userManager, IMapper mapper, IJWTTokenService jwtTokenService,  IOptionsSnapshot<JWTOptions> jwtSettings)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _jwtSettings = jwtSettings.Value;
    }


    #region Auth Requests
    public async Task<IDataResult<UserGetDto>> LoginAsync(LoginDto loginDto)
    {
        AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
        bool checkPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        IList<string> roles = await _userManager.GetRolesAsync(user);
        UserClaimsOptions userModelForTokenGen = new UserClaimsOptions() { Id = user.Id, UserName = user.UserName };
        string jwt = _jwtTokenService.GenerateJwt(userModelForTokenGen, roles, _jwtSettings);


        if (user is null|| !checkPassword) { return new ErrorDataResult<UserGetDto>(_mapper.Map<UserGetDto>(user), "Email or Password is not correct"); }
        UserGetDto userDto = _mapper.Map<UserGetDto>(user);
        userDto.Roles = (List<string>)await _userManager.GetRolesAsync(user);
        return new SuccessDataResult<UserGetDto>(userDto, "Login Successful");

    }


    public async Task<IDataResult<UserGetDto>> RegisterUserAsync(RegisterDto registerDto)
    {
        AppUser existUser = await _userManager.FindByNameAsync(registerDto.UserName);
        if (existUser is not null) 
        { 
            return new ErrorDataResult<UserGetDto>(_mapper.Map<UserGetDto>(existUser), "User Already Exist");
        }
        AppUser user = _mapper.Map<AppUser>(registerDto);
        IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            List<string> errors = new List<string>();
            foreach (IdentityError error in result.Errors) 
            { 
                errors.Add(error.Description);
            }
            return new ErrorDataResult<UserGetDto>(_mapper.Map<UserGetDto>(user), errors.ToArray());
        }
        await _userManager.AddClaimsAsync(user, new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Name,user.UserName)
        });
        await _userManager.AddToRoleAsync(user, "User");
        await _userManager.UpdateAsync(user);
        UserGetDto userDto = _mapper.Map<UserGetDto>(user);
        userDto.Roles = (List<string>)await _userManager.GetRolesAsync(user);
        return new SuccessDataResult<UserGetDto>(userDto, "Successfully Registered");
    }

    //public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user)
    //{
    //    IList<Claim> claims = await _userManager.GetClaimsAsync(user);
    //    UserGetDto userDto = _mapper.Map<UserGetDto>(user);
    //    var accessToken = _tokenHelper.GenerateJwt(_tokenOptions);
    //    return new SuccessDataResult<AccessToken>(accessToken);
    //}
    #endregion

    #region Get Requests

    public async Task<IDataResult<List<UserGetDto>>> GetAllUser(params string[] includes)
    {
        List<AppUser> userList = GetUsers(includes).ToList();
        return new SuccessDataResult<List<UserGetDto>>(await GetUserDtos(userList));

    }

    public async Task<IDataResult<List<UserGetDto>>> GetAllUserByRole(string role, params string[] includes)
    {
        IList<AppUser> users = await _userManager.GetUsersInRoleAsync(role);
        users = GetUsers(includes).ToList();
        return new SuccessDataResult<List<UserGetDto>>(_mapper.Map<List<UserGetDto>>(users));
    }

    public async Task<IDataResult<UserGetDto>> GetUserById(string id, params string[] includes)
    {
        List<AppUser> users = GetUsers(includes).ToList();
        return new SuccessDataResult<UserGetDto>(_mapper.Map<UserGetDto>(users.Where(u => u.Id == id).FirstOrDefault()));
    }
    public async Task<IDataResult<UserGetDto>> GetUserByClaims(ClaimsPrincipal userClaims, params string[] includes)
    {
        List<AppUser> userList = GetUsers(includes).ToList();
        AppUser user = await _userManager.GetUserAsync(userClaims);
        return new SuccessDataResult<UserGetDto>(_mapper.Map<UserGetDto>(userList.Where(u => u.Id == user.Id).FirstOrDefault()));
    }


    #endregion


    #region EvokeRevoke Requests

    public async Task<IResult> EvokeUserToAdmin(UserGetDto dto)
    {
        AppUser user = await _userManager.FindByIdAsync(dto.Id);
        await _userManager.RemoveFromRoleAsync(user, "User");
        IdentityResult result = await _userManager.AddToRoleAsync(user, "Admin");
        if (!result.Succeeded)
        {
            return new ErrorResult("The user could not become an admin");
        }
        return new ErrorResult("The user is an admin now");
    }
    public async Task<IResult> RevokeFromAdmin(UserGetDto dto)
    {
        AppUser user = await _userManager.FindByIdAsync(dto.Id);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        IdentityResult result = await _userManager.AddToRoleAsync(user, "User");
        if (!result.Succeeded)
        {
            return new ErrorResult("Can't revoke the admin");
        }
        return new ErrorResult("The admin successfully revoked");
    }



    #endregion


    #region Private Methods

    private IQueryable<AppUser>GetUsers(string[] includes)
    {
        IQueryable<AppUser> users = _userManager.Users;
        if (includes is not null)
        {
            foreach (var item in includes)
            {
                users = users.Include(item);
            }
        }
        return users;
    }

    private async Task<List<UserGetDto>> GetUserDtos(List<AppUser> userList)
    {
        List<UserGetDto> users = _mapper.Map<List<UserGetDto>>(userList);
        for (int i = 0; i < userList.Count; i++)
        {
            for (int j = 0; j < users.Count; j++)
            {
                users[i].Roles = (List<string>)await _userManager.GetRolesAsync(userList[i]);
            }
        }
        return users;
    }

    public Task<IDataResult<List<UserGetDto>>> GetAllUsersAsync(params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UserGetDto>> GetUserByIdAsync(string id, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UserGetDto>> GetUserByClaimsAsync(ClaimsPrincipal userClaims, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> EditUserAsync(UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> AddUserToRoleAsync(int userId, int roleId)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> AddUserToRolesAsync(int userId, List<int> roleIds)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> RemoveUserFromRoleAsync(int userId, int roleIds)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> RemoveUserFromRolesAsync(int userId, List<int> roleIds)
    {
        throw new NotImplementedException();
    }




    #endregion





}
