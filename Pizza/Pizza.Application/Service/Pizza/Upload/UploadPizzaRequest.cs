namespace Pizza.Application.Service;

public record UploadPizzaRequest(IFormFile File)
    : IRequest<Unit>;

public class UploadPizzaRequestValidator : AbstractValidator<UploadPizzaRequest>
{
    public UploadPizzaRequestValidator()
    {
        RuleFor(x => x.File)
            .NotNull();
    }
}