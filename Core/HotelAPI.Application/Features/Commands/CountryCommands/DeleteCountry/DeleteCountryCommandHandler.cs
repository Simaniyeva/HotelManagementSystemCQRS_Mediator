using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;

namespace HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;


public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, DeleteCountryCommandResponse>
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly ICountryReadRepository _countryReadRepository;

    public DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }


    public async Task<DeleteCountryCommandResponse> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
    {
        Country country = await _countryReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        if (country is not null)
        {
            country.entityStatus = EntityStatus.InActive;
            _countryWriteRepository.Update(country);
            await _countryWriteRepository.SaveAsync();
            return new DeleteCountryCommandResponse
            {
                Success = true

            };
        }

        return new DeleteCountryCommandResponse
        {
            Success = false,
            ErrorMessage = "Country is not found or not active."
        };


    }
}
