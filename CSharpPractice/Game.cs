public class Game
{
    public string Name { get; set; }

    // public readonly DateTime CreatedAt;
    public DateTime CreatedAt { get; }
    // the two above are basically the same, they roughly mean:
    // set it during construction, then don't allow outside code to change it

    public static int GamesCreated { get; private set; } // this automatically becomes 0 by default
    
    public const int MaxPlayers = 4;

    public Game(string gameName)
    {
        Name = gameName;
        GamesCreated++;
        CreatedAt = DateTime.Now;
    }
}