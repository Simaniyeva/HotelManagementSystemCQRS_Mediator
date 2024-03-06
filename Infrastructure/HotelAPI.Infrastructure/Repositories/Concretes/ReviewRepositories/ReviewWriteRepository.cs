namespace HotelAPI.Infrastructure.Repositories.Concretes.ReviewRepositories;

public class ReviewWriteRepository : WriteRepository<Review>, IReviewWriteRepository
{
    public ReviewWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
