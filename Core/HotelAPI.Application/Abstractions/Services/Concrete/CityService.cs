namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class CityService : ICityService
{
    private readonly ICityReadRepository _cityReadRepository;
    private readonly ICityWriteRepository _cityWriteRepository;
    private readonly IMapper _mapper;

    public CityService(ICityReadRepository cityReadRepository, ICityWriteRepository cityWriteRepository, IMapper mapper)
    {
        _cityReadRepository = cityReadRepository;
        _cityWriteRepository = cityWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<CityGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<City> cities = getDeleted
            ? await _cityReadRepository.GetAllAsync(includes: includes)
            : await _cityReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (cities is null)
        {
            return new ErrorDataResult<List<CityGetDto>>(Messages.NotFound(Messages.City));
        }
        return new SuccessDataResult<List<CityGetDto>>(_mapper.Map<List<CityGetDto>>(cities));
    }

    public async Task<IDataResult<CityGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == id, includes);
        if (city is null)
        {
            return new ErrorDataResult<CityGetDto>(Messages.NotFound(Messages.City));

        }
        return new SuccessDataResult<CityGetDto>(_mapper.Map<CityGetDto>(city));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(CityPostDto dto)
    {
        
        City city = _mapper.Map<City>(dto);
        await _cityWriteRepository.CreateAsync(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<CityPostDto>(Messages.NotFound(Messages.City));
        }
        return new SuccessDataResult<CityPostDto>(_mapper.Map<CityPostDto>(city));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(CityUpdateDto dto)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        city = _mapper.Map<City>(dto);
        _cityWriteRepository.Update(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.City));
        }
        return new SuccessResult(Messages.Updated(Messages.City));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        city.entityStatus = EntityStatus.Active;
        _cityWriteRepository.Update(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.City));
        }
        return new SuccessResult(Messages.Recovered(Messages.City));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive || c.entityStatus == EntityStatus.Active);
        _cityWriteRepository.Delete(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.City));
        }
        return new SuccessResult(Messages.Deleted(Messages.City));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        city.entityStatus = EntityStatus.InActive;
        _cityWriteRepository.Update(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.City));
        }
        return new SuccessResult(Messages.Deleted(Messages.City));
    }
    #endregion


}
