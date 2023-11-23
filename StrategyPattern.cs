using System;

/// <summary>
/// Payment Strategy interface
/// </summary>
public interface IPaymentStrategy
{
    /// <summary>
    /// Pay method
    /// </summary>
    /// <param name="amount">The amount to pay</param>
    void Pay(double amount);
}


/// <summary>
/// Concrete strategies class implementation of credit card
/// </summary>
public class CreditCardPayment : IPaymentStrategy
{
    /// <summary>
    /// Pay method
    /// </summary>
    /// <param name="amount">The amount to pay</param>
    public void Pay(double amount)
    {
        Console.WriteLine($"Amount:- ${amount} paid using Credit Card");
    }
}

/// <summary>
/// Concrete strategies class implementation of pay pal
/// </summary>
public class PayPalPayment : IPaymentStrategy
{
    /// <summary>
    /// Pay method
    /// </summary>
    /// <param name="amount">The amount to pay</param>
    public void Pay(double amount)
    {
        Console.WriteLine($"Amount:- ${amount} paid using PayPal");
    }
}


/// <summary>
/// The context class
/// </summary>
public class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="paymentStrategy">Injected dependency payment strategy</param>
    public ShoppingCart(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    /// <summary>
    /// Checkout method
    /// </summary>
    /// <param name="amount">Amout of cart checkout</param>
    public void Checkout(double amount)
    {
        _paymentStrategy.Pay(amount);
    }
}


/// <summary>
/// Client code
/// </summary>
public class Program
{
    static void Main()
    {
        CreditCardPayment creditCardPayment = new CreditCardPayment();
        PayPalPayment paypalPayment = new PayPalPayment();

        // Customer one is trying to pay by credit card.
        ShoppingCart shoppingCartCustomer1 = new ShoppingCart(creditCardPayment);
        shoppingCartCustomer1.Checkout(1000000); // This Customer is too rich :)

        // Customer tow is trying to pay by Pay pal.
        ShoppingCart shoppingCartCustomer2 = new ShoppingCart(paypalPayment);
        shoppingCartCustomer2.Checkout(50); // This is me.
    }
}
