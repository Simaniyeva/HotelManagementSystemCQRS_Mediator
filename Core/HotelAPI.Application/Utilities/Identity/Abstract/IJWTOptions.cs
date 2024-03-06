namespace HotelAPI.Application.Identity
{
    public interface IJWTOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationInYears { get; set; }
    }
}
