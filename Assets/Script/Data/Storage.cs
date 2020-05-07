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

    public static bool _mutedSound;
    public static bool mutedSound
    {
        get => _mutedSound;
        set
        {
            _mutedSound = value;

            PlayerPrefs.SetInt("mutedSound", _mutedSound ? 1 : 0);
        }
    }

    static Storage()
    {
        var storedValue = PlayerPrefs.GetInt("mutedSound", 0);

        _mutedSound = storedValue == 1 ? true : false;
    }

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