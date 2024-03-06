namespace HotelAPI.Application.Features.Queries.EquipmentQueries.GetAllEquipments;

public record GetAllEquipmentsQueryRequest(bool isDeleted):IRequest<GetAllEquipmentsQueryResponse>;
