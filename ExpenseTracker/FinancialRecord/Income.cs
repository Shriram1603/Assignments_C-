namespace ExpenseTracker.FinancialRecord;

public class Income : IFinancialRecord
{
    public string Id { get; set; }
    public double Amount { get; set; }
    public DateOnly TransactionDate { get; set; }
    public DateTime TransactionTimeStamp { get; set; }

    public string Source { get; set; }

    public Income(double amount, DateOnly transactionDate, string source)
    {
        Id = $"{source}-{GenerateId()}";
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionTimeStamp = DateTime.Now;
        Source = source;
    }

    public string GetId() => Id;

    public double GetAmount() => Amount;

    public DateOnly GetTransactionDate() => TransactionDate;

    public void SetAmount(double amount)
    {
        Amount = amount;
    }
    public void setTransactionDate(DateOnly date)
    {
        TransactionDate = date;
    }
    
    public string GenerateId() => Guid.NewGuid().ToString().Substring(0, 4);
    public string GetType() => Source; 

    public void SetType(string source)
    {
        Source = source;
    }
}