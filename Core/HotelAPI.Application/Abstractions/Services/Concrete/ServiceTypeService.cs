

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class ServiceTypeService : IServiceTypeService
{
    private readonly IServiceTypeReadRepository _serviceTypeReadRepository;
    private readonly IServiceTypeWriteRepository _serviceTypeWriteRepository;
    private readonly IMapper _mapper;

    public ServiceTypeService(IServiceTypeReadRepository ServiceTypeReadRepository, IServiceTypeWriteRepository ServiceTypeWriteRepository, IMapper mapper)
    {
        _serviceTypeReadRepository = ServiceTypeReadRepository;
        _serviceTypeWriteRepository = ServiceTypeWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<ServiceTypeGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<ServiceType> serviceTypes = getDeleted
            ? await _serviceTypeReadRepository.GetAllAsync(includes: includes)
            : await _serviceTypeReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (serviceTypes is null)
        {
            return new ErrorDataResult<List<ServiceTypeGetDto>>(Messages.NotFound(Messages.ServiceType));
        }
        return new SuccessDataResult<List<ServiceTypeGetDto>>(_mapper.Map<List<ServiceTypeGetDto>>(serviceTypes));
    }

    public async Task<IDataResult<ServiceTypeGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        ServiceType ServiceType = await _serviceTypeReadRepository.GetAsync(c => c.Id == id, includes);
        if (ServiceType is null)
        {
            return new ErrorDataResult<ServiceTypeGetDto>(Messages.NotFound(Messages.ServiceType));

        }
        return new SuccessDataResult<ServiceTypeGetDto>(_mapper.Map<ServiceTypeGetDto>(ServiceType));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(ServiceTypePostDto dto)
    {
        ServiceType ServiceType = _mapper.Map<ServiceType>(dto);
        await _serviceTypeWriteRepository.CreateAsync(ServiceType);
        int result = await _serviceTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<ServiceTypeGetDto>(Messages.NotFound(Messages.ServiceType));
        }
        return new SuccessDataResult<ServiceTypeGetDto>(_mapper.Map<ServiceTypeGetDto>(ServiceType));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(ServiceTypeUpdateDto dto)
    {
        ServiceType ServiceType = await _serviceTypeReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        ServiceType = _mapper.Map<ServiceType>(dto);
        _serviceTypeWriteRepository.Update(ServiceType);
        int result = await _serviceTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.ServiceType));
        }
        return new SuccessResult(Messages.Updated(Messages.ServiceType));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        ServiceType ServiceType = await _serviceTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        ServiceType.entityStatus = EntityStatus.Active;
        _serviceTypeWriteRepository.Update(ServiceType);
        int result = await _serviceTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.ServiceType));
        }
        return new SuccessResult(Messages.Recovered(Messages.ServiceType));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        ServiceType ServiceType = await _serviceTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _serviceTypeWriteRepository.Delete(ServiceType);
        int result = await _serviceTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.ServiceType));
        }
        return new SuccessResult(Messages.Deleted(Messages.ServiceType));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        ServiceType ServiceType = await _serviceTypeReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        ServiceType.entityStatus = EntityStatus.InActive;
        _serviceTypeWriteRepository.Update(ServiceType);
        int result = await _serviceTypeWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.ServiceType));
        }
        return new SuccessResult(Messages.Deleted(Messages.ServiceType));
    }
    #endregion


}
