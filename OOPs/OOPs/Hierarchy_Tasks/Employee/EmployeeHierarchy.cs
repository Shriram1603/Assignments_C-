using System.Security.Cryptography.X509Certificates;

namespace OOPs.Hierarchy_Tasks.Employee;

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
    /// Abstract method to be overridden by child classes
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
