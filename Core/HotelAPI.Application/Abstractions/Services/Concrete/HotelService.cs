using HotelAPI.Application.Helpers;
using HotelAPI.Application.Utilities.Results;
using HotelAPI.Domain.Repositories.HotelImageRepositories;
using HotelAPI.Infrastructure.Repositories.Concretes.HotelRepositories;
using HotelAPI.Infrastructure.Utilities.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;
using IResult = HotelAPI.Application.Utilities.Results.IResult;

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class HotelService : IHotelService
{
    private readonly IHotelImageReadRepository _hotelImageReadRepository;
    private readonly IHotelImageWriteRepository _hotelImageWriteRepository;
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IMapper _mapper;

    public HotelService(IHotelImageReadRepository hotelImageReadRepository, IHotelImageWriteRepository hotelImageWriteRepository, IHotelReadRepository hotelReadRepository, IHotelWriteRepository hotelWriteRepository, IMapper mapper)
    {
        _hotelImageReadRepository = hotelImageReadRepository;
        _hotelImageWriteRepository = hotelImageWriteRepository;
        _hotelReadRepository = hotelReadRepository;
        _hotelWriteRepository = hotelWriteRepository;
        _mapper = mapper;
    }

    #region Get Requests

    public async Task<IDataResult<List<HotelGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Hotel> hotels = getDeleted
            ? await _hotelReadRepository.GetAllAsync(includes: includes)
            : await _hotelReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (hotels is null)
        {
            return new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel));
        }
        return new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(hotels));
    }

    public async Task<IDataResult<HotelGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id, includes);
        if (Hotel is null)
        {
            return new ErrorDataResult<HotelGetDto>(Messages.NotFound(Messages.Hotel));

        }
        return new SuccessDataResult<HotelGetDto>(_mapper.Map<HotelGetDto>(Hotel));

    }

    public async Task<IDataResult<List<HotelGetDto>>> GetHotelsByRoomCountAsync(int roomCount, params string[] includes)
    {
        List<Hotel> hotels = await _hotelReadRepository.GetAllAsync(c => c.Rooms.Count == roomCount, includes);
        if (hotels is null)
        {
            return new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel));

        }
        return new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(hotels));

    }

    public async Task<IDataResult<List<HotelGetDto>>> GetHotelsByCityIdAsync(int cityId, params string[] includes)
    {
        List<Hotel> hotels = await _hotelReadRepository.GetAllAsync(c => c.CityId == cityId, includes);
        if (hotels is null)
        {
            return new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel));

        }
        return new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(hotels));
    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(HotelPostDto dto)
    {

        foreach (var image in dto.HotelImages)
        {
            byte[] bytes = Convert.FromBase64String(image.FileBase64);
            image.FileName = FileHelper.SavePhotoToFtp(bytes, image.FileName);
        }
        Hotel hotel = _mapper.Map<Hotel>(dto);
        await _hotelWriteRepository.CreateAsync(hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<HotelGetDto>(Messages.NotFound(Messages.Hotel));
        }
        return new SuccessDataResult<HotelGetDto>(_mapper.Map<HotelGetDto>(hotel));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(HotelUpdateDto dto)
    {
        Hotel hotel = await _hotelReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active, "HotelImages", "Reviews");
        foreach (var image in dto.HotelImages)
        {
            byte[] bytes = Convert.FromBase64String(image.FileBase64);
            image.FileName = FileHelper.SavePhotoToFtp(bytes, image.FileName);
        }
        dto.TotalRating = hotel.Reviews is not null ? (decimal)hotel.Reviews.Average(r => (int)r.Rating) : 0;

        hotel = _mapper.Map<Hotel>(dto);
        _hotelWriteRepository.Update(hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Hotel));
        }
        return new SuccessResult(Messages.Updated(Messages.Hotel));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Hotel.entityStatus = EntityStatus.Active;
        _hotelWriteRepository.Update(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Hotel));
        }
        return new SuccessResult(Messages.Recovered(Messages.Hotel));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _hotelWriteRepository.Delete(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Hotel));
        }
        return new SuccessResult(Messages.Deleted(Messages.Hotel));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Hotel.entityStatus = EntityStatus.InActive;
        _hotelWriteRepository.Update(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Hotel));
        }
        return new SuccessResult(Messages.Deleted(Messages.Hotel));
    }


    #endregion

    //#region Private Methods
    //private async void FillHotel(Hotel hotel, List<IFormFile> files)
    //{
    //    if (files is not null)
    //    {
    //        AddHotelImages(hotel, files);
    //    }

    //}
    //private async void AddHotelImages(Hotel hotel, List<IFormFile> files)
    //{
    //    foreach (IFormFile file in files)
    //    {
    //        HotelImage image = new()
    //        {
    //            Hotel = hotel,
    //            ImagePath = file.FileCreate(_env.WebRootPath, "uploads/hotel")
    //        };
    //        hotel.HotelImages.Add(image);
    //    }
    //}


    //#endregion


}
