
namespace HotelAPI.Application.Features.Queries.HotelQueries.GetHotelById;

public record GetHotelByIdQueryRequest(bool isDeleted):IRequest<GetHotelByIdQueryResponse>;
