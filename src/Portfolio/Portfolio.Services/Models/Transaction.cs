namespace Portfolio.Services.Models;

public class Transaction
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public required String Description { get; set; }
}
