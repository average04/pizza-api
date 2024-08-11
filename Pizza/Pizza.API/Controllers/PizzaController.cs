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
    /// <param name="request">Get pizza by sale request</param>
    /// <returns></returns>
    [HttpGet("pizza/sale")]
    public async Task<IActionResult> GetPizzaSale([FromQuery] GetPizzaBySaleRequest request)
    {
        return Ok(await Mediator.Send(request));
    }

    /// <summary>
    /// Get pizza summary by quantity sold
    /// </summary>
    /// <param name="request">Get pizza by quantity sold request</param>
    /// <returns></returns>
    [HttpGet("pizza/quantity-sold")]
    public async Task<IActionResult> GetPizzaQuantitySold([FromQuery] GetPizzaByQuantitySoldRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
}

