using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.FinancialRecord;

namespace ExpenseTracker.ExpenseTracker;

public class ConsoleUI
{

    public IFinancialRecord AddExpense()
    {

    }

    private double GetAmount()
    {
        while (true)
        {
            Console.WriteLine("Enter the amount :");
            var userInput = Console.ReadLine();
            double amount = ConvertToDouble(userInput);
        }
    }

    private double ConvertToDouble(string userInput)
    {   
        if (double.TryParse(userInput, out double amount))
        {
            return amount;
        }
        else
        {
            Console.WriteLine("Enter a Valid numeric value !!");

        }
    }
}
