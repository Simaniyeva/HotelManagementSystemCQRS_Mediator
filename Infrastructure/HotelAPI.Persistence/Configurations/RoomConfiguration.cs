namespace HotelAPI.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Number).IsRequired().HasMaxLength(25);
        builder.Property(b => b.Floor).IsRequired().HasMaxLength(25);
        builder.Property(b => b.Phone).IsRequired().HasMaxLength(400);
        builder.Property(b => b.Price).IsRequired().HasMaxLength(100);        
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        //builder.HasOne(b => b.RoomType).WithMany(b => b.Rooms).HasForeignKey(b => b.RoomTypeId);
        //builder.HasOne(b => b.Hotel).WithMany(b => b.Rooms).HasForeignKey(b => b.HotelId);
        builder.HasMany(b => b.Reservations).WithOne(b => b.Room).HasForeignKey(b => b.RoomId);
    }
}