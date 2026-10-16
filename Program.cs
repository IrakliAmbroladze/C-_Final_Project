class TemperatureChangedEventArgs : EventArgs
{
    public double Temperature { get; }
    public TemperatureChangedEventArgs(double temperature) { Temperature = temperature; }
}
class Thermometer
{
    private double temperature;
    private readonly double threshold;
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;
    public Thermometer(double threshold)
    {
        this.threshold = threshold;
    }
    public void SetTemperature(double value)
    {
        temperature = value;
        Console.WriteLine($"Temperature: {temperature}°C");
        if (temperature > threshold) TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(temperature));
    }
}
class Logger
{
    public void OnTemperatureChanged(object? sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Logger: high temperature recorded ({e.Temperature}°C).");
    }
}
class Alarm
{
    public void OnTemperatureChanged(object? sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine("Alarm: temperature threshold exceeded!");
    }
}

class Program
{
    static void Main()
    {
        Thermometer thermometer = new(30);
        Logger logger = new();
        Alarm alarm = new();
        thermometer.TemperatureChanged += logger.OnTemperatureChanged;
        thermometer.TemperatureChanged += alarm.OnTemperatureChanged;
        thermometer.SetTemperature(25);
        thermometer.SetTemperature(35);
        thermometer.TemperatureChanged -= logger.OnTemperatureChanged;
        thermometer.TemperatureChanged -= alarm.OnTemperatureChanged;
        Console.WriteLine("Subscribers removed.");
        thermometer.SetTemperature(40);
    }
}