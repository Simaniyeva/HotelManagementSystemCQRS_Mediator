namespace HotelAPI.Application.Features.Commands.HotelCommands.UpdateHotel;

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommandRequest, UpdateHotelCommandResponse>
{
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IMapper _mapper;

    public UpdateHotelCommandHandler(IHotelReadRepository hotelReadRepository, IHotelWriteRepository hotelWriteRepository, IMapper mapper)
    {
        _hotelReadRepository = hotelReadRepository;
        _hotelWriteRepository = hotelWriteRepository;
        _mapper = mapper;
    }

    public async  Task<UpdateHotelCommandResponse> Handle(UpdateHotelCommandRequest request, CancellationToken cancellationToken)
    {
        Hotel hotel = await _hotelReadRepository.GetAsync(c => c.Id == request.Id && c.entityStatus == EntityStatus.Active);
        hotel = _mapper.Map<Hotel>(request);
        _hotelWriteRepository.Update(hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new UpdateHotelCommandResponse
            {
                Result = new ErrorDataResult<HotelUpdateDto>(Messages.NotUpdated(Messages.Hotel))
            };
        }

        return new UpdateHotelCommandResponse
        {
            Result = new SuccessDataResult<HotelUpdateDto>(_mapper.Map<HotelUpdateDto>(hotel))
        };
    }
}
