using Pizza.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizza.API.Controllers;

public class OrderDetailCsv
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public string PizzaId { get; set; } = default!;
    public int Quantity { get; set; }

    public OrderDetail ToDomainModel()
    {
        return new OrderDetail()
        {
            Id = OrderDetailId,
            OrderId = OrderId,
            PizzaId = PizzaId,
            Quantity = Quantity,
        };
    }
}

public class OrderDetailCsvMap : ClassMap<OrderDetailCsv>
{
    public OrderDetailCsvMap()
    {
        Map(m => m.OrderDetailId).Name("order_details_id");
        Map(m => m.OrderId).Name("order_id");
        Map(m => m.PizzaId).Name("pizza_id");
        Map(m => m.Quantity).Name("quantity");
    }
}