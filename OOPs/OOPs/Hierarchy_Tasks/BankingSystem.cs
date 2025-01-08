namespace OOPs.BankingSystem;


/// <summary>
/// Class Describes the implementation of BankAccount
/// </summary>
public class BankAccount
{
    protected string _Account_Number {  get; set; }
    protected decimal _balance { get; set; }


    public BankAccount(string accountNumber, decimal balance)
    {
        _Account_Number = accountNumber;
        _balance = balance;
    }
    /// <summary>
    /// Deposits or adds the amount to the existing balance.
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {
        _balance = _balance + amount;
        Console.WriteLine($"\n {amount} Deposited.\nCurrent Balance = {_balance} ");
    }

    /// <summary>
    /// Virtual method to be overridden in SavingsAccount and CheckingAccount
    /// </summary>
    /// <param name="amount"></param>
    public virtual void WithDraw(decimal amount) {
        if (amount > _balance) 
        {
            Console.WriteLine("Insufficient Funds in Account");
        }
        else 
        {
            _balance -= amount;
            Console.WriteLine($"\n{amount} WithDrawn.\nCurrent Balance = {_balance}");
        }
     }

}

/// <summary>
/// Class of type BankAccount specifically for Savings Account.
/// </summary>
public class SavingsAccount : BankAccount
{
    private const int Minimum_Balance = 5000;
    public SavingsAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }
    /// <summary>
    /// Overriding WithDraw Method to Set a Minimum amount to always be maintain a small amount.
    /// </summary>
    /// <param name="amount"></param>
    public override void WithDraw(decimal amount) {
    
        if (amount > _balance) 
        {
            Console.WriteLine("Insufficient Funds in Account");
        }
        else if(_balance - amount < Minimum_Balance)
        {
            Console.WriteLine($"Cannot Withdraw {amount}.\nMinimum Balance of {Minimum_Balance} must be maintained. \n Current Balance = {_balance}.");
        }
        else 
        {
            _balance = _balance - amount;
            Console.WriteLine($"\n{amount} WithDrawn.\nCurrent Balance = {_balance}");
        }
    }
}

/// <summary>
/// Class of type BankAccount specifically for Checking Account.
/// </summary>
public class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }

    /// <summary>
    /// Overriding WithDraw Method to Remove all restrictions when WithDrawing.
    /// </summary>
    /// <param name="amount"></param>
    public override void WithDraw(decimal amount) { 
        
        _balance -= amount;
    }
}