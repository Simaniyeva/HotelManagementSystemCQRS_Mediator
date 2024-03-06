namespace HotelAPI.Domain.Entities;

public class Reservator:BaseEntity, IEntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    //Relations
    public List<Reservation>Reservations { get; set; }
    public List<Review> Reviews { get; set; }
}
