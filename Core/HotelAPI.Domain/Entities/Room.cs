namespace HotelAPI.Domain.Entities;

public class Room:BaseEntity, IEntityBase
{
    public int Number { get; set; }
    public int Floor { get; set; }
    public string Phone { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public RoomState RoomState { get; set; } = RoomState.Available;

    //Relations
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public List<Reservation>Reservations { get; set; }
    public List<RoomEquipment> RoomEquipments { get; set; }
    public List<RoomImage> RoomImages { get; set; }


    public Room()
    {
        RoomEquipments = new List<RoomEquipment>();
    }


}

