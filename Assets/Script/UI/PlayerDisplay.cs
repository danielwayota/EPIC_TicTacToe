using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public GameObject[] turnFrames;

    public Text[] scoreLabels;

    public Text[] playerLabels;

    public void SetTurn(int playerIndex)
    {
        foreach (var frame in this.turnFrames)
        {
            frame.SetActive(false);
        }

        this.turnFrames[playerIndex].SetActive(true);
    }

    public void SetPlayerName(int playerIndex, string name)
    {
        this.playerLabels[playerIndex].text = name + ":";
    }

    public void UpdateScores()
    {
        int i = 0;
        foreach (var score in ScoreStorage.scores)
        {
            this.scoreLabels[i].text = score.ToString();
            i++;
        }
    }
}
