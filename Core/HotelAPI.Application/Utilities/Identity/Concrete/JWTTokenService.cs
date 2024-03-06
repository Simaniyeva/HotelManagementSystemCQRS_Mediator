
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelAPI.Application.Identity.Concrete
{
    public class JWTTokenService : IJWTTokenService
    {
        public string GenerateJwt(IUserClaimsOptions userModelForTokenGen, IList<string> roles, IJWTOptions jwtSettings)
        {
            List<Claim> claims = new List<Claim>
                            {
                                new Claim(JwtRegisteredClaimNames.Sub, userModelForTokenGen.Id.ToString()),
                                new Claim(ClaimTypes.Name, userModelForTokenGen.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(ClaimTypes.NameIdentifier, userModelForTokenGen.Id.ToString())
                            };

            IEnumerable<Claim> roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime accessTokenExpiration = DateTime.Now.AddYears(Convert.ToInt32(jwtSettings.ExpirationInYears));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: accessTokenExpiration,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
