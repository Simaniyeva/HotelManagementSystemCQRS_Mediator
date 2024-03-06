namespace HotelAPI.Persistence.Configurations;

public class RoomImageConfiguration : IEntityTypeConfiguration<RoomImage>

{
    public void Configure(EntityTypeBuilder<RoomImage> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasOne(b => b.Room).WithMany(b => b.RoomImages).HasForeignKey(b => b.RoomId);
    }
}