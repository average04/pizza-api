namespace Pizza.Domain.Abstraction.Entity;

public interface IEntity<T> 
{
    public T Id { get; set; }
}
