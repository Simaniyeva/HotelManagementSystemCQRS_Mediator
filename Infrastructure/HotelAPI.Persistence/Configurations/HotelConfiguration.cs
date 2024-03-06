namespace HotelAPI.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(255);
        builder.Property(b => b.Address).IsRequired().HasMaxLength(255);
        builder.Property(b => b.WebSite).HasMaxLength(250);
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Email).HasMaxLength(100);
        builder.Property(b => b.entityStatus).IsRequired();
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasOne(b => b.City).WithMany(b => b.Hotels).HasForeignKey(b => b.CityId);
        builder.HasMany(b => b.Rooms).WithOne(b => b.Hotel).HasForeignKey(b => b.HotelId);
        builder.HasMany(b => b.Reviews).WithOne(b => b.Hotel).HasForeignKey(b => b.HotelId);
    }
}
