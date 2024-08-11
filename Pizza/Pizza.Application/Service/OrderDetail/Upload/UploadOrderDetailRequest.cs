namespace Pizza.Application.Service;

public record UploadOrderDetailRequest(IFormFile File)
    : IRequest<Unit>;

public class UploadOrderDetailRequestValidator : AbstractValidator<UploadOrderDetailRequest>
{
    public UploadOrderDetailRequestValidator()
    {
        RuleFor(x => x.File)
            .NotNull();
    }
}