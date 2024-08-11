using Pizza.Domain;

namespace Pizza.API.Controllers;

public class PizzaCsv
{
    public string PizzaId { get; set; } = default!;
    public string PizzaTypeId { get; set; } = default!;
    public string Size { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public Domain.Pizza ToDomainModel()
    {
        return new Domain.Pizza()
        {
            Id = PizzaId,
            PizzaTypeId = PizzaTypeId,
            Size = Size,
            Price = Price
        };
    }
}

public class PizzaCsvMap : ClassMap<PizzaCsv>
{
    public PizzaCsvMap()
    {
        Map(m => m.PizzaId).Name("pizza_id");
        Map(m => m.PizzaTypeId).Name("pizza_type_id");
        Map(m => m.Size).Name("size");
        Map(m => m.Price).Name("price");
    }
}