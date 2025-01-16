namespace OOPs.Hierarchy_Tasks.Banking;


/// <summary>
/// Class describes the implementation of <see cref="BankAccount"/>
/// </summary>
public class BankAccount
{
    protected string AccountNumber { get; set; }
    protected decimal Balance { get; set; }

    /// <summary>
    /// Contructor Of <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="accountNumber">Account number of the <see cref="BankAccount"/>.</param>
    /// <param name="balance">Initial ammount aeposited in the <see cref="BankAccount"/>. </param>
    public BankAccount(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    /// <summary>
    /// Deposits or adds the amount to the existing balance.
    /// </summary>
    /// <param name="amount">Money to be added to the <see cref="Balance"/></param>
    public void Deposit(decimal amount)
    {
        Balance = Balance + amount;
        Console.WriteLine($"\t {amount} Deposited.\tCurrent Balance = {Balance} ");
    }

    /// <summary>
    /// Method to withdraw amount from <see cref="BankAccount"/>
    /// </summary>
    /// <param name="amount">Money to be taken or subtracted from balance</param>
    public void WithDraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("\tInsufficient Funds in Account");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"\t{amount} WithDrawn.\tCurrent Balance = {Balance}");
        }
    }
}
