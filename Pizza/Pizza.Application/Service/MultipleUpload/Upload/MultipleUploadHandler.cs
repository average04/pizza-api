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
        var pizzaTypeHandler = new UploadPizzaTypeHandler(_dbContext);
        var pizzaHandler = new UploadPizzaHandler(_dbContext);
        var orderHandler = new UploadOrderHandler(_dbContext);
        var orderDetailHandler = new UploadOrderDetailHandler(_dbContext);

        // Hacky way to ensure the consecutive insert of data, important because of foreign key
        foreach (var file in request.Files)
        {
            await pizzaTypeHandler.Handle(new UploadPizzaTypeRequest(file), cancellationToken);
        }
        foreach (var file in request.Files)
        {
            await pizzaHandler.Handle(new UploadPizzaRequest(file), cancellationToken);
        }
        foreach (var file in request.Files)
        {
            await orderHandler.Handle(new UploadOrderRequest(file), cancellationToken);
        }
        foreach (var file in request.Files)
        {
            await orderDetailHandler.Handle(new UploadOrderDetailRequest(file), cancellationToken);
        }
        return Unit.Value;
    }
}
