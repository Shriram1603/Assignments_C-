using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.ExpenseTracker;

public class TransactionManager
{
    private readonly TransactionRepository _repository;
    private readonly ConsoleUI consoleUI;

    public TransactionManager(TransactionRepository repository, ConsoleUI consoleUI)
    {
        _repository = repository;
        this.consoleUI = consoleUI;
    }
}
