namespace Pizza.Application.Service;

public class GetPizzaBySaleHandler : IRequestHandler<GetPizzaBySaleRequest, IEnumerable<GetPizzaResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetPizzaBySaleHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetPizzaResponse>> Handle(GetPizzaBySaleRequest request, CancellationToken cancellationToken)
    {
        var query = await (from od in _dbContext.OrderDetails
                           join p in _dbContext.Pizzas on od.PizzaId equals p.Id
                           group new { p.Price, od.Quantity } by new { od.PizzaId, p.Price } into g
                           select new
                           {
                               PizzaId = g.Key.PizzaId,
                               TotalSale = Math.Round(g.Sum(x => x.Price * x.Quantity), 2),
                               QuantitySold = g.Sum(x => x.Quantity)
                           }).ToListAsync();

        var result = query.AsEnumerable()
            .Select(x => new GetPizzaResponse(x.PizzaId, x.TotalSale, x.QuantitySold))
            .OrderByDescending(x => x.TotalSale);

        if (request.Sort == SortBySale.LowToHigh)
        {
            result = result.OrderBy(x => x.TotalSale);
        }

        return result.ToList();
    }
}