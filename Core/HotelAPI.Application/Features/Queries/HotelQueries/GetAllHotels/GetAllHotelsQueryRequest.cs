namespace HotelAPI.Application.Features.Queries.HotelQueries.GetAllHotels;

public record GetAllHotelsQueryRequest(bool isDeleted):IRequest<GetAllHotelsQueryResponse>;
