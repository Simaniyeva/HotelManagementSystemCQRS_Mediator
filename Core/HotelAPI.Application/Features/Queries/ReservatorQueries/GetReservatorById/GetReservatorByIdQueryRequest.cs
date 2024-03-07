namespace HotelAPI.Application.Features.Queries.ReservatorQueries.GetReservatorById;

public record GetReservatorByIdQueryRequest(int id):IRequest<GetReservatorByIdQueryResponse>;

