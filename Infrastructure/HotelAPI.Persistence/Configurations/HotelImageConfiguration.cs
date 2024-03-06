namespace HotelAPI.Persistence.Configurations;

public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>

{
    public void Configure(EntityTypeBuilder<HotelImage> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasOne(b => b.Hotel).WithMany(b => b.HotelImages).HasForeignKey(b => b.HotelId);
    }

}
