
namespace HotelAPI.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.CheckInDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");
      
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        //builder.HasOne(b => b.Room).WithMany(b => b.Reservations).HasForeignKey(b => b.RoomId);
        //builder.HasOne(b => b.Reservator).WithMany(b => b.Reservations).HasForeignKey(b => b.ReservatorId);
    }
}

