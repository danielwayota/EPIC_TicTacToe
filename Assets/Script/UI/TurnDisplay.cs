using UnityEngine;

public class TurnDisplay : MonoBehaviour
{
    public GameObject[] turnFrames;

    public void SetTurn(int playerIndex)
    {
        foreach (var frame in this.turnFrames)
        {
            frame.SetActive(false);
        }

        this.turnFrames[playerIndex].SetActive(true);
    }
}
