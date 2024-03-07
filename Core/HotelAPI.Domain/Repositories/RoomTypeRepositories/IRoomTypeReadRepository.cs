namespace HotelAPI.Domain.Repositories.RoomTypeRepositories;

public interface IRoomTypeReadRepository : IReadRepository<RoomType> {
    Task<List<RoomType>> GetAllRoomTypesDetailsAsync(Expression<Func<RoomType, bool>>? exp = null);
}
