using Pizza.Application.Service.Pizza;

namespace Pizza.Application.Service;

public class GetPizzaBySaleHandler : IRequestHandler<GetPizzaBySaleRequest, PaginatedResult<GetPizzaResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetPizzaBySaleHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<GetPizzaResponse>> Handle(GetPizzaBySaleRequest request, CancellationToken cancellationToken)
    {
        var result = await new BaseQuery(_dbContext).GetPizzaSaleSummaryQuery(request.PageNumber, request.PageSize);

        if (request.Sort == SortBySale.LowToHigh)
        {
            result.Items.OrderBy(x => x.TotalSale);
        }
        else
        {
            result.Items.OrderByDescending(x => x.TotalSale);
        }

        return result;
    }
}