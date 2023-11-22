public interface IStockSubject
{
    void RegisterObserver(IStockObserver observer);
    void UnregisterObserver(IStockObserver observer);
    void NotifyObservers();
}

public class StockMarket : IStockSubject
{
    private List<IStockObserver> observers = new List<IStockObserver>();
    private decimal stockPrice;

    public void RegisterObserver(IStockObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IStockObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(stockPrice);
        }
    }

    public void SetStockPrice(decimal price)
    {
        stockPrice = price;
        NotifyObservers();
    }
}

public interface IStockObserver
{
    void Update(decimal stockPrice);
}

public class Investor : IStockObserver
{
    private string name;

    public Investor(string name)
    {
        this.name = name;
    }

    public void Update(decimal stockPrice)
    {
        Console.WriteLine($"{name} received an update. New stock price: {stockPrice}");
    }
}

class Program
{
    static void Main()
    {
        StockMarket stockMarket = new StockMarket();

        Investor investor1 = new Investor("Chuck Norris");
        Investor investor2 = new Investor("John Cena");

        stockMarket.RegisterObserver(investor1);
        stockMarket.RegisterObserver(investor2);

        // Simulate stock price changes
        stockMarket.SetStockPrice(150.0m);
        stockMarket.SetStockPrice(155.5m);

        // Unregister an observer
        stockMarket.UnregisterObserver(investor1);

        // Simulate more stock price changes
        stockMarket.SetStockPrice(160.2m);
    }
}
