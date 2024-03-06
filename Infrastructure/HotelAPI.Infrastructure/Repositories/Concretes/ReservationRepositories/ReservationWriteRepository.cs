namespace HotelAPI.Infrastructure.Repositories.Concretes.ReservationRepositories;

public class ReservationWriteRepository : WriteRepository<Reservation>, IReservationWriteRepository
{
    public ReservationWriteRepository(HotelIdentityDbContext context) : base(context) { }
}