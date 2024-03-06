

using HotelAPI.Domain.Repositories.RoomEquipmentRepositories;

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class RoomService : IRoomService
{
    private readonly IRoomReadRepository _roomReadRepository;
    private readonly IRoomWriteRepository _roomWriteRepository;
    private readonly IRoomEquipmentWriteRepository _roomEquipmentWriteRepository;
    private readonly IMapper _mapper;

    public RoomService(IRoomReadRepository RoomReadRepository, IRoomWriteRepository RoomWriteRepository, IMapper mapper, IRoomEquipmentWriteRepository roomEquipmentWriteRepository)
    {
        _roomReadRepository = RoomReadRepository;
        _roomWriteRepository = RoomWriteRepository;
        _mapper = mapper;
        _roomEquipmentWriteRepository = roomEquipmentWriteRepository;
    }
    #region Get Requests

    public async Task<IDataResult<List<RoomGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Room> rooms = getDeleted
            ? await _roomReadRepository.GetAllAsync(includes: includes)
            : await _roomReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (rooms is null)
        {
            return new ErrorDataResult<List<RoomGetDto>>(Messages.NotFound(Messages.Room));
        }
        return new SuccessDataResult<List<RoomGetDto>>(_mapper.Map<List<RoomGetDto>>(rooms));
    }

    public async Task<IDataResult<RoomGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id, includes);
        if (Room is null)
        {
            return new ErrorDataResult<RoomGetDto>(Messages.NotFound(Messages.Room));

        }
        return new SuccessDataResult<RoomGetDto>(_mapper.Map<RoomGetDto>(Room));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(RoomPostDto dto)
    {
        Room room = _mapper.Map<Room>(dto);
        foreach (var image in dto.RoomImages)
        {
            byte[] bytes = Convert.FromBase64String(image.FileBase64);
            image.FileName = FileHelper.SavePhotoToFtp(bytes, image.FileName);
        }
        FillRoom(room, dto.EquipmentIds);
        await _roomWriteRepository.CreateAsync(room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<RoomGetDto>(Messages.NotFound(Messages.Room));
        }
        return new SuccessDataResult<RoomGetDto>(_mapper.Map<RoomGetDto>(room));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(RoomUpdateDto dto)
    {
        Room room = await _roomReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active, "RoomEquipments.Equipment", "Reviews");
        if (room.RoomEquipments.ToList().Count != 0)
        {
            foreach (RoomEquipment equipment in room.RoomEquipments.ToList())
            {
                _roomEquipmentWriteRepository.Delete(equipment);
                await _roomEquipmentWriteRepository.SaveAsync();
                room.RoomEquipments.Remove(equipment);
            }
        }
        foreach (var image in dto.RoomImages)
        {
            byte[] bytes = Convert.FromBase64String(image.FileBase64);
            image.FileName = FileHelper.SavePhotoToFtp(bytes, image.FileName);
        }
        room = _mapper.Map<Room>(dto);
        _roomWriteRepository.Update(room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Room));
        }
        return new SuccessResult(Messages.Updated(Messages.Room));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Room.entityStatus = EntityStatus.Active;
        _roomWriteRepository.Update(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Room));
        }
        return new SuccessResult(Messages.Recovered(Messages.Room));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _roomWriteRepository.Delete(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Room));
        }
        return new SuccessResult(Messages.Deleted(Messages.Room));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Room.entityStatus = EntityStatus.InActive;
        _roomWriteRepository.Update(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Room));
        }
        return new SuccessResult(Messages.Deleted(Messages.Room));
    }
    #endregion


    #region Private Methods
    private async Task FillRoom(Room room, List<int> EquipmentIds)
    {
        if (EquipmentIds.Count > 0)
        {
            await AddEquipments(room, EquipmentIds);
        }
    }

    private async Task AddEquipments(Room room, List<int> EquipmentIds)
    {
        foreach (int equipmentId in EquipmentIds)
        {
            RoomEquipment roomEquipment = new()
            {
                Room = room,
                EquipmentId = equipmentId
            };
            room.RoomEquipments.Add(roomEquipment);
        }
    }
    #endregion

}
