namespace Pizza.Application.Service;

public record GetPizzaByQuantitySoldRequest(SortBySale Sort)
    : IRequest<IEnumerable<GetPizzaResponse>>;

public class GetPizzaByQuantitySoldRequestValidator : AbstractValidator<GetPizzaByQuantitySoldRequest>
{
    public GetPizzaByQuantitySoldRequestValidator()
    {
        RuleFor(x => x.Sort)
            .IsInEnum();
    }
}