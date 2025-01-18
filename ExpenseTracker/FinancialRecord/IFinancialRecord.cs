using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.FinancialRecord;

public interface IFinancialRecord
{
    string Id { get; set; }
    public double Amount { get; set; }
    public DateOnly TransactionDate {  get; set; }
    public DateTime TransactionTimeStamp { get; set; }
    
    public string GenerateId();

    public string GetType();

    public void SetType(string type);
}
