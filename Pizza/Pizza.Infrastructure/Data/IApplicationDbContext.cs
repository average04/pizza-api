using Microsoft.EntityFrameworkCore.Internal;

namespace Pizza.Infrastructure.Data;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; }
    DbSet<OrderDetail> OrderDetails { get; }
    DbSet<Domain.Pizza> Pizzas { get; }
    DbSet<PizzaType> PizzaTypes { get; }

    Task<int> SaveChangesAsync(CancellationToken? cancellationToken);
    Task BulkInsertOrUpdateEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
}
