namespace HotelAPI.Infrastructure.Repositories.Concretes.ReviewRepositories;

public class ReviewReadRepository : ReadRepository<Review>, IReviewReadRepository
{
    public ReviewReadRepository(HotelIdentityDbContext context) : base(context) { }
}
