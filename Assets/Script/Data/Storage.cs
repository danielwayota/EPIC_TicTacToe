using UnityEngine;

public class Storage
{
    private static int[] _scores;
    public static int[] scores
    {
        get {
            if (_scores == null)
                ResetScores();
            return _scores;
        }
    }

    public static bool mutedSound { get; set; } = false;

    public static void ResetScores()
    {
        _scores = new int[2];
    }

    public static void PlayerWin(int playerIndex)
    {
        if (_scores == null)
            ResetScores();

        _scores[playerIndex]++;
    }
}