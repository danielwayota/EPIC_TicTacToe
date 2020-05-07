using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Toggle gameMode1vs1;
    public Toggle gameMode1vsAI;

    public Toggle size3x3;
    public Toggle size4x4;

    public Toggle soundToggle;

    private Config config;

    /// ===========================================
    void Start()
    {
        Storage.ResetScores();

        this.config = Config.current;
        DontDestroyOnLoad(this.config.gameObject);

        switch (this.config.mode)
        {
            case GameMode.PLAYER_VS_PLAYER:
                this.gameMode1vs1.isOn = true;
                break;
            case GameMode.PLAYER_VS_AI:
                this.gameMode1vsAI.isOn = true;
                break;
        }

        switch (this.config.size)
        {
            case BoardSize.SMALL:
                this.size3x3.isOn = true;
                break;
            case BoardSize.BIG:
                this.size4x4.isOn = true;
                break;
        }

        this.soundToggle.isOn = Storage.mutedSound;
    }

    /// ===========================================
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// ===========================================
    public void ToggleGameMode1vs1(bool v)
    {
        if (v)
        {
            this.config.mode = GameMode.PLAYER_VS_PLAYER;
        }
    }

    /// ===========================================
    public void ToggleGameMode1vsAI(bool v)
    {
        if (v)
        {
            this.config.mode = GameMode.PLAYER_VS_AI;
        }
    }

    /// ===========================================
    public void ToggleBoardSize3x3(bool v)
    {
        if (v)
        {
            this.config.size = BoardSize.SMALL;
        }
    }

    /// ===========================================
    public void ToggleBoardSize4x4(bool v)
    {
        if (v)
        {
            this.config.size = BoardSize.BIG;
        }
    }

    /// ===========================================
    public void ToggleSound(bool v)
    {
        Storage.mutedSound = v;
    }

    /// ===========================================
    public void StartGame()
    {
        SceneManager.LoadScene(SceneName.GAME);
    }
}
