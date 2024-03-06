using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
using HotelAPI.Domain.DTOs;
using HotelAPI.Domain.Entities;
using HotelAPI.Domain.Repositories.CityRepositories;
using HotelAPI.Infrastructure.Repositories.Concretes.CityRepositories;
using MediatR;

namespace HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;

public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommandRequest, UpdateCityCommandResponse>

{
    readonly ICityReadRepository _cityReadRepository;
    readonly ICityWriteRepository _cityWriteRepository;
    readonly IMapper _mapper;

    public UpdateCityCommandHandler(ICityWriteRepository cityWriteRepository, IMapper mapper, ICityReadRepository cityReadRepository)
    {
        _cityWriteRepository = cityWriteRepository;
        _mapper = mapper;
        _cityReadRepository = cityReadRepository;
    }

    public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommandRequest request, CancellationToken cancellationToken)
    {
        City city = await _cityReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        city = _mapper.Map<City>(request);
        _cityWriteRepository.Update(city);
        int result = await _cityWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new UpdateCityCommandResponse
            {
                Result = new ErrorDataResult<CityUpdateDto>(Messages.NotUpdated(Messages.City))
            };
        }

        return new UpdateCityCommandResponse
        {
            Result = new SuccessDataResult<CityUpdateDto>(_mapper.Map<CityUpdateDto>(city))
        };
    }
}