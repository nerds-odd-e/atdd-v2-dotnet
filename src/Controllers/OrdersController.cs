using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using atdd_v2_dotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace atdd_v2_dotnet.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext appDbContext;
    private readonly LogisticService logisticService;

    public OrdersController(AppDbContext appDbContext, LogisticService logisticService)
    {
        this.appDbContext = appDbContext;
        this.logisticService = logisticService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(appDbContext.Orders.ToList().Select(order => new
        {
            order.Code,
            order.ProductName,
            order.Total,
            order.Status
        }));
    }

    [HttpGet("{code}")]
    public IActionResult Get(string code)
    {
        var order = appDbContext.Orders.ToList().First(order => order.Code == code);
        if (order.DeliverNo != null)
            return Ok(new
            {
                order.Code,
                order.ProductName,
                order.Total,
                order.RecipientName,
                order.RecipientMobile,
                order.RecipientAddress,
                order.DeliverNo,
                order.DeliveredAt,
                order.Status,
                logistics = logisticService.queryOrderLogistics(order.DeliverNo)
            });

        return Ok(new
        {
            order.Code,
            order.ProductName,
            order.Total,
            order.RecipientName,
            order.RecipientMobile,
            order.RecipientAddress,
            order.Status
        });
    }

    [HttpPost("{code}/deliver")]
    public IActionResult Deliver(string code, [FromBody] DeliverInfo deliverInfo)
    {
        var order = appDbContext.Orders.ToList().First(order => order.Code == code);
        order.DeliverNo = deliverInfo.deliverNo;
        order.DeliveredAt = DateTime.Now;
        order.Status = "delivering";
        appDbContext.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult create([FromBody] Order order)
    {
        appDbContext.Orders.Add(order);
        appDbContext.SaveChanges();
        return Ok();
    }

    public class DeliverInfo
    {
        public string deliverNo { get; set; }
    }
}