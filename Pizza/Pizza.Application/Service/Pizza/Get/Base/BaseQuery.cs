namespace Pizza.Application.Service.Pizza;

public class BaseQuery
{
    private readonly IApplicationDbContext _dbContext;
    public BaseQuery(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<GetPizzaResponse>> GetPizzaSaleSummaryQuery(int? pageNumber, int? pageSize)
    {
        return await _dbContext.OrderDetails
            .Join(_dbContext.Pizzas,
            od => od.PizzaId,
            p => p.Id,
            (od, p) => new { od, p })
            .Join(_dbContext.Orders,
            od_p => od_p.od.OrderId,
            o => o.Id,
            (od_p, o) => new { od_p.od, od_p.p, o })
            .GroupBy(x => new { x.od.PizzaId, x.p.Price })
            .Select(g => new GetPizzaResponse
            (
                g.Key.PizzaId,
                Math.Round(g.Sum(x => x.p.Price * x.od.Quantity), 2),
                g.Sum(x => x.od.Quantity)
            )).PaginateAsync(pageNumber, pageSize);
    }
}
