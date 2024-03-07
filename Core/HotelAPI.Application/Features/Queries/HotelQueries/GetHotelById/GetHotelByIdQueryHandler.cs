
namespace HotelAPI.Application.Features.Queries.HotelQueries.GetHotelById;

public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQueryRequest, GetHotelByIdQueryResponse>
{
    private readonly IHotelReadRepository _hotelReadrepository;
    private readonly IMapper _mapper;

    public GetHotelByIdQueryHandler(IHotelReadRepository hotelReadrepository, IMapper mapper)
    {
        _hotelReadrepository = hotelReadrepository;
        _mapper = mapper;
    }

    public Task<GetHotelByIdQueryResponse> Handle(GetHotelByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
