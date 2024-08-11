using Pizza.Domain;

namespace Pizza.API.Controllers;

public class OrderCsv
{
    public int OrderId { get; set; }
    public DateOnly Date { get; set; } = default!;
    public TimeOnly Time { get; set; }

    public Order ToDomainModel()
    {
        return new Order()
        {
            Id = OrderId,
            Date = Date,
            Time = Time,
        };
    }
}

public class OrderCsvMap : ClassMap<OrderCsv>
{
    public OrderCsvMap()
    {
        Map(m => m.OrderId).Name("order_id");
        Map(m => m.Date).Name("date");
        Map(m => m.Time).Name("time");
    }
}