namespace Code;

public class TemperatureConverter
{
    public double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
    public double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
}
