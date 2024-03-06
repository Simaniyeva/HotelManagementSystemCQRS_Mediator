namespace HotelAPI.Application.DTOs.AccountDtos;

public class UserUpdateDto:IMapTo<AppUser>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public NetworkStatus NetworkStatus { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Review> Reviews { get; set; }
    //public List<HotelUserImage> HotelUserImages { get; set; }
}
