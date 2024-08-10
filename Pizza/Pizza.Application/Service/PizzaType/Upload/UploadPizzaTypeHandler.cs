namespace Pizza.Application.Service;

public class UploadPizzaTypeHandler : IRequestHandler<UploadPizzaTypeRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public UploadPizzaTypeHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UploadPizzaTypeRequest request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            throw new BadRequestException("No file was uploaded.");
        }

        List<PizzaType> pizza;
        using (var stream = request.File.OpenReadStream())
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            try
            {
                csv.Context.RegisterClassMap<PizzaTypeCsvMap>();
                pizza = csv.GetRecords<PizzaTypeCsv>().Select(o => o.ToDomainModel()).ToList();
            }
            catch (CsvHelperException)
            {
                // Ignore if cant read
                return Unit.Value;
            }
        }

        await _dbContext.BulkInsertOrUpdateEntitiesAsync(pizza);

        return Unit.Value;
    }
}