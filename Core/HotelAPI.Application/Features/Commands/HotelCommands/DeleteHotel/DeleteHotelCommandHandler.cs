namespace HotelAPI.Application.Features.Commands.HotelCommands.DeleteHotel;

public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommandRequest, DeleteHotelCommandResponse>
{
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IHotelReadRepository _hotelReadRepository;

    public DeleteHotelCommandHandler(IHotelWriteRepository hotelWriteRepository, IHotelReadRepository hotelReadRepository)
    {
        _hotelWriteRepository = hotelWriteRepository;
        _hotelReadRepository = hotelReadRepository;
    }

    public async Task<DeleteHotelCommandResponse> Handle(DeleteHotelCommandRequest request, CancellationToken cancellationToken)
    {
        Hotel hotel = await _hotelReadRepository.GetAsync(c => c.Id == request.id && c.entityStatus == EntityStatus.Active);
        if (hotel is not null)
        {
            hotel.entityStatus = EntityStatus.InActive;
            _hotelWriteRepository.Update(hotel);
            await _hotelWriteRepository.SaveAsync();
            return new DeleteHotelCommandResponse
            {
                Success = true

            };
        }

        return new DeleteHotelCommandResponse
        {
            Success = false,
            ErrorMessage = "Hotel is not found or not active."
        };

    }
}
