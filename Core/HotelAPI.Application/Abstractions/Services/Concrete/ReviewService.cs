using HotelAPI.Domain.Repositories.HotelImageRepositories;

namespace HotelAPI.Application.Abstractions.Services.Concrete;
public class ReviewService : IReviewService
{
    private readonly IReviewReadRepository _reviewReadRepository;
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IReservatorReadRepository _reservatorReadRepository;
    private readonly IReservatorWriteRepository _reservatorWriteRepository;
    private readonly IReviewWriteRepository _reviewWriteRepository;
    private readonly IMapper _mapper;

    public ReviewService(IReviewReadRepository ReviewReadRepository, IReviewWriteRepository ReviewWriteRepository, IMapper mapper, IHotelReadRepository hotelReadRepository, IReservatorReadRepository reservatorReadRepository, IHotelWriteRepository hotelWriteRepository, IReservatorWriteRepository reservatorWriteRepository)
    {
        _reviewReadRepository = ReviewReadRepository;
        _reviewWriteRepository = ReviewWriteRepository;
        _hotelReadRepository = hotelReadRepository;
        _reservatorReadRepository = reservatorReadRepository;
        _hotelWriteRepository = hotelWriteRepository;
        _reservatorWriteRepository = reservatorWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<ReviewGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Review> reviews = getDeleted
            ? await _reviewReadRepository.GetAllAsync(includes: includes)
            : await _reviewReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (reviews is null)
        {
            return new ErrorDataResult<List<ReviewGetDto>>(Messages.NotFound(Messages.Review));
        }
        return new SuccessDataResult<List<ReviewGetDto>>(_mapper.Map<List<ReviewGetDto>>(reviews));
    }

    public async Task<IDataResult<ReviewGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Review Review = await _reviewReadRepository.GetAsync(c => c.Id == id, includes);
        if (Review is null)
        {
            return new ErrorDataResult<ReviewGetDto>(Messages.NotFound(Messages.Review));

        }
        return new SuccessDataResult<ReviewGetDto>(_mapper.Map<ReviewGetDto>(Review));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(ReviewPostDto dto)
    {
        Review Review = _mapper.Map<Review>(dto);
        await _reviewWriteRepository.CreateAsync(Review);
        int result = await _reviewWriteRepository.SaveAsync();
        Hotel hotel = await _hotelReadRepository.GetAsync(h => h.Id == dto.HotelId, "Rooms", "Reviews");
        _hotelWriteRepository.Update(hotel);
        Reservator reservator =await _reservatorReadRepository.GetAsync(h => h.Id == dto.ReservatorId, "Reservations", "Reviews");
        _reservatorWriteRepository.Update(reservator);
        await _hotelWriteRepository.SaveAsync();
        await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<ReviewGetDto>(Messages.NotFound(Messages.Review));
        }
        return new SuccessDataResult<ReviewGetDto>(_mapper.Map<ReviewGetDto>(Review));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(ReviewUpdateDto dto)
    {
        Review Review = await _reviewReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Review = _mapper.Map<Review>(dto);
        _reviewWriteRepository.Update(Review);
        int result = await _reviewWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Review));
        }
        return new SuccessResult(Messages.Updated(Messages.Review));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Review Review = await _reviewReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Review.entityStatus = EntityStatus.Active;
        _reviewWriteRepository.Update(Review);
        int result = await _reviewWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Review));
        }
        return new SuccessResult(Messages.Recovered(Messages.Review));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Review Review = await _reviewReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _reviewWriteRepository.Delete(Review);
        int result = await _reviewWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Review));
        }
        return new SuccessResult(Messages.Deleted(Messages.Review));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Review Review = await _reviewReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Review.entityStatus = EntityStatus.InActive;
        _reviewWriteRepository.Update(Review);
        int result = await _reviewWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Review));
        }
        return new SuccessResult(Messages.Deleted(Messages.Review));
    }
    #endregion


}
