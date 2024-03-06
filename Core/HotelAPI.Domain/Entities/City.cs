namespace HotelAPI.Domain.Entities;

public class City : BaseEntity,IEntityBase
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    //Relations
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual List<Hotel>Hotels { get; set; }
}
