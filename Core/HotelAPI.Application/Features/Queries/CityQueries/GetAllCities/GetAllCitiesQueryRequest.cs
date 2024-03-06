namespace HotelAPI.Application.Features.Queries.CityQueries.GetAllCities;

public record GetAllCitiesQueryRequest(bool isDeleted): IRequest<GetAllCitiesQueryResponse>;