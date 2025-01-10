using System.Security.Cryptography.X509Certificates;

namespace OOPs.EmployeeHierarchy;

/// <summary>
/// This class <see cref="Employee"/> creates a contract for the derived or child classes to follow.
/// </summary>
public abstract class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    /// <summary>
    /// Constructor of base class <see cref="Employee"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="salary"></param>
    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    /// <summary>
    /// Abstract metho to be overridden by child classes
    /// </summary>
    /// <returns>integer</returns>
    public abstract int CalculateBonus();

    /// <summary>
    /// Method to disply the [name, salary , bonus_amount] of an <see cref="Employee"/>
    /// </summary>
    public void PrintDisplay()
    {
        Console.WriteLine($"Name : {Name}; Salary : {Salary}; Bonus : {CalculateBonus()}");
    }
}

/// <summary>
/// Class <see cref="Manager"/> which is of type Employee as it inherits from abstract <see cref="Employee"/> class.
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
    public Manager(string name, decimal salary, Random random) : base(name,salary)
    {
        this._random = random;
    }

    /// <summary>
    /// Calculates a Random Bonus Amount for a Manager.
    /// </summary>
    /// <returns>int Bonus</returns>
    public override int CalculateBonus()
    {
        var Bonus_multiple = _random.Next(4,11);
        return Bonus_multiple*1000;
    }
}

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
    public Developer(string name, decimal salary, Random obj) : base(name,salary) 
    {
        this._random = obj;
    }

    /// <summary>
    /// Calculates a Random Bonus Amount for a Developer.
    /// </summary>
    /// <returns>int Bonus</returns>
    public override int CalculateBonus() {

        var Bonus_multiple = _random.Next(1, 6);
        return Bonus_multiple * 1000;
    }
}