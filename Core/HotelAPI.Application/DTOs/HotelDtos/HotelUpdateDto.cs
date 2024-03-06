using HotelAPI.Application.DTOs.HotelImageDtos;
using HotelAPI.Application.Utilities.Profiles;
using Microsoft.AspNetCore.Http;

namespace HotelAPI.Application.DTOs.HotelDtos;

public class HotelUpdateDto : IDto, IMapTo<Hotel>
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
    public List<HotelImagePostDto> HotelImages { get; set; }

}