
namespace HotelAPI.Application.Features.Queries.HotelQueries.GetAllDetailsOfHotels;

public record GetAllDetailsOfHotelsQueryRequest(bool isDeleted):IRequest<GetAllDetailsOfHotelsQueryResponse>;
