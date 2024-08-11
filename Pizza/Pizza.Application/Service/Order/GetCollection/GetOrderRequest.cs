namespace Pizza.Application.Service;

public record GetOrderRequest(DateOnly? DateFrom = null, DateOnly? DateTo = null, int? PageNumber = null, int? PageSize = null)
    : PaginationRequest(PageNumber, PageSize), IRequest<PaginatedResult<GetOrderResponse>>;

public record GetOrderResponse(
    long Id,
    List<string> OrderedPizza,
    DateOnly Date,
    TimeOnly Time);

public class GetOrderRequestValidator : AbstractValidator<GetOrderRequest>
{
    public GetOrderRequestValidator()
    {
        RuleFor(x => x.DateTo)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .When(x => x.DateFrom.HasValue)
            .WithMessage("DateTo must have a value if DateFrom is provided.");

        RuleFor(x => x.PageSize)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .When(x => x.PageNumber.HasValue)
           .WithMessage("PageSize must have a value if Page number is provided.");
    }
}