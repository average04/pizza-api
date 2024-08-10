﻿using System.Reflection;

namespace Pizza.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Domain.Pizza> Pizzas => Set<Domain.Pizza>();
    public DbSet<PizzaType> PizzaTypes => Set<PizzaType>();

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
