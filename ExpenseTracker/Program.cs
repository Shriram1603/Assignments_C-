using ExpenseTracker.ExpenseTracker;


namespace ExpenseTracker
{
    internal class Program
    {
        static void Main()
        {   
            ConsoleUI _consoleUI = new ConsoleUI();
            TransactionRepository _transactionRepository = new TransactionRepository();
            TransactionManager _manager = new TransactionManager(_transactionRepository,_consoleUI);
            bool isRunning = true;
            while (isRunning)
            {
                UserChoice userChoice = (UserChoice)_manager.DisplayMenu();
                switch(userChoice)
                {
                    case UserChoice.AddExpense:
                        _manager.AddExpense();
                        break;
                    case UserChoice.AddIncome:
                        _manager.AddIncome();
                        break;
                    case UserChoice.Delete:
                        _manager.RemoveRecord();
                        break;
                    case UserChoice.Edit:
                        break;
                    case UserChoice.Display:
                        _manager.DisplayRecords();
                        break;
                    case UserChoice.Exit:
                        isRunning = false;
                        break;
                    case UserChoice.FinancialSummary:
                        _manager.ShowSummary();
                        break;
                    default:
                        Console.WriteLine("That Feature is not available Yet !!");
                        break;
                }
            }
        }
    }
}
