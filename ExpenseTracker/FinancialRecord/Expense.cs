namespace ExpenseTracker.FinancialRecord;

public class Expense : IFinancialRecord
{
    public string Id { get; set; }
    public double Amount { get; set; }
    public DateOnly TransactionDate { get; set; }
    public DateTime TransactionTimeStamp { get; set; }
    public string Category { get; set; }

    public Expense(double amount, DateOnly transactionDate, string category)
    {
        Id = $"{category}-{GenerateId()}";
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionTimeStamp = DateTime.Now;
        Category = category;
    }

    public string GetId() => Id;

    public double GetAmount() => Amount;

    public DateOnly GetTransactionDate() => TransactionDate;

    public string GetType() => Category;
    public string GenerateId() => Guid.NewGuid().ToString().Substring(0, 4);
    public void SetAmount(double amount)
    {
        Amount = amount;
    }
    public void setTransactionDate(DateOnly date)
    {
        TransactionDate = date;
    }
    public void SetType(string category)
    {
        Category = category;
    }
}
