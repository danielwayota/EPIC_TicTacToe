using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public GameObject[] turnFrames;

    public Text[] scoreLabels;

    public void SetTurn(int playerIndex)
    {
        foreach (var frame in this.turnFrames)
        {
            frame.SetActive(false);
        }

        this.turnFrames[playerIndex].SetActive(true);
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
