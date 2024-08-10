namespace Pizza.Application.Service;

public record GetPizzaResponse(
    string PizzaId,
    decimal TotalSale,
    int QuantitySold);