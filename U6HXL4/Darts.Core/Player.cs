namespace Darts.Core;

public class Player
{
    public string name { get; set; }
    public int score { get; set; }
    public List<Throw> throws { get; set; }

    public Player(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public int getMaxThrow()
    {
        return throws.Max(t => t.score);
    }
}
