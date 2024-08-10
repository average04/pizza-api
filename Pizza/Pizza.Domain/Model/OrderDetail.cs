namespace Pizza.Domain;

public class OrderDetail : Entity<long>
{
    public long OrderId { get; set; }
    public string PizzaId { get; set; } = default!;
    public int Quantity {  get; set; }
}
