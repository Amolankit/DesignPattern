using System;
using System.Collections.Generic;

// Step 1: Component Interface
public interface IGraphic
{
    void Draw();
}

// Step 2: Leaf
public class Circle : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

// Step 3: Composite
public class CompositeGraphic : IGraphic
{
    private List<IGraphic> graphics = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        graphics.Add(graphic);
    }

    public void Remove(IGraphic graphic)
    {
        graphics.Remove(graphic);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing Composite Graphic");
        foreach (var graphic in graphics)
        {
            graphic.Draw();
        }
    }
}

class Program
{
    static void Main()
    {
        // Using the Composite Pattern
        var composite = new CompositeGraphic();
        composite.Add(new Circle());
        composite.Add(new Circle());

        var anotherCircle = new Circle();
        
        // Adding a Leaf to the Composite
        composite.Add(anotherCircle);

        // Drawing the composite, which in turn draws all its children
        composite.Draw();
    }
}
