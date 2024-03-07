using HotelAPI.Domain.DTOs;

namespace HotelAPI.Application.Features.Commands.HotelCommands.CreateHotel;

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommandRequest, CreateHotelCommandResponse>
{
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IMapper _mapper;

    public CreateHotelCommandHandler(IHotelWriteRepository hotelWriteRepository, IMapper mapper)
    {
        _hotelWriteRepository = hotelWriteRepository;
        _mapper = mapper;
    }

    public async Task<CreateHotelCommandResponse> Handle(CreateHotelCommandRequest request, CancellationToken cancellationToken)
    {
        foreach (var image in request.HotelImages)
        {
            byte[] bytes = Convert.FromBase64String(image.FileBase64);
            image.FileName = FileHelper.SavePhotoToFtp(bytes, image.FileName);
        }
        Hotel hotel = _mapper.Map<Hotel>(request);
        await _hotelWriteRepository.CreateAsync(hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new CreateHotelCommandResponse
            {
                Result = new ErrorDataResult<HotelPostDto>(Messages.NotCreated(Messages.Hotel))
            };
        }

        return new CreateHotelCommandResponse
        {
            Result = new SuccessDataResult<HotelPostDto>(_mapper.Map<HotelPostDto>(hotel))
        };
    }
}
