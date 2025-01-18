using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.FinancialRecord;

namespace ExpenseTracker.ExpenseTracker;

public class TransactionRepository
{
    private IList<IFinancialRecord> _financialRecords = new List<IFinancialRecord>();

    public void AddRecord(IFinancialRecord record)
    {
        _financialRecords.Add(record);
    }

    public void DeleteRecord(IFinancialRecord record)
    {
        _financialRecords.Remove(record);
    }

    public IFinancialRecord getRecord(string Id)
    {
        return _financialRecords.FirstOrDefault(i => i.Id == Id);
    }

    public IList<IFinancialRecord> GetAllRecords()
    {
        return _financialRecords;
    }

    public void EditRecord(IFinancialRecord record, double amount, DateOnly transactionDate, string category)
    {
        record.Amount = amount;
        record.TransactionDate = transactionDate;
        record.SetType(category);
    }

    public bool isRecordPresent(string id)
    {
        IFinancialRecord record = getRecord(id);
        return record != null;
    }
}
