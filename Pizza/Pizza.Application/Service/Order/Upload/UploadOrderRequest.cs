namespace Pizza.Application.Service;

public record UploadOrderRequest(IFormFile File)
    : IRequest<Unit>;

public class UploadOrderRequestValidator : AbstractValidator<UploadOrderRequest>
{
    public UploadOrderRequestValidator()
    {
        RuleFor(x => x.File)
            .NotNull();
    }
}