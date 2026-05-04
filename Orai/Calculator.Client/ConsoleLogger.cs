using Calculator.HTTP;

internal class ConsoleLogger : ILogger
{
    private object _lock = new object();

    public void Error(string message)
    {
        lock (_lock)
        {
            Console.WriteLine(message);
        }
        
    }

    public void Info(string message)
    {
        lock (_lock)
        {
            Console.WriteLine(message);
        }
    }
}
