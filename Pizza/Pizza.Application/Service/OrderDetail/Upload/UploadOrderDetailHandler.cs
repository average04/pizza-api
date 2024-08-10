namespace Pizza.Application.Service;

public class UploadOrderDetailHandler : IRequestHandler<UploadOrderDetailRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public UploadOrderDetailHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UploadOrderDetailRequest request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            throw new BadRequestException("No file was uploaded.");
        }

        List<OrderDetail> orderDetails;
        using (var stream = request.File.OpenReadStream())
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            try
            {
                csv.Context.RegisterClassMap<OrderDetailCsvMap>();
                orderDetails = csv.GetRecords<OrderDetailCsv>().Select(o => o.ToDomainModel()).ToList();
            }
            catch (CsvHelperException)
            {
                // Ignore if cant read
                return Unit.Value;
            }
  
        }

        await _dbContext.BulkInsertOrUpdateEntitiesAsync(orderDetails);

        return Unit.Value;
    }
}