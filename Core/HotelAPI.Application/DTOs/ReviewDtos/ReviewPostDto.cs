
using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.ReviewDtos;

public class ReviewPostDto : IDto, IMapTo<Review>
{
    public string Content { get; set; }

    //Relations
    public int ReservatorId { get; set; }
    public int HotelId { get; set; }
}
