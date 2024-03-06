namespace HotelAPI.Persistence.Configurations;

public class ReservatorConfiguration : IEntityTypeConfiguration<Reservator>
{
    public void Configure(EntityTypeBuilder<Reservator> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.FirstName).IsRequired().HasMaxLength(255);
        builder.Property(b => b.LastName).IsRequired().HasMaxLength(255);
        builder.Property(b => b.Email).HasMaxLength(255);
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(255);
        
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasMany(b => b.Reservations).WithOne(b => b.Reservator).HasForeignKey(b => b.ReservatorId);
        builder.HasMany(b => b.Reviews).WithOne(b => b.Reservator).HasForeignKey(b => b.ReservatorId);

    }
}

