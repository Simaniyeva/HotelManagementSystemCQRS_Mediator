namespace HotelAPI.Domain.Repositories.CityRepositories;

public interface ICityReadRepository : IReadRepository<City> {
    Task<List<City>> GetAllCityDetailsAsync(Expression<Func<City, bool>>? exp = null);

}