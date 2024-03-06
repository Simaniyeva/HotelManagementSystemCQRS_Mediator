﻿using HotelAPI.Application.DTOs.RoleDtos;

namespace HotelAPI.Application.Abstractions.Services.Abstract;

public interface IRoleService
{
    Task<IDataResult<List<RoleGetDto>>> GetAllAsync();
    Task<IDataResult<RoleGetDto>> GetByIdAsync(string iD);
    Task<IResult> CreateAsync(RolePostDto dto);
    Task<IResult> UpdateAsync(RoleUpdateDto dto);
    Task<IResult> HardDeleteByIdAsync(string id);

}
