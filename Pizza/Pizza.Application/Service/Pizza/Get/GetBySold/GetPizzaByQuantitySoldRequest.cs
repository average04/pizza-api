namespace Pizza.Application.Service;

public record GetPizzaByQuantitySoldRequest(
    SortBySale Sort,
    DateOnly? DateFrom = null,
    DateOnly? DateTo = null,
    int? PageNumber = null,
    int? PageSize = null)
    : PaginationRequest(PageNumber, PageSize), IRequest<PaginatedResult<GetPizzaResponse>>;

public class GetPizzaByQuantitySoldRequestValidator : AbstractValidator<GetPizzaByQuantitySoldRequest>
{
    public GetPizzaByQuantitySoldRequestValidator()
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