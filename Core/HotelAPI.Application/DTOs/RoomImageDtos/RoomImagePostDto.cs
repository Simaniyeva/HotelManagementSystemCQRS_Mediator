

namespace HotelAPI.Application.DTOs.RoomImageDtos;

public class RoomImagePostDto : IMapTo<RoomImage>
{

    public string FileName { get; set; }
    [JsonIgnore]
    public string FilePath { get; set; } = FileServerPath.Path;
    public string FileBase64 { get; set; }

    //Relations
    [JsonIgnore]
    public int RoomId { get; set; }

}
