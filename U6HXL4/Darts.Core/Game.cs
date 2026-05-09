namespace Darts.Core;

public class Game
{
    public List<Player> players { get; set; } = new List<Player>();
    public int currentPlayer = 0;
    public int startingPoint { get; set; }
    public bool doubleIn { get; set; }
    public bool doubleOut { get; set; }

    public Game(int startingPoint, bool doubleIn, bool doubleOut)
    {
        this.startingPoint = startingPoint;
        this.doubleIn = doubleIn;
        this.doubleOut = doubleOut;
    }

    public Game()
    {

    }
    public Player getCurrentPlayer()
    {
        return players[currentPlayer];
    }

    public void nextPlayer()
    {
        if (players.Count == 1)
            return;

        if (currentPlayer + 1 == players.Count)
        {
            currentPlayer = 0;
        }
        else
        {
            currentPlayer++;
        }
    }

    public bool PlayerThrowsOneDart(string dartThrow = "")
    {
        string[] parts = dartThrow.Split(' ');
        int multiplier = 1;
        int throwScore = 0;
        if (parts.Length > 1)
        {
            try
            {
                multiplier = Convert.ToInt32(parts[0]);
                throwScore = Convert.ToInt32(parts[1]);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        if (multiplier < 1 || multiplier > 3 || !isThrowable(throwScore) || (multiplier == 3 && throwScore == 25))
            return false;

        Throw currentThrow = new Throw(throwScore, multiplier);
        getCurrentPlayer().PlayerThrows(currentThrow);

        return true;

    }

    private bool isThrowable(int number)
    {
        if (number < 0 || number > 25)
            return false;
        if (number > 20 && number < 25)
            return false;
        return true;
    }

    public bool isGameEnd()
    {
        return getCurrentPlayer().score == 0;
    }


    public List<(string, int)> Scoreboard()
    {
        List<(string, int)> results = [];

        results = players
            .OrderBy(p => p.score)
            .Select(p => (p.name, p.score))
            .ToList();
        return results;
    }

    public void saveScoreboard()
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        docPath = Path.Combine(docPath, "dartsscores");
        Directory.CreateDirectory(docPath);
        string date = DateTime.Today.ToString("yyyy_MM_dd");
        int i = 0;
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"Scoreboard_{date}.txt")))
        {

            outputFile.WriteLine("Scoreboard:");
            foreach (var player in Scoreboard())
            {
                i++;
                outputFile.WriteLine($"#{i}: Name: {player.Item1} , Points left: {player.Item2}");
            }

            i = 0;
            outputFile.WriteLine();
            outputFile.WriteLine("Biggest throws for each player");
            foreach (var player in players)
            {
                i++;
                outputFile.WriteLine($"#{i}: Name: {player.name} , Biggest: {player.getMaxThrow()}");
            }
        }



    }
}