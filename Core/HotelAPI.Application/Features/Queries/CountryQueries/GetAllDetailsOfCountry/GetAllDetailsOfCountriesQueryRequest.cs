using HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;

namespace HotelAPI.Application.Features.Queries.CountryQueries.GetAllDetailsOfCountry;

public record GetAllDetailsOfCountriesQueryRequest(bool isDeleted) : IRequest<GetAllDetailsOfCountriesQueryResponse>;

