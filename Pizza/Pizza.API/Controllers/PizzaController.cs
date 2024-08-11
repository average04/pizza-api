using Pizza.Application.Enums;

namespace Pizza.API.Controllers;

public class PizzaController : BaseController
{
    /// <summary>
    /// Can upload pizza type, pizza, order detail, and order data at the same time
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    [HttpPost("pizza/upload-multiple-csv")]
    public async Task<IActionResult> UploadPizzaCsv([FromForm] List<IFormFile> files)
    {
        var request = new MultipleUploadRequest(files);
        await Mediator.Send(request);
        return Ok();
    }

    /// <summary>
    /// Upload pizza data through csv
    /// </summary>
    /// <param name="file">Csv file</param>
    /// <returns></returns>
    [HttpPost("pizza/upload-csv")]
    public async Task<IActionResult> UploadPizzaCsv([FromForm] IFormFile file)
    {
        var request = new UploadPizzaRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    /// <summary>
    /// Upload pizza types data through csv
    /// </summary>
    /// <param name="file">Csv file</param>
    /// <returns></returns>
    [HttpPost("pizza/upload-pizza-type-csv")]
    public async Task<IActionResult> UploadPizzaTypeCsv([FromForm] IFormFile file)
    {
        var request = new UploadPizzaTypeRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    /// <summary>
    /// Get pizza summary by sale
    /// </summary>
    /// <param name="sort_by">Sort by</param>
    /// <param name="date_from">Date from</param>
    /// <param name="date_to">Date to</param>
    /// <returns></returns>
    [HttpGet("pizza/sale")]
    public async Task<IActionResult> GetPizzaSale([FromQuery] SortBySale sort_by, DateOnly? date_from, DateOnly? date_to)
    {
        var request = new GetPizzaBySaleRequest(sort_by, date_from, date_to);

        return Ok(await Mediator.Send(request));
    }

    /// <summary>
    /// Get pizza summary by quantity sold
    /// </summary>
    /// <param name="sort_by">Sort by</param>
    /// <param name="date_from">Date from</param>
    /// <param name="date_to">Date to</param>
    /// <returns></returns>
    [HttpGet("pizza/quantity-sold")]
    public async Task<IActionResult> GetPizzaQuantitySold([FromQuery] SortBySale sort_by, DateOnly? date_from, DateOnly? date_to)
    {
        var request = new GetPizzaByQuantitySoldRequest(sort_by, date_from, date_to);

        return Ok(await Mediator.Send(request));
    }
}

