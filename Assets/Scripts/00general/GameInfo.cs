
public enum GameMode{ PRACTICE, TEST}

public class GameInfo {


    public static string userName = "";
    public static string userClass = "";

    public static GameMode gameMode;

	public static int gameScore = 100;

	public static void Reset()
	{
		userName = "";
		userClass = "";
		gameScore = 100;
	}
}

