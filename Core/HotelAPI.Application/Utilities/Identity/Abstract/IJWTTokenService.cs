namespace HotelAPI.Application.Identity
{
    public interface IJWTTokenService
    {
        string GenerateJwt(IUserClaimsOptions userModelForTokenGen, IList<string> roles, IJWTOptions jwtSettings);
    }
}
