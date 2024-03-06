namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class CountryService : ICountryService
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly IMapper _mapper;

    public CountryService(ICountryReadRepository CountryReadRepository, ICountryWriteRepository CountryWriteRepository, IMapper mapper)
    {
        _countryReadRepository = CountryReadRepository;
        _countryWriteRepository = CountryWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<CountryGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Country> countries = getDeleted
            ? await _countryReadRepository.GetAllAsync(includes: includes)
            : await _countryReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (countries is null)
        {
            return new ErrorDataResult<List<CountryGetDto>>(Messages.NotFound(Messages.Country));
        }
        return new SuccessDataResult<List<CountryGetDto>>(_mapper.Map<List<CountryGetDto>>(countries));
    }

    public async Task<IDataResult<CountryGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Country Country = await _countryReadRepository.GetAsync(c => c.Id == id, includes);
        if (Country is null)
        {
            return new ErrorDataResult<CountryGetDto>(Messages.NotFound(Messages.Country));

        }
        return new SuccessDataResult<CountryGetDto>(_mapper.Map<CountryGetDto>(Country));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(CountryPostDto dto)
    {
        Country Country = _mapper.Map<Country>(dto);
        await _countryWriteRepository.CreateAsync(Country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<CountryGetDto>(Messages.NotFound(Messages.Country));
        }
        return new SuccessDataResult<CountryGetDto>(_mapper.Map<CountryGetDto>(Country));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(CountryUpdateDto dto)
    {
        Country Country = await _countryReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Country = _mapper.Map<Country>(dto);
        _countryWriteRepository.Update(Country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Country));
        }
        return new SuccessResult(Messages.Updated(Messages.Country));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Country Country = await _countryReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Country.entityStatus = EntityStatus.Active;
        _countryWriteRepository.Update(Country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Country));
        }
        return new SuccessResult(Messages.Recovered(Messages.Country));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Country Country = await _countryReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _countryWriteRepository.Delete(Country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Country));
        }
        return new SuccessResult(Messages.Deleted(Messages.Country));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Country Country = await _countryReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Country.entityStatus = EntityStatus.InActive;
        _countryWriteRepository.Update(Country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Country));
        }
        return new SuccessResult(Messages.Deleted(Messages.Country));
    }
    #endregion


}
