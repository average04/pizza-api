using Pizza.Domain;

namespace Pizza.API.Controllers;

public class PizzaTypeCsv
{
    public string PizzaTypeId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Ingredients { get; set; } = default!;

    public PizzaType ToDomainModel()
    {
        return new PizzaType()
        {
            Id = PizzaTypeId,
            Name = Name,
            Category = Category,
            Ingredients = Ingredients,
        };
    }
}

public class PizzaTypeCsvMap : ClassMap<PizzaTypeCsv>
{
    public PizzaTypeCsvMap()
    {
        Map(m => m.PizzaTypeId).Name("pizza_type_id");
        Map(m => m.Name).Name("name");
        Map(m => m.Category).Name("category");
        Map(m => m.Ingredients).Name("ingredients");
    }
}