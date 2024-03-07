namespace HotelAPI.Application.Features.Queries.CityQueries.GetCityById;

public record GetCityByIdQueryRequest(int Id):IRequest<GetCityByIdQueryResponse>;

