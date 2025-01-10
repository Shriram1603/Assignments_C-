namespace OOPs.BankingSystem;


/// <summary>
/// Class describes the implementation of <see cref="BankAccount"/>
/// </summary>
public class BankAccount
{
    protected string _accountNumber {  get; set; }
    protected decimal _balance { get; set; }

    /// <summary>
    /// Contructor Of <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="accountNumber">Account number of the <see cref="BankAccount"/>.</param>
    /// <param name="balance">Initial ammount aeposited in the <see cref="BankAccount"/>. </param>
    public BankAccount(string accountNumber, decimal balance)
    {
        _accountNumber = accountNumber;
        _balance = balance;
    }
    /// <summary>
    /// Deposits or adds the amount to the existing balance.
    /// </summary>
    /// <param name="amount">Money to be added to the <see cref="BankAccount._balance"/></param>
    public void Deposit(decimal amount)
    {
        _balance = _balance + amount;
        Console.WriteLine($"\t {amount} Deposited.\tCurrent Balance = {_balance} ");
    }

    /// <summary>
    /// Virtual method to be overridden in SavingsAccount and CheckingAccount
    /// </summary>
    /// <param name="amount">Money to be taken or Subtracted from balance</param>
    public void WithDraw(decimal amount) {
        if (amount > _balance) 
        {
            Console.WriteLine("\tInsufficient Funds in Account");
        }
        else 
        {
            _balance -= amount;
            Console.WriteLine($"\t{amount} WithDrawn.\tCurrent Balance = {_balance}");
        }
     }
}

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
        if (amount > _balance) 
        {
            Console.WriteLine("\tInsufficient Funds in Account");
        }
        else if(_balance - amount < _minimumBalance)
        {
            Console.WriteLine($"\tCannot Withdraw {amount}.\tMinimum Balance of {_minimumBalance} must be maintained.\tCurrent Balance = {_balance}.");
        }
        else 
        {
            _balance = _balance - amount;
            Console.WriteLine($"\t{amount} WithDrawn.\tCurrent Balance = {_balance}");
        }
    }
}

/// <summary>
/// Class of type <see cref="BankAccount"/> specifically for <see cref="CheckingAccount"/>.
/// </summary>
public class CheckingAccount : BankAccount
{
    /// <summary>
    /// Constuctor of <see cref="SavingsAccount"/> ; calls base constructor <see cref="BankAccount"/>
    /// </summary>
    /// <param name="accountNumber">Customer's Account Number.</param>
    /// <param name="balance">Customer' Balance Amount.</param>
    public CheckingAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }

    /// <summary>
    /// WithDraw method of <see cref="CheckingAccount"/> which remove restriction in withdrawing.
    /// </summary>
    /// <param name="amount">Money to be taken or Subtracted from balance</param>
    public new void WithDraw(decimal amount) 
    {    
        _balance -= amount;
    }
}