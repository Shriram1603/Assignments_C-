namespace ExpenseTracker.FinancialRecord;

public class Income : IFinancialRecord
{
    public string Id { get; set; }
    public double Amount { get; set; }
    public DateOnly TransactionDate { get; set; }
    public DateTime TransactionTimeStamp { get; set; }

    public string Source { get; set; }

    public Income(double amount, DateOnly transactionDate, DateTime transactionTimeStamp, string source)
    {
        Id = $"{source}-{GenerateId()}";
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionTimeStamp = transactionTimeStamp;
        Source = source;
    }
    public string GenerateId()
    {
        return Guid.NewGuid().ToString().Substring(0, 4);
    }
    public string GetType()
    {
        return Source;
    }

    public void SetType(string source)
    {
        Source = source;
    }
}