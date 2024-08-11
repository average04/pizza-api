using Pizza.Application.Helper;

namespace Pizza.Application.Service;

public class GetOrderHandler : IRequestHandler<GetOrderRequest, PaginatedResult<GetOrderResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetOrderHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<GetOrderResponse>> Handle(GetOrderRequest request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Orders.AsQueryable();

        if (request.DateFrom.HasValue && request.DateTo.HasValue)
        {
            query = query.Where(o => o.Date >= request.DateFrom && o.Date <= request.DateTo);
        }

        var result = query
            .OrderBy(o => o.Date)
            .Select(o => new GetOrderResponse(
                o.Id,
                _dbContext.OrderDetails
                    .Where(od => od.OrderId == o.Id)
                    .Select(od => od.PizzaId)
                    .ToList(),
                o.Date,
                o.Time));

        return await result.PaginateAsync(request.PageNumber, request.PageSize);
    }
}