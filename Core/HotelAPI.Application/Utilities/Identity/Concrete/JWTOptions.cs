namespace HotelAPI.Application.Identity.Concrete
{
    public class JWTOptions : IJWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationInYears { get; set; }
    }
}
