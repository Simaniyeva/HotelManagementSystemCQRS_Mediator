namespace HotelAPI.Domain.Entities;

public class Service:BaseEntity, IEntityBase
{
    public string Description { get; set; }
    public string AvailabilitySchedule { get; set; }
    public double Price { get; set; }


    //Relations
    public int ServiceTypeId { get; set; }
    public virtual ServiceType ServiceType { get; set; }
}
