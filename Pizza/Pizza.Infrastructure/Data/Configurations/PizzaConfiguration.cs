namespace Pizza.Infrastructure.Data.Configurations;

public class PizzaConfiguration : IEntityTypeConfiguration<Domain.Pizza>
{
    public void Configure(EntityTypeBuilder<Domain.Pizza> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("NVARCHAR(255)")
            .HasColumnOrder(0);

        builder.HasOne<PizzaType>()
            .WithMany()
            .HasForeignKey(o => o.PizzaTypeId)
            .IsRequired();
        builder.Property(c => c.PizzaTypeId)
           .HasColumnType("NVARCHAR(255)")
           .HasColumnOrder(1);

        builder.Property(c => c.Size)
          .HasColumnType("NVARCHAR(10)")
          .HasColumnOrder(2);

        builder.Property(c => c.Price)
          .HasColumnType("DECIMAL(5,2)")
          .HasColumnOrder(3);
    }
}
