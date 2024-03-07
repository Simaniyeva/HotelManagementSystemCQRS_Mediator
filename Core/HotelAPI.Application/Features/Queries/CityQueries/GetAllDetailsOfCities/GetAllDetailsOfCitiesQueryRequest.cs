namespace HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;

public record GetAllDetailsOfCitiesQueryRequest(bool isDeleted=false) : IRequest<GetAllDetailsOfCitiesQueryResponse>;
