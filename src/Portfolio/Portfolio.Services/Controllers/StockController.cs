namespace Portfolio.Services.Controllers;

using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Models;

[ApiController]
[Route("api/[controller]")]
public class StockController : Controller
{
    private static readonly List<Stock> StockPortfolio = new List<Stock>
    {
        new Stock { Name = "AAPL", Quantity = 30, Price = 153.00m },
        new Stock { Name = "GOOGL", Quantity = 57, Price = 2807.00m },
        new Stock { Name = "MSFT", Quantity = 23, Price = 305.00m },
        new Stock { Name = "AMZN", Quantity = 15, Price = 3400.00m },
        new Stock { Name = "FB", Quantity = 20, Price = 355.00m },
        new Stock { Name = "TSLA", Quantity = 10, Price = 700.00m },
        new Stock { Name = "NFLX", Quantity = 12, Price = 590.00m },
        new Stock { Name = "NVDA", Quantity = 25, Price = 220.00m },
        new Stock { Name = "ADBE", Quantity = 18, Price = 650.00m },
        new Stock { Name = "PYPL", Quantity = 22, Price = 270.00m },
        new Stock { Name = "INTC", Quantity = 40, Price = 55.00m },
        new Stock { Name = "CSCO", Quantity = 35, Price = 55.00m },
        new Stock { Name = "ORCL", Quantity = 28, Price = 90.00m },
        new Stock { Name = "IBM", Quantity = 30, Price = 140.00m },
        new Stock { Name = "CRM", Quantity = 16, Price = 250.00m },
        new Stock { Name = "UBER", Quantity = 50, Price = 45.00m },
        new Stock { Name = "LYFT", Quantity = 45, Price = 50.00m },
        new Stock { Name = "TWTR", Quantity = 33, Price = 65.00m },
        new Stock { Name = "SNAP", Quantity = 38, Price = 70.00m },
        new Stock { Name = "SHOP", Quantity = 12, Price = 1500.00m },
        new Stock { Name = "SQ", Quantity = 20, Price = 240.00m },
        new Stock { Name = "SPOT", Quantity = 14, Price = 300.00m },
        new Stock { Name = "ZM", Quantity = 18, Price = 350.00m },
        new Stock { Name = "DOCU", Quantity = 22, Price = 280.00m },
        new Stock { Name = "ROKU", Quantity = 25, Price = 400.00m }
    };

    private static readonly List<MarketTrend> MarketTrends = new List<MarketTrend>
    {
        new MarketTrend { Name = "Tech", Change = 2.5 },
        new MarketTrend { Name = "Healthcare", Change = -1.2 },
        new MarketTrend { Name = "Finance", Change = 0.8 }
    };

    [HttpGet("portfolio")]
    public IActionResult GetStockPortfolio()
    {
        return Ok(StockPortfolio);
    }

    [HttpGet("trends")]
    public IActionResult GetMarketTrends()
    {
        return Ok(MarketTrends);
    }
}
