namespace Darts.Core;

public class Game
{
    public List<Player> playerName { get; set; }
    int startingPoint { get; set; }
    bool doubleIn { get; set; }
    bool doubleOut { get; set; }

    public Game(int startingPoint, bool doubleIn, bool doubleOut)
    {
        this.startingPoint = startingPoint;
        this.doubleIn = doubleIn;
        this.doubleOut = doubleOut;
    }



    internal void StartGame()
    {

    }




}
