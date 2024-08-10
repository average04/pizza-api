using EFCore.BulkExtensions;

namespace Pizza.Application.Service;

public class UploadOrderHandler : IRequestHandler<UploadOrderRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public UploadOrderHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UploadOrderRequest request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            throw new BadRequestException("No file was uploaded.");
        }

        List<Domain.Order> orders;
        using (var stream = request.File.OpenReadStream())
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            try
            {
                csv.Context.RegisterClassMap<OrderCsvMap>();
                orders = csv.GetRecords<OrderCsv>().Select(o => o.ToDomainModel()).ToList();
            }
            catch (CsvHelperException)
            {
                // Ignore if cant read
                return Unit.Value;
            }
        }

        await _dbContext.BulkInsertOrUpdateEntitiesAsync(orders);
        //_dbContext.Orders.UpdateRange(orders);
        //await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}