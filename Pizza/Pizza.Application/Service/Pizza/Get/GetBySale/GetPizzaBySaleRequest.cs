namespace Pizza.Application.Service;

public record GetPizzaBySaleRequest(SortBySale Sort)
    : IRequest<IEnumerable<GetPizzaResponse>>;

public class GetPizzaBySaleRequestValidator : AbstractValidator<GetPizzaBySaleRequest>
{
    public GetPizzaBySaleRequestValidator()
    {
        RuleFor(x => x.Sort)
            .IsInEnum();
    }
}