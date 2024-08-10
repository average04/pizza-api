namespace Pizza.Application.Service;

public record UploadPizzaTypeRequest(IFormFile File)
    : IRequest<Unit>;

public class UploadPizzaTypeRequestValidator : AbstractValidator<UploadPizzaTypeRequest>
{
    public UploadPizzaTypeRequestValidator()
    {
        RuleFor(x => x.File)
            .NotNull();
    }
}