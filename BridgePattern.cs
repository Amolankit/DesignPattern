/// <summary>
/// Implementation Interface
/// </summary>
public interface IDrawingPlatform
{
    void DrawCircle(int radius);
    void DrawSquare(int side);
}

/// <summary>
/// Concrete Implementations for Windows drawing
/// </summary>
public class WindowsDrawing : IDrawingPlatform
{
    public void DrawCircle(int radius)
    {
        Console.WriteLine($"Drawing Circle on Windows with radius {radius}");
    }

    public void DrawSquare(int side)
    {
        Console.WriteLine($"Drawing Square on Windows with side {side}");
    }
}

/// <summary>
/// Concrete Implementations for Linux drawing
/// </summary>
public class LinuxDrawing : IDrawingPlatform
{
    public void DrawCircle(int radius)
    {
        Console.WriteLine($"Drawing Circle on Linux with radius {radius}");
    }

    public void DrawSquare(int side)
    {
        Console.WriteLine($"Drawing Square on Linux with side {side}");
    }
}

/// <summary>
/// Abstraction Interface
/// </summary>
public interface IShape
{
    void Draw();
}

/// <summary>
/// Refined Abstraction for circle
/// </summary>
public class Circle : IShape
{
    private readonly int _radius;
    private readonly IDrawingPlatform _drawingPlatform;

    public Circle(int radius, IDrawingPlatform drawingPlatform)
    {
        _radius = radius;
        _drawingPlatform = drawingPlatform;
    }

    public void Draw()
    {
        _drawingPlatform.DrawCircle(_radius);
    }
}

/// <summary>
/// Refined Abstraction for square
/// </summary>
public class Square : IShape
{
    private readonly int _side;
    private readonly IDrawingPlatform _drawingPlatform;

    public Square(int side, IDrawingPlatform drawingPlatform)
    {
        _side = side;
        _drawingPlatform = drawingPlatform;
    }

    public void Draw()
    {
        _drawingPlatform.DrawSquare(_side);
    }
}

/// <summary>
/// Client Code
/// </summary>
class Program
{
    static void Main()
    {
        IDrawingPlatform windowsDrawing = new WindowsDrawing();
        IDrawingPlatform linuxDrawing = new LinuxDrawing();

        IShape circleOnWindows = new Circle(10, windowsDrawing);
        IShape squareOnLinux = new Square(5, linuxDrawing);

        circleOnWindows.Draw();
        squareOnLinux.Draw();
    }
}
