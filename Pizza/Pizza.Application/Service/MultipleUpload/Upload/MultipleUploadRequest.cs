namespace Pizza.Application.Service;

public record MultipleUploadRequest(List<IFormFile> Files)
    : IRequest<Unit>;

public class MultipleUploadRequestValidator : AbstractValidator<MultipleUploadRequest>
{
    public MultipleUploadRequestValidator()
    {
        RuleFor(x => x.Files.Count)
            .GreaterThan(0);
    }
}