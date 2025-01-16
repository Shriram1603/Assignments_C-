namespace OOPs.Hierarchy_Tasks.Banking;

/// <summary>
/// Class of type <see cref="BankAccount"/> specifically for <see cref="CheckingAccount"/>.
/// </summary>
public class CheckingAccount : BankAccount
{
    /// <summary>
    /// Constuctor of <see cref="SavingsAccount"/> ; calls base constructor <see cref="BankAccount"/>
    /// </summary>
    /// <param name="accountNumber">Customer's account number.</param>
    /// <param name="balance">Customer's balance amount.</param>
    public CheckingAccount(string accountNumber, decimal balance) : base(accountNumber, balance) { }

    /// <summary>
    /// WithDraw method of <see cref="CheckingAccount"/> which remove restriction in withdrawing.
    /// </summary>
    /// <param name="amount">Money to be taken or subtracted from <see cref="BankAccount.Balance"/></param>
    public new void WithDraw(decimal amount)
    {
        Balance -= amount;
    }
}