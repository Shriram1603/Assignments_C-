namespace OOPs.EmployeeHierarchy;

/// <summary>
/// This class Employee creates a Contract for the derived or child classes to follow.
/// </summary>
public abstract class Employee
{
    public abstract string Name { get; set; }
    public abstract decimal Salary { get; set; }

    public abstract int CalculateBonus();

    public abstract void PrintDisplay();

}

/// <summary>
/// Class Manager which is of type Employee as it inherits from abstract Employee class.
/// </summary>
public class Manager : Employee
{
    public override string Name { get; set; }
    public override decimal Salary { get; set; }

    private Random _random;

    public Manager(string name, decimal salary, Random obj) {
        Name = name;
        Salary = salary;
        this._random = obj;
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

    /// <summary>
    /// Displays the information Name, Salary, Bonus amount of a Manager.
    /// </summary>
    public override void PrintDisplay() {

        Console.WriteLine($"Name : {Name}; Salary : {Salary}; Bonus : {CalculateBonus()}");
    }
}


/// <summary>
/// Class Developer which is of type Employee as it inherits from abstract Employee class.
/// </summary>
public class Developer : Employee
{
    public override string Name { get; set; }
    public override decimal Salary { get; set; }

    private Random _random;

    public Developer(string name, decimal salary, Random obj)
    {
        Name = name;
        Salary = salary;
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

    /// <summary>
    /// Displays the information Name, Salary, Bonus amount of a Developer.
    /// </summary>
    public override void PrintDisplay() {

        Console.WriteLine($"Name : {Name}; Salary : {Salary}; Bonus : {CalculateBonus()}");

    }

}