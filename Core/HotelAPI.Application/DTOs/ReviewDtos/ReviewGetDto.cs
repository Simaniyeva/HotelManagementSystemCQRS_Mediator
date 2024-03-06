namespace HotelAPI.Application.DTOs.ReviewDtos;

public class ReviewGetDto : IDto
{
    public int Id { get; set; }
    public string Content { get; set; }

    //Relations
    public ReservatorGetDto Reservator { get; set; }
    public HotelGetDto Hotel { get; set; }
}