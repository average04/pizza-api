using Azure.Core;
using EFCore.BulkExtensions;

namespace Pizza.Application.Service;

public class MultipleUploadHandler : IRequestHandler<MultipleUploadRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public MultipleUploadHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(MultipleUploadRequest request, CancellationToken cancellationToken)
    {
        if (request.Files == null || request.Files.Count == 0)
        {
            throw new BadRequestException("No file was uploaded.");
        }

        await ProcessFilesAsync(request.Files, cancellationToken, file =>
            new UploadPizzaTypeHandler(_dbContext).Handle(new UploadPizzaTypeRequest(file), cancellationToken));

        await ProcessFilesAsync(request.Files, cancellationToken, file =>
            new UploadPizzaHandler(_dbContext).Handle(new UploadPizzaRequest(file), cancellationToken));

        await ProcessFilesAsync(request.Files, cancellationToken, file =>
            new UploadOrderHandler(_dbContext).Handle(new UploadOrderRequest(file), cancellationToken));

        await ProcessFilesAsync(request.Files, cancellationToken, file =>
            new UploadOrderDetailHandler(_dbContext).Handle(new UploadOrderDetailRequest(file), cancellationToken));

        return Unit.Value;
    }

    private async Task ProcessFilesAsync(IEnumerable<IFormFile> files, CancellationToken cancellationToken, Func<IFormFile, Task> handler)
    {
        try
        {
            foreach (var file in files)
            {
                await handler(file);
            }
        }
        catch 
        {
            // Ignore exception
        }
       
    }
}
