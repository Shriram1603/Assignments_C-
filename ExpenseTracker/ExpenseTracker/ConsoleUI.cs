using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.FinancialRecord;
namespace ExpenseTracker.ExpenseTracker;

public class ConsoleUI
{
    public int DisplayMenu()
    {

        Console.WriteLine("\nEnter the Operation You want to perform: " +
           "\n [1] - Add Expense " +
           "\n [2] - Add Income " +
           "\n [3] - Delete a Record " +
           "\n [4] - Edit a Record " +
           "\n [5] - Display all Records " +
           "\n [6] - Financial Summary" +
           "\n [7] - Exit \n");
        var userInput = Console.ReadLine();
        int userChoice;
        if (!int.TryParse(userInput, out userChoice))
        {
            return 0;
        }
        return userChoice;
    }
    public IFinancialRecord AddExpense()
    {
        string[] categories = { "Rent", "Food", "Utilities", "Entertainment", "Transport" };
        string category = CreateDropDown(categories);
        double amount = GetAmount();
        DateOnly recordDate = GetRecordDate();
        IFinancialRecord record = new Expense(amount, recordDate, category);
        Console.Clear();
        return record;
    }

    public IFinancialRecord AddIncome()
    {
        string[] sources = { "Salary", "FreeLance", "Trading", "Fixed-Deposit", "Bank-insurance" };
        string source = CreateDropDown(sources);
        double amount = GetAmount();
        DateOnly recordDate = GetRecordDate();
        IFinancialRecord record = new Income(amount, recordDate, source);
        Console.Clear();
        return record;
    }

    public void DisplayRecords(IList<IFinancialRecord> records)
    {
        Console.WriteLine("Expense List :");
        foreach (IFinancialRecord record in records)
        {   
            string type;
            if(record is Expense)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                type = "Expense";
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.DarkGreen;
                type = "Income";
            }
            Console.WriteLine($"Id = {record.Id} ; Type : {type}; Category/source = {record.GetType()} ; Amount : {record.Amount}; Date : {record.TransactionDate} ");
        }
        Console.ResetColor();
    }

    public void DisplayFailure(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplaySuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public string GetId(string message)
    {
        Console.WriteLine(message);
        var id = Console.ReadLine();
        if (!String.IsNullOrWhiteSpace(id))
        {
            return id;
        }
        throw new ArgumentException("Id cannot be empty");
    }

    private string CreateDropDown(string[] items )
    {
        int selectedIndex = 0;
        ConsoleKey key;
        while (true)
        {
            DrawMenu(items, selectedIndex);
            
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + items.Length) % items.Length;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1 + items.Length) % items.Length;
            }
            else if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                return items[selectedIndex];
            }
        }
    }

    private void DrawMenu(string[] categories, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("Pick a cause for the transaction :");
        Console.SetCursorPosition(0, 2);

        for (int i = 0; i < categories.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {categories[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {categories[i]}");
            }
        }
    }

    private DateOnly GetRecordDate()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the Date of format  [yyyy-mm-dd] :");
                var userInput = Console.ReadLine();
                DateOnly recordDate = GetValidDate(userInput);
                return recordDate;
            }
            catch (Exception ex) 
            { DisplayFailure(ex.Message); }
            
        }
    }

    private DateOnly GetValidDate(string userInput)
    {   
        if (DateOnly.TryParse(userInput, out DateOnly recordDate))
        {
            return recordDate ;
        }
        else
        {
            throw new ArgumentException("Enter a valid Date of format [yyyy-mm-dd] !!");

        }
    }

    private double GetAmount()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the amount :");
                var userInput = Console.ReadLine();
                double amount = GetValidAmount(userInput);
                return amount;
            }
            catch (Exception ex)
            { DisplayFailure(ex.Message); }
        }
    }

    private double GetValidAmount(string userInput)
    {   
        if (double.TryParse(userInput, out double amount))
        {   
            if(amount >= 0)
            {
                return amount;
            }
            else
            {
                throw new ArgumentException("Amount cannot be a Negative value !!");
            }
        }
        else
        {
            throw new ArgumentException("Enter a valid numeric value !!");

        }
    }
}
