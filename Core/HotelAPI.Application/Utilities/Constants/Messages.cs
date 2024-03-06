namespace HotelAPI.Application.Utilities.Constants;

static class Messages
{
    #region Success Messages

    public static string Created(string entity)
    {
        return $"The {entity} has been created";
    }
    public static string Updated(string entity)
    {
        return $"The {entity} has been updated.";
    }
    public static string Deleted(string entity)
    {
        return $"The {entity} has been deleted.";
    }
    public static string Recovered(string entity)
    {
        return $"The {entity} has been recovered.";
    }
    #endregion

    #region Error Messages
    public static string NotFound(string entity)
    {
        return $"{entity} is not found.";
    }
    public static string NotCreated(string entity)
    {
        return $"The {entity} could not be created";
    }
    public static string NotUpdated(string entity)
    {
        return $"The {entity} could not be updated.";
    }
    public static string NotDeleted(string entity)
    {
        return $"The {entity} could not be deleted.";
    }
    public static string NotRecovered(string entity)
    {
        return $"The {entity} could not be recovered.";
    }
    public static string EnterValid(string entity)
    {
        return $" Enter Valid {entity}.";
    }
    #endregion

    #region RoomState Messages

    public static string NotAvailable(string entity)
    {
        return $"{entity} is not available.";
    }

    #endregion

    #region Message Entity
    public static string Country = "Country";
    public static string City = "City";
    public static string Equipment = "Equipment";
    public static string RoomEquipment = "RoomEquipment";
    public static string Hotel = "Hotel";
    public static string Reservation = "Reservation";
    public static string Reservator = "Reservator";
    public static string Review = "Review";
    public static string Room = "Room";
    public static string RoomType = "RoomType";
    public static string Service = "Service";
    public static string ServiceType = "ServiceType";
    public static string Role = "Role";
    #endregion
}
