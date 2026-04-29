using System.Diagnostics;

using Darts.Core;

namespace Darts.Client;

internal class Program
{
    private static int Main(string[] args)
    {
        int playerCount;
        int startingPoint;
        bool doubleOut;
        bool doubleIn;


        Console.WriteLine("Welcome to my Darts application!");
        Console.Write("> ");

        Console.WriteLine("Player count: ");
        playerCount = Convert.ToInt32(Console.ReadLine());

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

        Game game = new Game(startingPoint, doubleIn, doubleOut);

        for (int i = 0; i < playerCount; i++)
        {
            Console.WriteLine($"Player {i} name: ");
            string playerName = Console.ReadLine();
            if (playerName == "" || playerName == null)
                playerName = $"Player{i}";
            game.playerName.Add(new Player(playerName, startingPoint));
        }


        throw new UnreachableException("This shouldn't happen");
    }
}
