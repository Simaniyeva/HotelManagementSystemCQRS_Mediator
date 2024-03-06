using Microsoft.Extensions.Options;

namespace HotelAPI.Persistence.DbContexts;

public class HotelIdentityDbContext : IdentityDbContext<AppUser>
{
    public HotelIdentityDbContext(DbContextOptions<HotelIdentityDbContext> options) : base(options) {}

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Reservator> Reservators { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.RegisterAllEntities<BaseEntity>(typeof(BaseEntity).Assembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    //Entity üzərində edilən dəyişikliklər və ya yeni əlavə olunan datanı saxlayan propertydir.
    //    var datas = ChangeTracker.Entries<BaseEntity>();
    //    foreach (var data in datas)
    //    {
    //        _ = data.State switch
    //        {
    //            EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
    //        };
    //    }

    //    return await  base.SaveChangesAsync(cancellationToken);
    //}

}
