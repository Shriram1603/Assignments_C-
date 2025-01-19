using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.FinancialRecord;

public interface IFinancialRecord
{
    
    public void SetAmount(double amount);
    public void setTransactionDate(DateOnly date);
    public string GenerateId();

    public string GetType();

    public string GetId();

    public double GetAmount();

    public DateOnly GetTransactionDate();

    public void SetType(string type);
}
