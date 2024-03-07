namespace HotelAPI.Application.Features.Queries.RoomTypeQueries.GetRoomTypeById;

public record GetRoomTypeByIdQueryRequest(bool isDeleted):IRequest<GetRoomTypeByIdQueryResponse>;
