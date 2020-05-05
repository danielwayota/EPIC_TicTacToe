using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneName.MENU);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneName.GAME);
    }
}
