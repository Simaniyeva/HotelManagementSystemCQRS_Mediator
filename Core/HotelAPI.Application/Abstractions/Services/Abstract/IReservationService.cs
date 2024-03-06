using HotelAPI.Application.Utilities.Results;

namespace HotelAPI.Application.Abstractions.Services.Abstract;

public interface IReservationService : IGenericService<ReservationGetDto, ReservationPostDto, ReservationUpdateDto> 
{
    Task<IDataResult<List<ReservationGetDto>>> GetReservationsforAdminAsync(int userId,bool getDeleted, params string[] includes);
    Task<IDataResult<List<ReservationGetDto>>> GetReservationsforUserAsync();


}

