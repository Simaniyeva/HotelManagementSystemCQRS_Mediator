namespace HotelAPI.Application.Abstractions.Services;

public interface IHotelService:IGenericService<HotelGetDto, HotelPostDto, HotelUpdateDto>
{
    Task<IDataResult<List<HotelGetDto>>> GetHotelsByRoomCountAsync(int roomCount, params string[] includes);
    Task<IDataResult<List<HotelGetDto>>> GetHotelsByCityIdAsync(int cityId, params string[] includes);

}
