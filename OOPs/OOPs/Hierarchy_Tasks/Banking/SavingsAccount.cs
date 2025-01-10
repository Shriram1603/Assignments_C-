namespace OOPs.Hierarchy_Tasks.Banking;

/// <summary>
/// Class of type <see cref="BankAccount"/> specifically for <see cref="SavingsAccount"/>.
/// </summary>
public class SavingsAccount : BankAccount
{
    private const int _minimumBalance = 5000;

    /// <summary>
    /// Constuctor of <see cref="SavingsAccount"/> ; calls base constructor <see cref="BankAccount"/>
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="balance"></param>
    public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }

    /// <summary>
    /// Withdraw method for savings account to set a minimum amount to always maintain a set amount.
    /// </summary>
    /// <param name="amount">Money to be taken or Subtracted from balance</param>
    public new void WithDraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("\tInsufficient Funds in Account");
        }
        else if (Balance - amount < _minimumBalance)
        {
            Console.WriteLine($"\tCannot Withdraw {amount}.\tMinimum Balance of {_minimumBalance} must be maintained.\tCurrent Balance = {Balance}.");
        }
        else
        {
            Balance = Balance - amount;
            Console.WriteLine($"\t{amount} WithDrawn.\tCurrent Balance = {Balance}");
        }
    }
}
