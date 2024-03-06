using HotelAPI.Application.DTOs.AccountDtos;
using System.Security.Claims;

namespace HotelAPI.Application.Abstractions.Services.Abstract;
public interface IAccountService
{
    #region Auth Requests
    Task<IDataResult<UserGetDto>> RegisterUserAsync(RegisterDto registerDto);
    Task<IDataResult<UserGetDto>> LoginAsync(LoginDto loginDto);
    //Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);
    #endregion

    #region Get Requests

    Task<IDataResult<List<UserGetDto>>> GetAllUsersAsync(params string[] includes);
    Task<IDataResult<List<UserGetDto>>> GetAllUserByRole(string role, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserByIdAsync(string id, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserByClaimsAsync(ClaimsPrincipal userClaims, params string[] includes);
    Task<IdentityResult> EditUserAsync(UserUpdateDto userUpdateDto);
    #endregion

    #region Role Operations
    Task<IdentityResult> AddUserToRoleAsync(int userId, int roleId);
    Task<IdentityResult> AddUserToRolesAsync(int userId, List<int> roleIds);
    Task<IdentityResult> RemoveUserFromRoleAsync(int userId, int roleIds);
    Task<IdentityResult> RemoveUserFromRolesAsync(int userId, List<int> roleIds);


    #endregion


    Task<IResult> EvokeUserToAdmin(UserGetDto dto);
    Task<IResult> RevokeFromAdmin(UserGetDto dto);
}
