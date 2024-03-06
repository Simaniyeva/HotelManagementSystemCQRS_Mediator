namespace HotelAPI.API;

public static class Includes
{
    public static readonly string[] CountryIncludes =
    {
     "Cities",
    };

    public static readonly string[] CityIncludes = {
    "Country",
    "Hotels",
    };

    public static readonly string[] CityWithCountryIncludes = {
    "Country",
    };
    public static readonly string[] HotelIncludes = {
    "City",
    "City.Country",
    "Reviews",
    "Rooms",
    "HotelImages"
    };
    public static readonly string[] ReservationIncludes = {
    "Room",
    "Reservator",
    };

    public static readonly string[] ReservatorIncludes = {
    "Reviews",
    "Reservations",
    };

    public static readonly string[] ReviewIncludes = {
    "Reservator",
    "Hotel",
    };

    public static readonly string[] RoomIncludes = {
    "RoomType",
    "Hotel",
    "Reservations",
    "RoomEquipments",
    "RoomEquipments.Equipment"
    };

    public static readonly string[] RoomTypeIncludes = {
    "Rooms",
    };

    public static readonly string[] ServiceIncludes = {
    "ServiceType",
    };

    public static readonly string[] ServiceTypeIncludes = {
    "Services",

    };
    public static readonly string[] RoleIncludes = {
    "Users",

    };

}
