namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class ReservatorService : IReservatorService
{
    private readonly IReservatorReadRepository _reservatorReadRepository;
    private readonly IReservatorWriteRepository _reservatorWriteRepository;
    private readonly IMapper _mapper;

    public ReservatorService(IReservatorReadRepository ReservatorReadRepository, IReservatorWriteRepository ReservatorWriteRepository, IMapper mapper)
    {
        _reservatorReadRepository = ReservatorReadRepository;
        _reservatorWriteRepository = ReservatorWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<ReservatorGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Reservator> reservators = getDeleted
            ? await _reservatorReadRepository.GetAllAsync(includes: includes)
            : await _reservatorReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (reservators is null)
        {
            return new ErrorDataResult<List<ReservatorGetDto>>(Messages.NotFound(Messages.Reservator));
        }
        return new SuccessDataResult<List<ReservatorGetDto>>(_mapper.Map<List<ReservatorGetDto>>(reservators));
    }

    public async Task<IDataResult<ReservatorGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Reservator Reservator = await _reservatorReadRepository.GetAsync(c => c.Id == id, includes);
        if (Reservator is null)
        {
            return new ErrorDataResult<ReservatorGetDto>(Messages.NotFound(Messages.Reservator));

        }
        return new SuccessDataResult<ReservatorGetDto>(_mapper.Map<ReservatorGetDto>(Reservator));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(ReservatorPostDto dto)
    {
        Reservator Reservator = _mapper.Map<Reservator>(dto);
        await _reservatorWriteRepository.CreateAsync(Reservator);
        int result = await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<ReservatorGetDto>(Messages.NotFound(Messages.Reservator));
        }
        return new SuccessDataResult<ReservatorGetDto>(_mapper.Map<ReservatorGetDto>(Reservator));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(ReservatorUpdateDto dto)
    {
        Reservator Reservator = await _reservatorReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Reservator = _mapper.Map<Reservator>(dto);
        _reservatorWriteRepository.Update(Reservator);
        int result = await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Reservator));
        }
        return new SuccessResult(Messages.Updated(Messages.Reservator));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Reservator Reservator = await _reservatorReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Reservator.entityStatus = EntityStatus.Active;
        _reservatorWriteRepository.Update(Reservator);
        int result = await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Reservator));
        }
        return new SuccessResult(Messages.Recovered(Messages.Reservator));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Reservator Reservator = await _reservatorReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _reservatorWriteRepository.Delete(Reservator);
        int result = await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Reservator));
        }
        return new SuccessResult(Messages.Deleted(Messages.Reservator));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Reservator Reservator = await _reservatorReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Reservator.entityStatus = EntityStatus.InActive;
        _reservatorWriteRepository.Update(Reservator);
        int result = await _reservatorWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Reservator));
        }
        return new SuccessResult(Messages.Deleted(Messages.Reservator));
    }
    #endregion


}
