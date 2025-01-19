using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.FinancialRecord;

public interface IFinancialRecord
{
    public string GetId();
    public void SetAmount(double amount);
    public double GetAmount();
    public void setTransactionDate(DateOnly date);
    public DateOnly GetTransactionDate();
    public string GetType();
    public void SetType(string type);
}
