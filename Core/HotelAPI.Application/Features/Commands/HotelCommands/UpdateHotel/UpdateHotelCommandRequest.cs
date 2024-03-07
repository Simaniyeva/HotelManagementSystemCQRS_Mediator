namespace HotelAPI.Application.Features.Commands.HotelCommands.UpdateHotel;

public class UpdateHotelCommandRequest:IRequest<UpdateHotelCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WebSite { get; set; }
    public Grade Grade { get; set; }
    public bool isActive { get; set; }
    public decimal TotalRating { get; set; }

    //Relations
    public int CityId { get; set; }
}
