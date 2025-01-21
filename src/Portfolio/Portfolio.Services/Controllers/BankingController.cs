namespace Portfolio.Services.Controllers;

using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Models;

[ApiController]
[Route("[controller]")]
public class BankingController : Controller
{
    // Mock data for demonstration purposes
    private static readonly Dictionary<string, decimal> AccountBalances = new Dictionary<string, decimal>
    {
        { "123456", 1000.50m },
        { "654321", 2500.75m }
    };

    private static readonly Dictionary<string, List<Transaction>> AccountTransactions = new Dictionary<string, List<Transaction>>
    {
        { "123456", new List<Transaction>
            {
                new Transaction { Date = DateTime.Now.AddDays(-1), Amount = -50.00m, Description = "Grocery" },
                new Transaction { Date = DateTime.Now.AddDays(-2), Amount = -20.00m, Description = "Gas" },
                new Transaction { Date = DateTime.Now.AddDays(-3), Amount = -100.00m, Description = "Restaurant" },
                new Transaction { Date = DateTime.Now.AddDays(-4), Amount = 200.00m, Description = "Salary" },
                new Transaction { Date = DateTime.Now.AddDays(-5), Amount = -30.00m, Description = "Utilities" }
            }
        }
    };

    /// <summary>
    /// Gets the account balance for the specified account.
    /// </summary>
    /// <param name="accountId">The account identifier.</param>
    /// <returns>The account balance.</returns>
    [HttpGet("account/{accountId}/balance")]
    public IActionResult GetAccountBalance(string accountId)
    {
        if (AccountBalances.TryGetValue(accountId, out var balance))
        {
            return Ok(balance);
        }
        return NotFound("Account not found");
    }

    /// <summary>
    /// Gets the transactions for the specified account for the last 5 days.
    /// </summary>
    /// <param name="accountId">The account identifier.</param>
    /// <returns>The list of transactions for the last 5 days.</returns>
    [HttpGet("account/{accountId}/transactions")]
    public IActionResult GetAccountTransactions(string accountId)
    {
        if (AccountTransactions.TryGetValue(accountId, out var transactions))
        {
            var recentTransactions = transactions.FindAll(t => t.Date >= DateTime.Now.AddDays(-5));
            return Ok(recentTransactions);
        }
        return NotFound("Account not found");
    }
}
