using Pizza.Application.Service.Pizza;

namespace Pizza.Application.Service;

public class GetPizzaByQuantitySoldHandler : IRequestHandler<GetPizzaByQuantitySoldRequest, PaginatedResult<GetPizzaResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetPizzaByQuantitySoldHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<GetPizzaResponse>> Handle(GetPizzaByQuantitySoldRequest request, CancellationToken cancellationToken)
    {
        var result = await new BaseQuery(_dbContext).GetPizzaSaleSummaryQuery(request.PageNumber, request.PageSize);

        if (request.Sort == SortBySale.LowToHigh)
        {
            result.Items.OrderBy(x => x.QuantitySold);
        }
        else
        {
            result.Items.OrderByDescending(x => x.QuantitySold);
        }

        return result;
    }
}