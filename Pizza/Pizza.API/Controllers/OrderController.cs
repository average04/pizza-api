namespace Pizza.API.Controllers;

public class OrderController : BaseController
{
    /// <summary>
    /// Upload order data through csv
    /// </summary>
    /// <param name="file">Csv file</param>
    /// <returns></returns>
    [HttpPost("order/upload-csv")]
    public async Task<IActionResult> UploadOrderCsv([FromForm] IFormFile file)
    {
        var request = new UploadOrderRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    /// <summary>
    /// Upload order details data through csv
    /// </summary>
    /// <param name="file">Csv file</param>
    /// <returns></returns>
    [HttpPost("order/upload-order-detail-csv")]
    public async Task<IActionResult> UploadOrderDetailCsv([FromForm] IFormFile file)
    {
        var request = new UploadOrderDetailRequest(file);
        await Mediator.Send(request);
        return Ok();
    }

    /// <summary>
    /// Get order collection
    /// </summary>
    /// <param name="request">Get order request</param>
    /// <returns></returns>
    [HttpGet("order")]
    public async Task<IActionResult> UploadOrderDetailCsv(GetOrderRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
}

