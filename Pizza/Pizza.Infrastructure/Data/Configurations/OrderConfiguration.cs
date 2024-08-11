namespace Pizza.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnOrder(0);

        builder.Property(c => c.Date)
            .HasColumnOrder(1);
        
        builder.Property(c => c.Time)
           .HasColumnOrder(2);
    }
}
