using UnityEngine;

public enum CellState
{
    NONE, CIRCLE, CROSS
}

public class GameManager : MonoBehaviour
{
    public GameObject crossPrefab;
    public GameObject circlePrefab;

    private Player[] players;
    private int turn;

    public GameObject cellPrefab;
    public int size;

    public CellState[,] board { get; protected set; }

    public CameraController cameraController { get; protected set; }

    public Cell[,] cells;

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.cameraController = FindObjectOfType<CameraController>();
        this.cameraController.SetSize(this.size);

        float offset = (this.size - 1) / 2f;
        this.board = new CellState[this.size, this.size];

        this.cells = new Cell[this.size, this.size];

        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                var go = Instantiate(this.cellPrefab);

                go.transform.position = new Vector3(i - offset, j - offset, 0);
                go.transform.SetParent(this.transform);

                var cell = go.GetComponent<Cell>();
                cell.boardCoordinates = new Vector2Int(i, j);

                this.cells[i, j] = cell;
            }
        }

        this.SetUpPlayers();
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void SetUpPlayers()
    {
        this.players = new Player[]
        {
            new HumanPlayer(CellState.CROSS, this.crossPrefab, this),
            new HumanPlayer(CellState.CIRCLE, this.circlePrefab, this),
        };

        this.turn = 0;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        var currentPlayer = this.players[this.turn];

        if (currentPlayer.DoTheTurn())
        {
            this.turn = (this.turn + 1) % this.players.Length;
        }
    }

    /// ===========================================
    /// <summary>
    /// Insert the piece if the cell is none
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public bool AllocatePiece(int i, int j, Player player)
    {
        CellState cellState = this.board[i, j];

        if (cellState == CellState.NONE)
        {
            this.board[i, j] = player.state;
            var cell = this.cells[i, j];

            Instantiate(player.piecePrefab, cell.transform.position, Quaternion.identity);

            return true;
        }

        return false;
    }
}
