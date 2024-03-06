namespace HotelAPI.Application.Features.Queries.EquipmentQueries.GetEquipmentById;

public record GetEquipmentByIdQueryRequest(bool isDeleted):IRequest<GetEquipmentByIdQueryResponse>;
