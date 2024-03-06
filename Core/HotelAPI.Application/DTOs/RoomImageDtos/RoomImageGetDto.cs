

namespace HotelAPI.Application.DTOs.RoomImageDtos;

public class RoomImageGetDto : IMapTo<RoomImage>
{
  
        public int Id { get; set; }
        public string FileName { get; set; }
        // public FileType FileType { get; set; }
        public string FileBase64 { get; set; }

        //Relations
        public int RoomId { get; set; }
    
}
