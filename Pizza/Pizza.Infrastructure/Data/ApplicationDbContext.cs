using EFCore.BulkExtensions;

namespace Pizza.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Domain.Pizza> Pizzas => Set<Domain.Pizza>();
    public DbSet<PizzaType> PizzaTypes => Set<PizzaType>();

    public async Task BulkInsertEntitiesAsync<T>(IEnumerable<T> entities) where T : class
    {
        // Ensure the entities are in a list
        await this.BulkInsertAsync(entities.ToList());
    }

    public Task<int> SaveChangesAsync(CancellationToken? cancellationToken)
    {
        return SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
