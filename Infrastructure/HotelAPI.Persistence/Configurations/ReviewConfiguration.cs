namespace HotelAPI.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Content).IsRequired().HasMaxLength(255);
       
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        ////Relations
        //builder.HasOne(b => b.Reservator).WithMany(b => b.Reviews).HasForeignKey(b => b.ReservatorId);
        //builder.HasOne(b => b.Hotel).WithMany(b => b.Reviews).HasForeignKey(b => b.HotelId);
    }
}
