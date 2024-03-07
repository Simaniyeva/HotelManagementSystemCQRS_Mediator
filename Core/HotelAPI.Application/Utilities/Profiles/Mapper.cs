using HotelAPI.Application.Features.Commands.CityCommands.CreateCity;
using HotelAPI.Application.Features.Commands.CityCommands.DeleteCity;
using HotelAPI.Application.Features.Commands.CityCommands.UpdateCity;
using HotelAPI.Application.Features.Commands.CountryCommands.CreateCountry;
using HotelAPI.Application.Features.Commands.CountryCommands.DeleteCountry;
using HotelAPI.Application.Features.Commands.CountryCommands.UpdateCountry;
using HotelAPI.Application.Features.Commands.EquipmentCommands.CreateEquipment;
using HotelAPI.Application.Features.Commands.EquipmentCommands.DeleteEquipment;
using HotelAPI.Application.Features.Commands.EquipmentCommands.UpdateEquipment;
using HotelAPI.Application.Features.Commands.RoomTypeCommands.CreateRoomType;
using HotelAPI.Application.Features.Commands.RoomTypeCommands.DeleteRoomType;
using HotelAPI.Application.Features.Commands.RoomTypeCommands.UpdateRoomType;

namespace HotelAPI.Application.Utilities.Profiles;

public class Mapper : Profile
{
    public Mapper()
    {
        //Country
        CreateMap<Country, CountryGetDto>();
        CreateMap<CountryPostDto, Country>();
        CreateMap<CountryUpdateDto, Country>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CountryGetDto, CountryUpdateDto>();

        //City
        CreateMap<City, CreateCityCommandRequest>().ReverseMap();
        CreateMap<City, UpdateCityCommandRequest>().ReverseMap();
        CreateMap<City, DeleteCityCommandRequest>().ReverseMap();


        //Country
        CreateMap<Country, CreateCountryCommandRequest>().ReverseMap();
        CreateMap<Country, UpdateCountryCommandRequest>().ReverseMap();
        CreateMap<Country, DeleteCountryCommandRequest>().ReverseMap();


        //Equipment
        CreateMap<Equipment, CreateEquipmentCommandRequest>().ReverseMap();
        CreateMap<Equipment, UpdateEquipmentCommandRequest>().ReverseMap();
        CreateMap<Equipment, DeleteEquipmentCommandRequest>().ReverseMap();

        //RoomType
        CreateMap<RoomType, CreateRoomTypeCommandRequest>().ReverseMap();
        CreateMap<RoomType, UpdateRoomTypeCommandRequest>().ReverseMap();
        CreateMap<RoomType, DeleteRoomTypeCommandRequest>().ReverseMap();



        CreateMap<City, CityGetDto>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country)); ;
        CreateMap<CityPostDto, City>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));
        CreateMap<Country, CountryGetDto>();
        CreateMap<CityUpdateDto, City>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CityGetDto, CityUpdateDto>();

        //Equipment
        CreateMap<Equipment, EquipmentGetDto>();
        CreateMap<EquipmentPostDto, Equipment>();
        CreateMap<EquipmentUpdateDto, Equipment>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<EquipmentGetDto, EquipmentUpdateDto>();

        //RoomEquipment
        CreateMap<RoomEquipment, RoomEquipmentGetDto>();
        CreateMap<RoomEquipmentPostDto, RoomEquipment>();
        CreateMap<RoomEquipmentUpdateDto, RoomEquipment>();
        CreateMap<RoomEquipmentGetDto, RoomEquipmentUpdateDto>();

        //Hotel
        CreateMap<Hotel, HotelGetDto>();
        CreateMap<HotelPostDto, Hotel>();
        CreateMap<HotelUpdateDto, Hotel>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<HotelGetDto, HotelUpdateDto>();

        //Reservation
        CreateMap<Reservation, ReservationGetDto>();
        CreateMap<ReservationPostDto, Reservation>();
        CreateMap<ReservationUpdateDto, Reservation>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReservationGetDto, ReservationUpdateDto>();

        //Reservator
        CreateMap<Reservator, ReservatorGetDto>();
        CreateMap<ReservatorPostDto, Reservator>();
        CreateMap<ReservatorUpdateDto, Reservator>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReservatorGetDto, ReservatorUpdateDto>();

        //Review
        CreateMap<Review, ReviewGetDto>();
        CreateMap<ReviewPostDto, Review>();
        CreateMap<ReviewUpdateDto, Review>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReviewGetDto, ReviewUpdateDto>();


        //Room
        CreateMap<Room, RoomGetDto>();
        CreateMap<RoomPostDto, Room>();
        CreateMap<RoomUpdateDto, Room>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<RoomGetDto, RoomUpdateDto>();

        //RoomType
        CreateMap<RoomType, RoomTypeGetDto>();
        CreateMap<RoomTypePostDto, RoomType>();
        CreateMap<RoomTypeUpdateDto, RoomType>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<RoomTypeGetDto, RoomTypeUpdateDto>();

        //Service
        CreateMap<Service, ServiceGetDto>();
        CreateMap<ServicePostDto, Service>();
        CreateMap<ServiceUpdateDto, Service>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ServiceGetDto, ServiceUpdateDto>();


        //ServiceType
        CreateMap<ServiceType, ServiceTypeGetDto>();
        CreateMap<ServiceTypePostDto, ServiceType>();
        CreateMap<ServiceTypeUpdateDto, ServiceType>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ServiceTypeGetDto, ServiceTypeUpdateDto>();

        //Auth
        CreateMap<RegisterDto, AppUser>();
        CreateMap<LoginDto, AppUser>();
        CreateMap<AppUser, UserGetDto>().ReverseMap();
        CreateMap<UserGetDto, AppUser >().ReverseMap();

        //Role
        CreateMap<IdentityRole, RoleGetDto>();
        CreateMap<RolePostDto, IdentityRole>();
        CreateMap<RoleUpdateDto, IdentityRole>();
        CreateMap<RoleGetDto, RoleUpdateDto>();




    }

}


