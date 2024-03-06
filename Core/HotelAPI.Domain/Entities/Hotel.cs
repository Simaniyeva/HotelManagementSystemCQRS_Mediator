namespace HotelAPI.Domain.Entities;

public class Hotel:BaseEntity, IEntityBase
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WebSite { get; set; }
    public Grade Grade { get; set; } = Grade.Hostel;
    public decimal TotalRating { get; set; }

    //Relations
    public int CityId { get; set; }
    public City City { get; set; }
    public List<Review>Reviews { get; set; }
    public List<Room>Rooms { get; set; }
    public List<HotelImage> HotelImages { get; set; }


}
