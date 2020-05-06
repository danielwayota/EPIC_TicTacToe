using UnityEngine;

public class StartUpPanel : MonoBehaviour
{
    public GameObject[] playerIcons;

    public void DisplayStartTurn(int playerIndex)
    {
        foreach (var icon in this.playerIcons)
        {
            icon.SetActive(false);
        }

        this.playerIcons[playerIndex].SetActive(true);
    }
}
