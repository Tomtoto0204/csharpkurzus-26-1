using System.Diagnostics;

using Darts.Core;

namespace Darts.Client;

internal class Program
{
    private static int Main(string[] args)
    {
        int playerCount = 0;
        int startingPoint = 0;
        bool doubleIn;
        bool doubleOut;
        bool gameActive;



        Console.WriteLine("Welcome to my Darts application!");
        Console.Write("> ");

        while (true)
        {
            try
            {
                Console.WriteLine("Player count: ");
                playerCount = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number!");
            }
        }
        while (true)
        {
            try
            {
                Console.WriteLine("Starting point? (301, 501): ");
                startingPoint = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number!");
            }
        }
        Console.WriteLine("Double in? [Y/N]");
        doubleIn = Console.ReadLine()?.ToUpper() == "Y";

        Console.WriteLine("Double Out? [Y/N]: ");
        doubleOut = Console.ReadLine()?.ToUpper() == "Y";

        Game game = new(startingPoint, doubleIn, doubleIn);

        for (int i = 1; i < playerCount + 1; i++)
        {
            Console.WriteLine($"Player {i} name: ");
            string playerName = Console.ReadLine();
            if (playerName == "" || playerName == null)
                playerName = $"Player{i}";
            game.players.Add(new Player(playerName, startingPoint));

        }

        Console.WriteLine("GAME CREATED! HAVE FUN!");
        gameActive = true;


        //while jatek aktiv
        //currentplayer 3 Throw()/next/scoreboard
        //IF Gameend(){
        //  active rotty
        //  Scoreboard}
        //nextTurn()
        //


        ScoreboardConsoleWrite();

        while (gameActive)
        {
            PlayersTurn();
            OneThrow();
        }

        string OneThrow()
        {
            return Console.ReadLine();
        }

        void PlayersTurn()
        {
            Player currentPlayer = game.getCurrentPlayer();
            Console.WriteLine($"{currentPlayer.name}'s turn");
        }


        void ScoreboardConsoleWrite()
        {
            foreach (var player in game.Scoreboard())
            {
                Console.WriteLine($"Name: {player.Item1} , Points left: {player.Item2}");
            }
        }






        throw new UnreachableException("This shouldn't happen");
    }
}
