namespace HotelAPI.Application.Features.Queries.RoomTypeQueries.GetAllRoomTypes;

public record GetAllRoomTypesQueryRequest(bool isDeleted):IRequest<GetAllRoomTypesQueryResponse>;
