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

    public void ThrowOneDart() { }

    public bool GameEnd()
    {
        return false;
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