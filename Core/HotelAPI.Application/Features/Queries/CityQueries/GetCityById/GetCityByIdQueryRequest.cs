namespace HotelAPI.Application.Features.Queries.CityQueries.GetCityById;

public record GetCityByIdQueryRequest(int Id,bool isDeleted):IRequest<GetCityByIdQueryResponse>;

