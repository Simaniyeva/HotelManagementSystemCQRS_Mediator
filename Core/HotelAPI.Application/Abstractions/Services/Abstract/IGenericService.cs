﻿using HotelAPI.Application.Utilities.Results;

namespace HotelAPI.Application.Abstractions.Services
{
    public interface IGenericService<TGetDto,TPostDto,TUpdateDto> 
        where TGetDto : class,IDto,new()
        where TPostDto : class,IDto,new()
        where TUpdateDto : class,IDto,new()
    {
        Task<IDataResult<List<TGetDto>>> GetAllAsync(bool getDeleted, params string[] includes);
        Task<IDataResult<TGetDto>> GetByIdAsync(int id, params string[] includes);
        Task<IResult> CreateAsync(TPostDto dto);
        Task<IResult> UpdateAsync(TUpdateDto dto);
        Task<IResult> RecoverByIdAsync(int id);
        Task<IResult> SoftDeleteByIdAsync(int id);
        Task<IResult> HardDeleteByIdAsync(int id);
    }
}
