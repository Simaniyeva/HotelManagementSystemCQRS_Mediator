
using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
using HotelAPI.Domain.Entities;
using System.Diagnostics.Metrics;

namespace HotelAPI.Application.Features.Commands.EquipmentCommands.CreateEquipment;

public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommandRequest, CreateEquipmentCommandResponse>
{
    private readonly IEquipmentWriteRepository _equipmentWriteRepository;
    private readonly IMapper _mapper;

    public CreateEquipmentCommandHandler(IEquipmentWriteRepository equipmentWriteRepository, IMapper mapper)
    {
        _equipmentWriteRepository = equipmentWriteRepository;
        _mapper = mapper;
    }

    public async Task<CreateEquipmentCommandResponse> Handle(CreateEquipmentCommandRequest request, CancellationToken cancellationToken)
    {
        Equipment equipment = _mapper.Map<Equipment>(request);
        await _equipmentWriteRepository.CreateAsync(equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new CreateEquipmentCommandResponse
            {
                Result = new ErrorDataResult<EquipmentPostDto>(Messages.NotCreated(Messages.Equipment))
            };
        }

        return new CreateEquipmentCommandResponse
        {
            Result = new SuccessDataResult<EquipmentPostDto>(_mapper.Map<EquipmentPostDto>(equipment))
        };
    }
}
