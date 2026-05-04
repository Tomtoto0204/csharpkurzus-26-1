using System.Diagnostics;

using Calculator.Core;
using Calculator.HTTP;

internal class Program
{
    private static int Main(string[] args)
    {
        using HttpServer server = new HttpServer(new ConsoleLogger(), 8080);
        server.Start();
        Console.ReadLine();
        server.Stop();
        return 0;
        //Console.WriteLine("Welcome to the calculator!");
        //Console.Write("> ");

        //string expression = Console.ReadLine() ?? string.Empty;

        //ICalculator calculator = CalculatorFactory.Create();
        //Either<double, Exception> result = calculator.Calculate(expression);

        //if (result.TryGetSuccess(out double? validResult))
        //{
        //    Console.WriteLine(validResult);
        //    return 0;
        //}
        //else if (result.TryGetError(out Exception? ex))
        //{
        //    Console.WriteLine(ex.Message);
        //    return -1;
        //}

        //throw new UnreachableException("This shouldn't happen");
    }
}