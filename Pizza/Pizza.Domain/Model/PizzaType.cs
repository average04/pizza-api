namespace Pizza.Domain;

public class PizzaType : Entity<string>
{
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Ingredients { get; set; } = default!;
}

