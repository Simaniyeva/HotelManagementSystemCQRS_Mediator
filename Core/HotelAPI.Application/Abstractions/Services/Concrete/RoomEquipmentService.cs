

using HotelAPI.Application.DTOs.RoomEquipmentDtos;
using HotelAPI.Domain.Repositories.RoomEquipmentRepositories;

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class RoomEquipmentService : IRoomEquipmentService
{
    private readonly IRoomEquipmentReadRepository _roomEquipmentReadRepository;
    private readonly IRoomEquipmentWriteRepository _roomEquipmentWriteRepository;
    private readonly IMapper _mapper;

    public RoomEquipmentService(IRoomEquipmentReadRepository RoomEquipmentReadRepository, IRoomEquipmentWriteRepository RoomEquipmentWriteRepository, IMapper mapper)
    {
        _roomEquipmentReadRepository = RoomEquipmentReadRepository;
        _roomEquipmentWriteRepository = RoomEquipmentWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<RoomEquipmentGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<RoomEquipment> roomEquipments = getDeleted
            ? await _roomEquipmentReadRepository.GetAllAsync(includes: includes)
            : await _roomEquipmentReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (roomEquipments is null)
        {
            return new ErrorDataResult<List<RoomEquipmentGetDto>>(Messages.NotFound(Messages.RoomEquipment));
        }
        return new SuccessDataResult<List<RoomEquipmentGetDto>>(_mapper.Map<List<RoomEquipmentGetDto>>(roomEquipments));
    }

    public async Task<IDataResult<RoomEquipmentGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        RoomEquipment RoomEquipment = await _roomEquipmentReadRepository.GetAsync(c => c.Id == id, includes);
        if (RoomEquipment is null)
        {
            return new ErrorDataResult<RoomEquipmentGetDto>(Messages.NotFound(Messages.RoomEquipment));

        }
        return new SuccessDataResult<RoomEquipmentGetDto>(_mapper.Map<RoomEquipmentGetDto>(RoomEquipment));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(RoomEquipmentPostDto dto)
    {

        RoomEquipment RoomEquipment = _mapper.Map<RoomEquipment>(dto);
        await _roomEquipmentWriteRepository.CreateAsync(RoomEquipment);
        int result = await _roomEquipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<RoomEquipmentPostDto>(Messages.NotFound(Messages.RoomEquipment));
        }
        return new SuccessDataResult<RoomEquipmentPostDto>(_mapper.Map<RoomEquipmentPostDto>(RoomEquipment));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(RoomEquipmentUpdateDto dto)
    {
        RoomEquipment RoomEquipment = await _roomEquipmentReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        RoomEquipment = _mapper.Map<RoomEquipment>(dto);
        _roomEquipmentWriteRepository.Update(RoomEquipment);
        int result = await _roomEquipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.RoomEquipment));
        }
        return new SuccessResult(Messages.Updated(Messages.RoomEquipment));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        RoomEquipment RoomEquipment = await _roomEquipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        RoomEquipment.entityStatus = EntityStatus.Active;
        _roomEquipmentWriteRepository.Update(RoomEquipment);
        int result = await _roomEquipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.RoomEquipment));
        }
        return new SuccessResult(Messages.Recovered(Messages.RoomEquipment));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        RoomEquipment RoomEquipment = await _roomEquipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _roomEquipmentWriteRepository.Delete(RoomEquipment);
        int result = await _roomEquipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.RoomEquipment));
        }
        return new SuccessResult(Messages.Deleted(Messages.RoomEquipment));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        RoomEquipment RoomEquipment = await _roomEquipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        RoomEquipment.entityStatus = EntityStatus.InActive;
        _roomEquipmentWriteRepository.Update(RoomEquipment);
        int result = await _roomEquipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.RoomEquipment));
        }
        return new SuccessResult(Messages.Deleted(Messages.RoomEquipment));
    }
    #endregion


}
