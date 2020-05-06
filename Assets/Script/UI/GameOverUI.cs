using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject drawScreen;

    public GameObject victoryScreen;

    public GameObject[] icons;

    public void Toggle(bool enabled)
    {
        this.gameObject.SetActive(enabled);
    }

    public void ActivateDraw()
    {
        this.victoryScreen.SetActive(false);
        this.drawScreen.SetActive(true);
    }

    public void ActivateVictory(int playerIndex)
    {
        this.drawScreen.SetActive(false);
        this.victoryScreen.SetActive(true);

        foreach (var icon in this.icons)
        {
            icon.SetActive(false);
        }

        this.icons[playerIndex].SetActive(true);
    }
}
