using System;

// Target interface
public interface IWeatherService
{
    string GetWeatherData();
}

// Adaptee (third-party service with XML interface)
public class ThirdPartyWeatherService
{
    public string FetchXMLData()
    {
        // Logic to fetch weather data in XML format
        return "<weather><temperature>72°F</temperature></weather>";
    }
}

// Adapter
public class WeatherServiceAdapter : IWeatherService
{
    private readonly ThirdPartyWeatherService adaptee;

    public WeatherServiceAdapter(ThirdPartyWeatherService adaptee)
    {
        this.adaptee = adaptee;
    }

    public string GetWeatherData()
    {
        // Translate XML data to JSON (simplified for the example)
        string xmlData = adaptee.FetchXMLData();
        // Logic to convert XML to JSON (simplified for the example)
        string jsonData = ConvertXMLtoJSON(xmlData);
        return jsonData;
    }

    private string ConvertXMLtoJSON(string xmlData)
    {
        // Logic to convert XML to JSON (simplified for the example)
        // Implement your XML to JSON conversion logic here
        return "{\"temperature\":\"22°C\"}";
    }
}

// Client code
class Program
{
    static void Main()
    {
        // Instantiate the ThirdPartyWeatherService
        ThirdPartyWeatherService thirdPartyService = new ThirdPartyWeatherService();

        // Create the adapter
        IWeatherService weatherService = new WeatherServiceAdapter(thirdPartyService);

        // Use the adapted service to get weather data
        string jsonData = weatherService.GetWeatherData();

        // Display the result
        Console.WriteLine(jsonData);
    }
}
