namespace Pizza.API.Controllers;

public class PizzaController : BaseController
{
    [HttpPost("upload-pizza-csv")]
    public async Task<IActionResult> UploadPizzaCsv([FromForm] IFormFile file)
    {
        var request = new UploadPizzaRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    [HttpPost("upload-pizza-type-csv")]
    public async Task<IActionResult> UploadPizzaTypeCsv([FromForm] IFormFile file)
    {
        var request = new UploadPizzaTypeRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    [HttpPost("upload-order-csv")]
    public async Task<IActionResult> UploadOrderCsv([FromForm] IFormFile file)
    {
        var request = new UploadOrderRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    [HttpPost("upload-order-detail-csv")]
    public async Task<IActionResult> UploadOrderDetailCsv([FromForm] IFormFile file)
    {
        var request = new UploadOrderDetailRequest(file);
        await Mediator.Send(request);
        return Ok();
    }
}

