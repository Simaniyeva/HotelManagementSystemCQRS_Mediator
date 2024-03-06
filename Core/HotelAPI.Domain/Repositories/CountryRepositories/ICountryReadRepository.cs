namespace HotelAPI.Domain.Repositories.CountryRepositories;

public interface ICountryReadRepository : IReadRepository<Country>
{

    Task<List<Country>> GetAllDetailsOfCountries(Expression<Func<Country, bool>>? exp = null);
}
