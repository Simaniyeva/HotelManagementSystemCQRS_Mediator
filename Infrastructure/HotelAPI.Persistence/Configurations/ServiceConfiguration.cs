namespace HotelAPI.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Description).IsRequired().HasMaxLength(400);
        builder.Property(b => b.Price).IsRequired().HasMaxLength(50);
        builder.Property(b => b.AvailabilitySchedule).HasMaxLength(255);
       
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        //builder.HasOne(b => b.ServiceType).WithMany(b => b.Services).HasForeignKey(b => b.ServiceTypeId);


    }
}

