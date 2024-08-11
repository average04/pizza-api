namespace Pizza.Infrastructure.Data.Configurations;

public class PizzaTypeConfiguration : IEntityTypeConfiguration<PizzaType>
{
    public void Configure(EntityTypeBuilder<PizzaType> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("NVARCHAR(255)")
            .HasColumnOrder(0);

        builder.Property(c => c.Name)
            .HasColumnType("NVARCHAR(255)")
            .HasColumnOrder(1);

        builder.Property(c => c.Ingredients)
           .HasColumnType("TEXT")
           .HasColumnOrder(2);
    }
}
