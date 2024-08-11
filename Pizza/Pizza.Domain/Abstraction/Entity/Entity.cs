namespace Pizza.Domain.Abstraction.Entity;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
}
