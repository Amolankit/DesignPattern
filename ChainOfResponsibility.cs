using System;

/// <summary>
/// Expense Doamin class
/// </summary>
public class Expense
{
    public required string Description { get; set; }
    public double Amount { get; set; }
}

/// <summary>
/// Expense handler class
/// </summary>
public abstract class ExpenseHandler
{
    protected ExpenseHandler? NextHandler;

    public void SetNextHandler(ExpenseHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public abstract void ApproveExpense(Expense expense);
}

/// <summary>
/// Manager level ExpenseHandler
/// </summary>
public class Manager : ExpenseHandler
{
    public override void ApproveExpense(Expense expense)
    {
        if (expense.Amount <= 1000)
        {
            Console.WriteLine($"Approved amount:- ${expense.Amount} by Manager");
        }
        else
        {
            NextHandler?.ApproveExpense(expense);
        }
    }
}

/// <summary>
/// Director level Expense Handler
/// </summary>
public class Director : ExpenseHandler
{
    public override void ApproveExpense(Expense expense)
    {
        if (expense.Amount <= 5000)
        {
            Console.WriteLine($"Approved amount:- ${expense.Amount} by Director.");
        }
        else
        {
            NextHandler?.ApproveExpense(expense);
        }
    }
}

/// <summary>
/// CFO level Expense Handler
/// </summary>
public class CFO : ExpenseHandler
{
    public override void ApproveExpense(Expense expense)
    {
        if (expense.Amount <= 10000)
        {
            Console.WriteLine($"Approved amount:- ${expense.Amount} by CFO");
        }
        else
        {
            Console.WriteLine($"Amout:- ${expense.Amount} : This is too expensive and can not be approved by just CFO, this need approval from borad");
        }
    }
}

/// <summary>
/// Main class
/// </summary>
public class Program
{
    static void Main()
    {
        // Creating a chain of handlers
        ExpenseHandler manager = new Manager();
        ExpenseHandler director = new Director();
        ExpenseHandler cfo = new CFO();

        // Creating a chain of hirerchy
        manager.SetNextHandler(director);
        director.SetNextHandler(cfo);

        // Client initiates the request
        Expense expense1 = new() { Description = "Team Lunch", Amount = 800 };
        manager.ApproveExpense(expense1);

        Expense expense2 = new() { Description = "Projector Purchase", Amount = 5500 };
        manager.ApproveExpense(expense2);

        Expense expense3 = new() { Description = "Conference Sponsorship", Amount = 12000 };
        manager.ApproveExpense(expense3);
    }
}
