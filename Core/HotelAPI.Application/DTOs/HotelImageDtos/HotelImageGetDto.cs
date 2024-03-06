using HotelAPI.Application.Utilities.Profiles;

namespace HotelAPI.Application.DTOs.HotelImageDtos;

public class HotelImageGetDto: IMapTo<HotelImage>
{
    public int Id { get; set; }
    public string FileName { get; set; }
    // public FileType FileType { get; set; }
    public string FileBase64 { get; set; }

    //Relations
    public int HotelId { get; set; }
}
