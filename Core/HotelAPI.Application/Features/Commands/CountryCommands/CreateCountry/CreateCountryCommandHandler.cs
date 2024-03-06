using HotelAPI.Domain.Entities;

namespace HotelAPI.Application.Features.Commands.CountryCommands.CreateCountry;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommandRequest, CreateCountryCommandResponse>
{
        private readonly IMapper _mapper;
        private readonly ICountryWriteRepository _countryWriteRepository;

    public CreateCountryCommandHandler(IMapper mapper, ICountryWriteRepository countryWriteRepository)
    {
        _mapper = mapper;
        _countryWriteRepository = countryWriteRepository;
    }

    public async Task<CreateCountryCommandResponse> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            Country country = _mapper.Map<Country>(request);
            await _countryWriteRepository.CreateAsync(country);
            int result = await _countryWriteRepository.SaveAsync();
            if (result is 0)
            {
                return new CreateCountryCommandResponse
                {
                    Result = new ErrorDataResult<CountryPostDto>(Messages.NotCreated(Messages.Country))
                };
            }

        return new CreateCountryCommandResponse
        {
            Result = new SuccessDataResult<CountryPostDto>(_mapper.Map<CountryPostDto>(country))

            };
        }
    }

