
namespace HotelAPI.Application.Features.Queries.EquipmentQueries.GetEquipmentById;

public class GetEquipmentByIdQueryHandler : IRequestHandler<GetEquipmentByIdQueryRequest, GetEquipmentByIdQueryResponse>
{
    private readonly IEquipmentReadRepository _equipmentReadRepository;
    private readonly IMapper _mapper;

    public GetEquipmentByIdQueryHandler(IEquipmentReadRepository equipmentReadRepository, IMapper mapper)
    {
        _equipmentReadRepository = equipmentReadRepository;
        _mapper = mapper;
    }

    public Task<GetEquipmentByIdQueryResponse> Handle(GetEquipmentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
