namespace OOPs.Hierarchy_Tasks.Employee;

/// <summary>
/// Class <see cref="Manager"/> which is of type employee as it inherits from abstract <see cref="Employee"/> class.
/// </summary>
public class Manager : Employee
{
    private Random _random;

    /// <summary>
    /// Contructor of <see cref="Manager"/> , instatiates <see cref="Employee"/>
    /// </summary>
    /// <param name="name">Name of the Manager.</param>
    /// <param name="salary">Salary of the manager</param>
    /// <param name="random">Object of <see cref="Random"/> to calculate bonus</param>
    public Manager(string name, decimal salary, Random random) : base(name, salary)
    {
        _random = random;
    }

    /// <summary>
    /// Calculates a random bonus amount for a manager.
    /// </summary>
    /// <returns>int Bonus</returns>
    public override int CalculateBonus()
    {
        var Bonus_multiple = _random.Next(4, 11);
        return Bonus_multiple * 1000;
    }
}
