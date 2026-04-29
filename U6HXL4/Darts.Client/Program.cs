using System.Diagnostics;

using Darts.Core;

namespace Darts.Client;

internal class Program
{
    private static int Main(string[] args)
    {
        string playerName;
        int startingPoint;
        bool doubleOut;
        bool doubleIn;


        Console.WriteLine("Welcome to my Darts application!");
        Console.Write("> ");

        Console.WriteLine("Player name: ");
        playerName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Starting point? (301, 501): ");
        startingPoint = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Double in? [Y/N]");
        if ((Console.ReadLine() ?? string.Empty) == "Y")
        {
            doubleIn = true;
        }
        else
        {
            doubleIn = false;
        }
        Console.WriteLine("Double Out? [Y/N]: ");
        if ((Console.ReadLine() ?? string.Empty) == "Y")
        {
            doubleOut = true;
        }
        else
        {
            doubleOut = false;
        }

        Game game = new Game(playerName, startingPoint, doubleIn, doubleOut);


        throw new UnreachableException("This shouldn't happen");
    }
}
