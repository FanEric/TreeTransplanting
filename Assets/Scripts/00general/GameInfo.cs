using UnityEngine;
using System.Collections;

public enum GameMode{ PRECTICE, TEST}

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

