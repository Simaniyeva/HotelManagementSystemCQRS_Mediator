namespace HotelAPI.Application.Features.Queries.CountryQueries.GetAllCountry;

public record GetAllCountryQueryRequest(bool isDeleted) :IRequest<GetAllCountryQueryResponse>;

