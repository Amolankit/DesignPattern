using System;

// Abstract Product: Engine
public interface IEngine
{
    void Start();
}

// Concrete Products
public class SedanEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Sedan Engine started");
    }
}

public class SUVEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("SUV Engine started");
    }
}

// Abstract Product: Interior
public interface IInterior
{
    void AssembleInterior();
}

// Concrete Products
public class SedanInterior : IInterior
{
    public void AssembleInterior()
    {
        Console.WriteLine("Assembling Sedan Interior");
    }
}

public class SUVInterior : IInterior
{
    public void AssembleInterior()
    {
        Console.WriteLine("Assembling SUV Interior");
    }
}

// Abstract Product: Exterior
public interface IExterior
{
    void AssembleExterior();
}

// Concrete Products
public class SedanExterior : IExterior
{
    public void AssembleExterior()
    {
        Console.WriteLine("Assembling Sedan Exterior");
    }
}

public class SUVExterior : IExterior
{
    public void AssembleExterior()
    {
        Console.WriteLine("Assembling SUV Exterior");
    }
}

// Abstract Factory
public interface IVehicleFactory
{
    IEngine CreateEngine();
    IInterior CreateInterior();
    IExterior CreateExterior();
}

// Concrete Factories
public class SedanFactory : IVehicleFactory
{
    public IEngine CreateEngine()
    {
        return new SedanEngine();
    }

    public IInterior CreateInterior()
    {
        return new SedanInterior();
    }

    public IExterior CreateExterior()
    {
        return new SedanExterior();
    }
}

public class SUVFactory : IVehicleFactory
{
    public IEngine CreateEngine()
    {
        return new SUVEngine();
    }

    public IInterior CreateInterior()
    {
        return new SUVInterior();
    }

    public IExterior CreateExterior()
    {
        return new SUVExterior();
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Create a Sedan
        Console.WriteLine("Building Sedan:");
        BuildVehicle(new SedanFactory());

        // Create an SUV
        Console.WriteLine("\nBuilding SUV:");
        BuildVehicle(new SUVFactory());

        Console.ReadLine();
    }

    static void BuildVehicle(IVehicleFactory factory)
    {
        var engine = factory.CreateEngine();
        var interior = factory.CreateInterior();
        var exterior = factory.CreateExterior();

        engine.Start();
        interior.AssembleInterior();
        exterior.AssembleExterior();
    }
}
