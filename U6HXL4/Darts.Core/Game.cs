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
        if (multiplier < 1 || multiplier > 3 || !isThrowable(throwScore))
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
            .OrderByDescending(p => p.score)
            .Select(p => (p.name, p.score))
            .ToList();
        return results;
    }



}