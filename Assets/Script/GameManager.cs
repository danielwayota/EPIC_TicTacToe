using UnityEngine;

public enum CellState
{
    NONE, CIRCLE, CROSS
}

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public int size;

    private CellState[,] board;

    private CameraController cameraController;

    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.cameraController = FindObjectOfType<CameraController>();
        this.cameraController.SetSize(this.size);

        float offset = (this.size - 1) / 2f;
        this.board = new CellState[this.size, this.size];

        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                var go = Instantiate(this.cellPrefab);

                go.transform.position = new Vector3(i - offset, j - offset, 0);
                go.transform.SetParent(this.transform);
            }
        }
    }
}
