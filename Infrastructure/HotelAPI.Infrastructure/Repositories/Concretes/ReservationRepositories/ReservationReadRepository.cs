namespace HotelAPI.Infrastructure.Repositories.Concretes.ReservationRepositories;

public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
{
    public ReservationReadRepository(HotelIdentityDbContext context) : base(context) { }
}
