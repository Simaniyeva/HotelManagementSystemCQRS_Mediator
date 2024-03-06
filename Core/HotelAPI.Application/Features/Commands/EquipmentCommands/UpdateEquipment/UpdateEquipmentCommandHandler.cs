
using HotelAPI.Application.Features.Commands.CountryCommands.UpdateCountry;
using HotelAPI.Domain.Entities;

namespace HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;

public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommandRequest, UpdateEquipmentCommandResponse>
{
    private readonly IEquipmentWriteRepository _equipmentWriteRepository;
    private readonly IEquipmentReadRepository _equipmentReadRepository; 
    private readonly IMapper _mapper;

    public UpdateEquipmentCommandHandler(IEquipmentWriteRepository equipmentWriteRepository, IEquipmentReadRepository equipmentReadRepository, IMapper mapper)
    {
        _equipmentWriteRepository = equipmentWriteRepository;
        _equipmentReadRepository = equipmentReadRepository;
        _mapper = mapper;
    }

    public async Task<UpdateEquipmentCommandResponse> Handle(UpdateEquipmentCommandRequest request, CancellationToken cancellationToken)
    {
        Equipment equipment = await _equipmentReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        equipment = _mapper.Map<Equipment>(request);
        _equipmentWriteRepository.Update(equipment);
        int result = await _equipmentWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new UpdateEquipmentCommandResponse
            {
                Result = new ErrorDataResult<EquipmentUpdateDto>(Messages.NotUpdated(Messages.Equipment))
            };
        }

        return new UpdateEquipmentCommandResponse
        {
            Result = new SuccessDataResult<EquipmentUpdateDto>(_mapper.Map<EquipmentUpdateDto>(equipment))
        };
    }
}
