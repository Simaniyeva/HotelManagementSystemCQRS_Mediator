﻿global using AutoMapper;
global using HotelAPI.Application.Abstractions.Services;
global using HotelAPI.Application.Abstractions.Services.Abstract;
global using HotelAPI.Application.DTOs.EquipmentDtos;
global using HotelAPI.Application.DTOs.HotelDtos;
global using HotelAPI.Application.DTOs.ReservationDtos;
global using HotelAPI.Application.DTOs.ReservatorDtos;
global using HotelAPI.Application.DTOs.ReviewDtos;
global using HotelAPI.Application.DTOs.RoleDtos;
global using HotelAPI.Application.DTOs.RoomDtos;
global using HotelAPI.Application.DTOs.ServiceDtos;
global using HotelAPI.Application.DTOs.ServiceTypeDtos;
global using HotelAPI.Application.Features.Commands.CountryCommands.CreateCountry;
global using HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;
global using HotelAPI.Application.Features.Commands.CountryCommands.UpdateCountry;
global using HotelAPI.Application.Features.Queries.CountryQueries.GetAllCountry;
global using HotelAPI.Application.Features.Queries.CountryQueries.GetAllDetailsOfCountry;
global using HotelAPI.Application.Features.Queries.CountryQueries.GetCountryById;
global using HotelAPI.Application.Utilities.Results;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
global using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
global using HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;
global using HotelAPI.Application.Features.Queries.CityQueries.GetAllCities;
global using HotelAPI.Application.Features.Queries.CityQueries.GetAllDetailsOfCities;
global using HotelAPI.Application.Features.Queries.CityQueries.GetCityById;
global using HotelAPI.Application.Features.Commands.EquipmentCommands.CreateEquipment;
global using HotelAPI.Application.Features.Commands.EquipmentCommands.DeleteEquipment;
global using HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;
global using HotelAPI.Application.Features.Queries.EquipmentQueries.GetAllEquipments;
global using HotelAPI.Application.Features.Queries.EquipmentQueries.GetEquipmentById;
global using HotelAPI.Application.Features.Commands.RoomTypeCommands.CreateRoomType;
global using HotelAPI.Application.Features.Commands.RoomTypeCommands.DeleteRoomType;
global using HotelAPI.Application.Features.Commands.RoomTypeCommands.UpdateRoomType;
global using HotelAPI.Application.Features.Queries.RoomTypeQueries.GetAllDetailsOfRoomTypes;
global using HotelAPI.Application.Features.Queries.RoomTypeQueries.GetAllRoomTypes;
global using HotelAPI.Application.Features.Queries.RoomTypeQueries.GetRoomTypeById;
global using HotelAPI.Application.Features.Commands.HotelCommands.CreateHotel;
global using HotelAPI.Application.Features.Commands.HotelCommands.DeleteHotel;
global using HotelAPI.Application.Features.Commands.HotelCommands.UpdateHotel;
global using HotelAPI.Application.Features.Queries.HotelQueries.GetAllDetailsOfHotels;
global using HotelAPI.Application.Features.Queries.HotelQueries.GetAllHotels;
global using HotelAPI.Application.Features.Queries.HotelQueries.GetHotelById;