namespace OOPs.ShapeHierarchy;

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

/// <summary>
/// Class <see cref="ReaderWriterLock"/> which is of type Shape as it inherits from abstract <see cref="Shape"/>.
/// </summary>
public class Rectangle : Shape
{
    private readonly string _shapeType = "Rectangle";
    public int Length { get; set; }
    public int Width { get; set; }

    /// <summary>
    /// Contructor of <see cref="Rectangle"/> , instatiates <see cref="Shape"/>
    /// </summary>
    /// <param name="colour">Colour of the Shape</param>
    /// <param name="length">Length of the Rectangle</param>
    /// <param name="width">Width of the Rectangle.</param>
    public Rectangle(string colour,int length, int width) : base(colour)
    {
        Length = length;
        Width = width;
    }

    /// <summary>
    /// Calculates the area of a <see cref="Rectangle"/>.
    /// </summary>
    /// <returns>double length * bredth</returns>
    public override double CalculateArea()
    {
        return this.Length * this.Width;
    }

    /// <summary>
    /// Displays the colour, shape type and area of the shape <see cref="Rectangle"/>.
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
    private readonly string _shapeType = "Circle";
    private double _radius;
    private const double Pi = Math.PI;

    /// <summary>
    /// Contructor of <see cref="Circle"/> , instatiates <see cref="Shape"/>
    /// </summary>
    /// <param name="colour"></param>
    /// <param name="radius"></param>
    public Circle(string colour, double radius) : base(colour) 
    {
        _radius = radius;
    }

    /// <summary>
    /// Calculates the Area of <see cref="Circle"/>.
    /// </summary>
    /// <returns>double 2 * Pi * Radius</returns>
    public override double CalculateArea()
    {
        return 2 * Pi * _radius;
    }

    /// <summary>
    /// Displays the colour, shape type and area of the shape <see cref="Circle"/>.
    /// </summary>
    public new void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, ShapeType : {_shapeType} ,Area :{CalculateArea()}");

    }
}