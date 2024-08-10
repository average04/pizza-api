namespace Pizza.Infrastructure.Data.Configurations;

public class OrderDeatailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnOrder(0);

        builder.HasOne<Order>()
           .WithMany()
           .HasForeignKey(o => o.OrderId)
           .IsRequired();
        builder.Property(c => c.OrderId)
          .HasColumnOrder(1);

        builder.HasOne<Domain.Pizza>()
            .WithMany()
            .HasForeignKey(o => o.PizzaId)
            .IsRequired();
        builder.Property(c => c.PizzaId)
            .HasColumnType("NVARCHAR(255)")
            .HasColumnOrder(2);

        builder.Property(c => c.Quantity)
            .HasColumnOrder(3);
    }
}
