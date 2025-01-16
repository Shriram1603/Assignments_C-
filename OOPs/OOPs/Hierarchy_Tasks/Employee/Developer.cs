namespace OOPs.Hierarchy_Tasks.Employee;

/// <summary>
/// Class Developer which is of type Employee as it inherits from abstract Employee class.
/// </summary>
public class Developer : Employee
{
    private Random _random;

    /// <summary>
    /// Contructor of <see cref="Developer"/> , instatiates <see cref="Employee"/>
    /// </summary>
    /// <param name="name">Name of the Developer.</param>
    /// <param name="salary">Salary of the Developer</param>
    /// <param name="random">Object of type <see cref="Random"/> to calculate bonus</param>
    public Developer(string name, decimal salary, Random obj) : base(name, salary)
    {
        _random = obj;
    }

    /// <summary>
    /// Calculates a random bonus amount for a developer.
    /// </summary>
    /// <returns>int Bonus</returns>
    public override int CalculateBonus()
    {

        var Bonus_multiple = _random.Next(1, 6);
        return Bonus_multiple * 1000;
    }
}