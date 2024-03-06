namespace HotelAPI.Domain.Entities;

public class ServiceType:BaseEntity, IEntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }


    //Relations
    public List<Service>Services { get; set; }
}
