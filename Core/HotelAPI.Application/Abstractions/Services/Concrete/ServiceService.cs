

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class ServiceService : IServiceService
{
    private readonly IServiceReadRepository _serviceReadRepository;
    private readonly IServiceWriteRepository _serviceWriteRepository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceReadRepository ServiceReadRepository, IServiceWriteRepository ServiceWriteRepository, IMapper mapper)
    {
        _serviceReadRepository = ServiceReadRepository;
        _serviceWriteRepository = ServiceWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<ServiceGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Service> services = getDeleted
            ? await _serviceReadRepository.GetAllAsync(includes: includes)
            : await _serviceReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (services is null)
        {
            return new ErrorDataResult<List<ServiceGetDto>>(Messages.NotFound(Messages.Service));
        }
        return new SuccessDataResult<List<ServiceGetDto>>(_mapper.Map<List<ServiceGetDto>>(services));
    }

    public async Task<IDataResult<ServiceGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Service Service = await _serviceReadRepository.GetAsync(c => c.Id == id, includes);
        if (Service is null)
        {
            return new ErrorDataResult<ServiceGetDto>(Messages.NotFound(Messages.Service));

        }
        return new SuccessDataResult<ServiceGetDto>(_mapper.Map<ServiceGetDto>(Service));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(ServicePostDto dto)
    {
        Service Service = _mapper.Map<Service>(dto);
        await _serviceWriteRepository.CreateAsync(Service);
        int result = await _serviceWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<ServiceGetDto>(Messages.NotFound(Messages.Service));
        }
        return new SuccessDataResult<ServiceGetDto>(_mapper.Map<ServiceGetDto>(Service));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(ServiceUpdateDto dto)
    {
        Service Service = await _serviceReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Service = _mapper.Map<Service>(dto);
        _serviceWriteRepository.Update(Service);
        int result = await _serviceWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Service));
        }
        return new SuccessResult(Messages.Updated(Messages.Service));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Service Service = await _serviceReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Service.entityStatus = EntityStatus.Active;
        _serviceWriteRepository.Update(Service);
        int result = await _serviceWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Service));
        }
        return new SuccessResult(Messages.Recovered(Messages.Service));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Service Service = await _serviceReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _serviceWriteRepository.Delete(Service);
        int result = await _serviceWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Service));
        }
        return new SuccessResult(Messages.Deleted(Messages.Service));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Service Service = await _serviceReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Service.entityStatus = EntityStatus.InActive;
        _serviceWriteRepository.Update(Service);
        int result = await _serviceWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Service));
        }
        return new SuccessResult(Messages.Deleted(Messages.Service));
    }
    #endregion


}
