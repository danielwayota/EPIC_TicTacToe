using UnityEngine;

public class ScoreStorage
{
    private static int[] _scores;
    public static int[] scores
    {
        get {
            if (_scores == null)
                Reset();
            return _scores;
        }
    }

    public static void Reset()
    {
        _scores = new int[2];
    }

    public static void PlayerWin(int playerIndex)
    {
        if (_scores == null)
            Reset();

        _scores[playerIndex]++;
    }
}