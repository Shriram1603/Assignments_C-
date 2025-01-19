using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.FinancialRecord;

namespace ExpenseTracker.ExpenseTracker;

public class TransactionManager
{
    private readonly TransactionRepository _repository;
    private readonly ConsoleUI _consoleUI;

    public TransactionManager(TransactionRepository repository, ConsoleUI consoleUI)
    {
        _repository = repository;
        _consoleUI = consoleUI;
    }
    public int DisplayMenu()
    {
        int userChoice = _consoleUI.DisplayMenu();
        return userChoice;
    }
    public void AddExpense()
    {
        IFinancialRecord record = _consoleUI.AddExpense();
        _repository.AddRecord(record);
        _consoleUI.DisplaySuccess("[+] Record added Successfully !!");
    }

    public void UpdateRecord()
    {
        string id = _consoleUI.GetId("Enter the Id of the expense you want to update ?");
        if (_repository.IsRecordPresent(id))
        {
            IFinancialRecord record = _repository.getRecord(id);
            _consoleUI.DisplaySuccess($"Updating {record.GetId()}");
            double amount = _consoleUI.GetAmount($"Enter the Amount [{record.GetAmount()}] : ");
            DateOnly dateToUpdate = _consoleUI.GetRecordDate($"Enter the Date of format  [yyyy-mm-dd] [{record.GetTransactionDate()}] : ");
            _consoleUI.DisplaySuccess($"[+] Record {id} Updated successfully !!");
        }
        else
        {
            _consoleUI.DisplayFailure($"[-] No record with id : {id} is found");
        }
    }

    public void AddIncome()
    {
        IFinancialRecord record = _consoleUI.AddIncome();
        _repository.AddRecord(record);
        _consoleUI.DisplaySuccess("[+] Record added Successfully !!");
    }

    public void RemoveRecord()
    {
        string id = _consoleUI.GetId("Enter the Id of the record you want to remove : ");
        if (_repository.IsRecordPresent(id))
        {
            IFinancialRecord record = _repository.getRecord(id);
            _repository.DeleteRecord(record);
            _consoleUI.DisplaySuccess($"[+] Record {id} deleted successfully !!");
        }
        else
        {
            _consoleUI.DisplayFailure($"[-] No record with id : {id} is found");
        }
    }

    public void DisplayRecords()
    {
        IList<IFinancialRecord> records = _repository.GetAllRecords();
        _consoleUI.DisplayRecords(records);

    }

    public void ShowSummary()
    {
        string summary = _repository.ShowTransactionSummary();
        _consoleUI.DisplaySuccess(summary);
    }

}
