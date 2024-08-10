using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Service.Order;
using System.Globalization;

namespace Pizza.API.Controllers;

public class OrderController : BaseController
{
   
    [HttpPost("upload-order-csv")]
    public async Task<IActionResult> UploadOrderCsv([FromForm] IFormFile file)
    {
        var request = new UploadOrderRequest(file);
        await Mediator.Send(request);
        return Ok();
    }
}

