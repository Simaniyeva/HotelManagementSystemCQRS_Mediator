using Microsoft.AspNetCore.Identity;

namespace HotelAPI.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EntityStatus Status { get; set; } = EntityStatus.Active;
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
