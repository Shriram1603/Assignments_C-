namespace OOPs.Hierarchy_Tasks.Shape;

/// <summary>
/// This class <see cref="Shape"/> creates a contract for the derived or child classes to follow.
/// </summary>
public abstract class Shape
{
    public string Colour { get; set; }
    public abstract double CalculateArea();

    /// <summary>
    /// Constructor of base class <see cref="Shape"/>
    /// </summary>
    /// <param name="colour"></param>
    public Shape(string colour)
    {
        Colour = colour;
    }

    /// <summary>
    /// Displays colour and area of the shape.
    /// </summary>
    public void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, Area :{CalculateArea()}");
    }
}
