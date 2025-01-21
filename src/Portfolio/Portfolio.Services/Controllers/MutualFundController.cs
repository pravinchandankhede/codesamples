namespace Portfolio.Services.Controllers;

using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class MutualFundController : Controller
{
    private static readonly List<Fund> Funds = new List<Fund>
    {
        new Fund { Name = "Equity Fund", Value = 20000 },
        new Fund { Name = "Debt Fund", Value = 5050 },
        new Fund { Name = "Hybrid Fund", Value = 7501 }
    };

    [HttpGet("overview")]
    public IActionResult GetFundOverview()
    {
        return Ok(Funds);
    }

    [HttpGet("calculate")]
    public IActionResult CalculateInvestment([FromQuery] decimal principal, [FromQuery] double rate, [FromQuery] int time)
    {
        var amount = principal * (decimal)Math.Pow(1 + rate / 100, time);
        return Ok(amount);
    }
}
