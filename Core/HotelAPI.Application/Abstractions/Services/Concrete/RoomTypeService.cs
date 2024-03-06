

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeReadRepository _roomTypeReadRepository;
    private readonly IRoomTypeWriteRepository _roomTypeWriteRepository;
    private readonly IMapper _mapper;

    public RoomTypeService(IRoomTypeReadRepository RoomTypeReadRepository, IRoomTypeWriteRepository RoomTypeWriteRepository, IMapper mapper)
    {
        _roomTypeReadRepository = RoomTypeReadRepository;
        _roomTypeWriteRepository = RoomTypeWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<RoomTypeGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<RoomType> roomtypes = getDeleted
            ? await _roomTypeReadRepository.GetAllAsync(includes: includes)
            : await _roomTypeReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (roomtypes is null)
        {
            return new ErrorDataResult<List<RoomTypeGetDto>>(Messages.NotFound(Messages.RoomType));
        }
        return new SuccessDataResult<List<RoomTypeGetDto>>(_mapper.Map<List<RoomTypeGetDto>>(roomtypes));
    }

    public async Task<IDataResult<RoomTypeGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        RoomType RoomType = await _roomTypeReadRepository.GetAsync(c => c.Id == id, includes);
        if (RoomType is null)
        {
            return new ErrorDataResult<RoomTypeGetDto>(Messages.NotFound(Messages.RoomType));

        }
        return new SuccessDataResult<RoomTypeGetDto>(_mapper.Map<RoomTypeGetDto>(RoomType));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(RoomTypePostDto dto)
    {
        RoomType RoomType = _mapper.Map<RoomType>(dto);
        await _roomTypeWriteRepository.CreateAsync(RoomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<RoomTypeGetDto>(Messages.NotFound(Messages.RoomType));
        }
        return new SuccessDataResult<RoomTypeGetDto>(_mapper.Map<RoomTypeGetDto>(RoomType));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(RoomTypeUpdateDto dto)
    {
        RoomType RoomType = await _roomTypeReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        RoomType = _mapper.Map<RoomType>(dto);
        _roomTypeWriteRepository.Update(RoomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.RoomType));
        }
        return new SuccessResult(Messages.Updated(Messages.RoomType));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        RoomType RoomType = await _roomTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        RoomType.entityStatus = EntityStatus.Active;
        _roomTypeWriteRepository.Update(RoomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.RoomType));
        }
        return new SuccessResult(Messages.Recovered(Messages.RoomType));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        RoomType RoomType = await _roomTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _roomTypeWriteRepository.Delete(RoomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.RoomType));
        }
        return new SuccessResult(Messages.Deleted(Messages.RoomType));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        RoomType RoomType = await _roomTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        RoomType.entityStatus = EntityStatus.InActive;
        _roomTypeWriteRepository.Update(RoomType);
        int result = await _roomTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.RoomType));
        }
        return new SuccessResult(Messages.Deleted(Messages.RoomType));
    }
    #endregion


}
