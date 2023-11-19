using System;

// Step 1: Component Interface
public interface ICoffee
{
    int Cost();
}

// Step 2: Concrete Component
public class SimpleCoffee : ICoffee
{
    public int Cost()
    {
        return 10;
    }
}

// Step 3: Decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual int Cost()
    {
        return _coffee.Cost();
    }
}

// Step 4: Concrete Decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override int Cost()
    {
        return _coffee.Cost() + 5;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override int Cost()
    {
        return _coffee.Cost() + 2;
    }
}

class Program
{
    static void Main()
    {
        // Creating a simple coffee
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine("Cost of Simple Coffee: " + coffee.Cost());

        // Adding milk to the coffee using a decorator
        ICoffee milkCoffee = new MilkDecorator(coffee);
        Console.WriteLine("Cost of Coffee with Milk: " + milkCoffee.Cost());

        // Adding sugar to the coffee using a decorator
        ICoffee sugarMilkCoffee = new SugarDecorator(milkCoffee);
        Console.WriteLine("Cost of Coffee with Milk and Sugar: " + sugarMilkCoffee.Cost());
    }
}
