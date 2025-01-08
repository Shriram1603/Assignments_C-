namespace OOPs.ShapeHierarchy;


/// <summary>
/// This class Shape creates a Contract for the derived or child classes to follow.
/// </summary>
public abstract class Shape
{
    public abstract string Colour { get; set; }
    public abstract double CalculateArea();
    public void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, Area :{CalculateArea()}");

    }
}

/// <summary>
/// Class Rectangle which is of type Shape as it inherits from abstract shape class.
/// </summary>
public class Rectangle : Shape
{
    public override string Colour { get; set; }
    private readonly string _shapeType = "Rectangle";
    public int Length { get; set; }
    public int Width { get; set; }

    public Rectangle(string colour, int length, int width)
    {
        Colour = colour;
        Length = length;
        Width = width;

    }
    /// <summary>
    /// Calculates the Area of a Rectangle.
    /// </summary>
    /// <returns>double Length * Bredth</returns>
    public override double CalculateArea()
    {
        return this.Length * this.Width;
    }
    /// <summary>
    /// Displays the Colour, Shape Type and Area of the shape Rectangle.
    /// </summary>
    public new void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, ShapeType : {_shapeType} ,Area :{CalculateArea()}");
    }
}

/// <summary>
/// Class Circle which is of type Shape as it inherits from abstract shape class.
/// </summary>
public class Circle : Shape
{

    public override string Colour { get; set; }
    private readonly string _shapeType = "Circle";

    private double _radius;

    private const double Pi = Math.PI;

    public Circle(string colour, double radius)
    {
        Colour = colour;
        _radius = radius;
    }
    /// <summary>
    /// Calculates the Area of a Circle.
    /// </summary>
    /// <returns>double 2 * Pi * Radius</returns>
    public override double CalculateArea()
    {
        return 2 * Pi * _radius;
    }

    /// <summary>
    /// Displays the Colour, Shape Type and Area of the shape Circle.
    /// </summary>
    public new void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, ShapeType : {_shapeType} ,Area :{CalculateArea()}");

    }

}