using Azure;

namespace Pizza.Application.Service;

public record GetPizzaBySaleRequest(
    SortBySale Sort,
    DateOnly? DateFrom = null,
    DateOnly? DateTo = null,
    int? PageNumber = null,
    int? PageSize = null)
    : PaginationRequest(PageNumber, PageSize), IRequest<PaginatedResult<GetPizzaResponse>>;

public class GetPizzaBySaleRequestValidator : AbstractValidator<GetPizzaBySaleRequest>
{
    public GetPizzaBySaleRequestValidator()
    {
        RuleFor(x => x.Sort)
            .IsInEnum();

        RuleFor(x => x.PageSize)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .When(x => x.PageNumber.HasValue)
           .WithMessage("PageSize must have a value if Page number is provided.");
    }
}