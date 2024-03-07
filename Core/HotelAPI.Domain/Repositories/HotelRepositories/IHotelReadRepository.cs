namespace HotelAPI.Domain.Repositories.HotelRepositories;

public interface IHotelReadRepository : IReadRepository<Hotel> {
    Task<List<Hotel>> GetAllCityDetailsAsync(Expression<Func<Hotel, bool>>? exp = null);

}