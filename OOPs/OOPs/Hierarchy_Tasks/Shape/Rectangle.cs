namespace OOPs.Hierarchy_Tasks.Shape;

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
    public Rectangle(string colour, int length, int width) : base(colour)
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
        return Length * Width;
    }

    /// <summary>
    /// Displays the colour, shape type and area of the shape <see cref="Rectangle"/>.
    /// </summary>
    public new void PrintDetails()
    {
        Console.WriteLine($"Colour : {Colour}, ShapeType : {_shapeType} ,Area :{CalculateArea()}");
    }
}
