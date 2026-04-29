namespace Darts.Core;

public class Game
{
    string playerName { get; set; }
    int startingPoint { get; set; }
    bool doubleIn { get; set; }
    bool doubleOut { get; set; }

    public Game(string playerName, int startingPoint, bool doubleIn, bool doubleOut)
    {
        this.playerName = playerName;
        this.startingPoint = startingPoint;
        this.doubleIn = doubleIn;
        this.doubleOut = doubleOut;
    }



    internal void StartGame(string playerName, int startingPoint, bool doubleIn, bool doubleOut)
    {
        this.playerName = playerName;
        this.startingPoint = startingPoint;
        this.doubleIn = doubleIn;
        this.doubleOut = doubleOut;
    }




}
