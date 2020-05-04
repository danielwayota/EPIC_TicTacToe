using UnityEngine;

public enum GameMode
{
    PLAYER_VS_PLAYER,
    PLAYER_VS_AI
}

public enum BoardSize
{
    SMALL, BIG
}

public class Config : MonoBehaviour
{
    public GameMode mode = GameMode.PLAYER_VS_PLAYER;
    public BoardSize size = BoardSize.SMALL;

    public static Config _current;
    public static Config current
    {
        get
        {
            if (_current == null)
            {
                _current = FindObjectOfType<Config>();
            }

            if (_current == null)
            {
                var go = new GameObject("Config");

                go.AddComponent(typeof(Config));
            }

            return _current;
        }
    }

    void Awake()
    {
        _current = current;
    }
}
