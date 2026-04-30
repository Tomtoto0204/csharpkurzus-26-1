namespace Darts.Core;

public class Player
{
    public int throwsInTurnCount { get; set; } = 0;
    public string name { get; set; }
    public int score { get; set; }
    public List<Throw> throws { get; set; } = new List<Throw>();

    public Player(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public int getMaxThrow()
    {
        return throws.Max(t => t.score);
    }

    public bool PlayerThrows(string throwString)
    {
        int throwResult = 0;
        try
        {
            throwResult = Convert.ToInt32(throwString);
            if (score - throwResult >= 0)
            {
                score -= throwResult;
                throws.Add(new Throw(throwResult, 1));
                throwsInTurnCount++;
            }
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    //Besokalt e TODO
    public bool isRoundOk()
    {
        return true;
    }
}
