namespace HotelAPI.Application.Features.Commands.EquipmentCommands.DeleteEquipment;

public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommandRequest, DeleteEquipmentCommandResponse>
{
    private readonly IEquipmentWriteRepository _equipmentWriteRepository;
    private readonly IEquipmentReadRepository _equipmentReadRepository;
    private readonly IMapper _mapper;

    public DeleteEquipmentCommandHandler(IEquipmentWriteRepository equipmentWriteRepository, IMapper mapper, IEquipmentReadRepository equipmentReadRepository)
    {
        _equipmentWriteRepository = equipmentWriteRepository;
        _mapper = mapper;
        _equipmentReadRepository = equipmentReadRepository;
    }

    public async Task<DeleteEquipmentCommandResponse> Handle(DeleteEquipmentCommandRequest request, CancellationToken cancellationToken)
    {
       Equipment equipment = await _equipmentReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        if (equipment != null)
        {
            equipment.entityStatus = EntityStatus.InActive;
            _equipmentWriteRepository.Update(equipment);
            await _equipmentWriteRepository.SaveAsync();
            return new DeleteEquipmentCommandResponse { Success = true };

        }
        return new DeleteEquipmentCommandResponse
        {
            Success = false,
            ErrorMessage = "Equipment is not found or not active"
        };


    }
}
