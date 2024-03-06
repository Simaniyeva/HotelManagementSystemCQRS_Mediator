using HotelAPI.Domain.Entities;

namespace HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommandRequest, DeleteCityCommandResponse>
{
    private readonly ICityWriteRepository _cityWriteRepository;
    private readonly ICityReadRepository _cityReadRepository;
    private readonly IMapper _mapper;
    public DeleteCityCommandHandler(ICityWriteRepository writeRepository, ICityReadRepository cityReadRepository, IMapper mapper)
    {
        _cityWriteRepository = writeRepository;
        _cityReadRepository = cityReadRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommandRequest request, CancellationToken cancellationToken)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        if (city is not null)
        {
            city.entityStatus = EntityStatus.InActive;
            _cityWriteRepository.Update(city);
            await _cityWriteRepository.SaveAsync();
            return new DeleteCityCommandResponse
            {
                Success = true

            };
        }

        return new DeleteCityCommandResponse
        {
            Success = false,
            ErrorMessage = "City is not found or not active."
        };

    }

}
