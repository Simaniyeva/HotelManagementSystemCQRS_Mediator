using HotelAPI.Application.Helpers;
using HotelAPI.Application.Utilities.Profiles;
using System.Text.Json.Serialization;

namespace HotelAPI.Application.DTOs.HotelImageDtos;

public class HotelImagePostDto:IMapTo<HotelImage>
{

    public string FileName { get; set; }
    [JsonIgnore]
    public string FilePath { get; set; } = FileServerPath.Path;
    public string FileBase64 { get; set; }

    //Relations
    [JsonIgnore]
    public int HotelId { get; set; }

}
