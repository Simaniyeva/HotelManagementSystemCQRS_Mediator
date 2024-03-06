
using HotelAPI.Application.Features.Queries.CountryQueries.GetAllCountry;

namespace HotelAPI.Application.Features.Queries.EquipmentQueries.GetAllEquipments;

public class GetAllEquipmentsQueryHandler : IRequestHandler<GetAllEquipmentsQueryRequest, GetAllEquipmentsQueryResponse>
{
    private readonly IEquipmentReadRepository _equipmentReadRepository;
    private readonly IMapper _mapper;

    public GetAllEquipmentsQueryHandler(IEquipmentReadRepository equipmentReadRepository, IMapper mapper)
    {
        _equipmentReadRepository = equipmentReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllEquipmentsQueryResponse> Handle(GetAllEquipmentsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Equipment> equipments = request.isDeleted
          ? await _equipmentReadRepository.GetAllAsync()
          : await _equipmentReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active);
        if (equipments is null)
        {
            return new GetAllEquipmentsQueryResponse
            {
                Result = new ErrorDataResult<List<EquipmentGetDto>>(Messages.NotFound(Messages.Equipment))
            };

        }
        return new GetAllEquipmentsQueryResponse
        {
            Result = new SuccessDataResult<List<EquipmentGetDto>>(_mapper.Map<List<EquipmentGetDto>>(equipments))
        };
    }
}
