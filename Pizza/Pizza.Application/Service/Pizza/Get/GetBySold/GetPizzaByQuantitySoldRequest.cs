namespace Pizza.Application.Service;

public record GetPizzaByQuantitySoldRequest(SortBySale Sort, DateOnly? DateFrom = null, DateOnly? DateTo = null)
    : IRequest<IEnumerable<GetPizzaResponse>>;

public class GetPizzaByQuantitySoldRequestValidator : AbstractValidator<GetPizzaByQuantitySoldRequest>
{
    public GetPizzaByQuantitySoldRequestValidator()
    {
        RuleFor(x => x.Sort)
            .IsInEnum();
    }
}