namespace HotelAPI.Application.Features.Commands.CountryCommands.UpdateCountry;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommandRequest, UpdateCountryCommandResponse>

{
    readonly ICountryReadRepository _countryReadRepository;
    readonly ICountryWriteRepository _countryWriteRepository;
    readonly IMapper _mapper;

    public UpdateCountryCommandHandler(ICountryReadRepository countryReadRepository, ICountryWriteRepository countryWriteRepository)
    {
        _countryReadRepository = countryReadRepository;
        _countryWriteRepository = countryWriteRepository;
    }

    public async Task<UpdateCountryCommandResponse> Handle(UpdateCountryCommandRequest request, CancellationToken cancellationToken)
    {
        Country country = await _countryReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        country = _mapper.Map<Country>(request);
        _countryWriteRepository.Update(country);
        int result = await _countryWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new UpdateCountryCommandResponse
            {
                Result = new ErrorDataResult<CountryUpdateDto>(Messages.NotUpdated(Messages.Country))
            };
        }

        return new UpdateCountryCommandResponse
        {
            Result = new SuccessDataResult<CountryUpdateDto>(_mapper.Map<CountryUpdateDto>(country))
        };
    }
}
