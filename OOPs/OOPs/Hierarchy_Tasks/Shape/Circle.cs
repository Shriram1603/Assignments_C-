namespace OOPs.Hierarchy_Tasks.Shape;

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