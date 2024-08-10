namespace Pizza.Domain;

public class Pizza : Entity<string>
{
    public string PizzaTypeId { get; set; } = default!;
    public string Size { get; set; } = default!;
    public decimal Price { get; set; }
}

