namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentReadRepository _equipmentReadRepository;
    private readonly IEquipmentWriteRepository _equipmentWriteRepository;
    private readonly IMapper _mapper;

    public EquipmentService(IEquipmentReadRepository EquipmentReadRepository, IEquipmentWriteRepository EquipmentWriteRepository, IMapper mapper)
    {
        _equipmentReadRepository = EquipmentReadRepository;
        _equipmentWriteRepository = EquipmentWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<EquipmentGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Equipment> equipments = getDeleted
            ? await _equipmentReadRepository.GetAllAsync(includes: includes)
            : await _equipmentReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (equipments is null)
        {
            return new ErrorDataResult<List<EquipmentGetDto>>(Messages.NotFound(Messages.Equipment));
        }
        return new SuccessDataResult<List<EquipmentGetDto>>(_mapper.Map<List<EquipmentGetDto>>(equipments));
    }

    public async Task<IDataResult<EquipmentGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Equipment Equipment = await _equipmentReadRepository.GetAsync(c => c.Id == id, includes);
        if (Equipment is null)
        {
            return new ErrorDataResult<EquipmentGetDto>(Messages.NotFound(Messages.Equipment));

        }
        return new SuccessDataResult<EquipmentGetDto>(_mapper.Map<EquipmentGetDto>(Equipment));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(EquipmentPostDto dto)
    {
        Equipment Equipment = _mapper.Map<Equipment>(dto);
        await _equipmentWriteRepository.CreateAsync(Equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<EquipmentGetDto>(Messages.NotFound(Messages.Equipment));
        }
        return new SuccessDataResult<EquipmentGetDto>(_mapper.Map<EquipmentGetDto>(Equipment));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(EquipmentUpdateDto dto)
    {
        Equipment Equipment = await _equipmentReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Equipment = _mapper.Map<Equipment>(dto);
        _equipmentWriteRepository.Update(Equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Equipment));
        }
        return new SuccessResult(Messages.Updated(Messages.Equipment));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Equipment Equipment = await _equipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Equipment.entityStatus = EntityStatus.Active;
        _equipmentWriteRepository.Update(Equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Equipment));
        }
        return new SuccessResult(Messages.Recovered(Messages.Equipment));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Equipment Equipment = await _equipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _equipmentWriteRepository.Delete(Equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Equipment));
        }
        return new SuccessResult(Messages.Deleted(Messages.Equipment));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Equipment Equipment = await _equipmentReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Equipment.entityStatus = EntityStatus.InActive;
        _equipmentWriteRepository.Update(Equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Equipment));
        }
        return new SuccessResult(Messages.Deleted(Messages.Equipment));
    }
    #endregion


}
