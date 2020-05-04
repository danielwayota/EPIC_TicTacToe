using UnityEngine;

public enum CellPlayer
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

    public CellPlayer[,] board { get; protected set; }

    public CameraController cameraController { get; protected set; }

    public Cell[,] cells;

    private bool paused;

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.paused = false;

        this.cameraController = FindObjectOfType<CameraController>();
        this.cameraController.SetSize(this.size);

        // Generate the board and store the data
        float offset = (this.size - 1) / 2f;

        this.board = new CellPlayer[this.size, this.size];
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
    /// Creates each player data
    /// </summary>
    void SetUpPlayers()
    {
        this.players = new Player[]
        {
            new HumanPlayer(CellPlayer.CROSS, this.crossPrefab, this),
            new HumanPlayer(CellPlayer.CIRCLE, this.circlePrefab, this),
        };

        this.turn = 0;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        if (this.paused)
        {
            return;
        }

        var currentPlayer = this.players[this.turn];

        if (currentPlayer.DoTheTurn())
        {
            this.turn = (this.turn + 1) % this.players.Length;

            bool gameOver = this.CheckGameOver();

            if (gameOver)
            {
                // TODO: Show some thing
                this.paused = true;
            }
            else
            {
                this.finalLine = this.CheckLines();
                if (this.finalLine != null)
                {
                    Debug.Log("LINE: " + this.finalLine.ToString());
                    this.paused = true;
                }
            }
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
        CellPlayer cellState = this.board[i, j];

        if (cellState == CellPlayer.NONE)
        {
            this.board[i, j] = player.state;
            var cell = this.cells[i, j];

            Instantiate(player.piecePrefab, cell.transform.position, Quaternion.identity);

            cell.Disable();

            return true;
        }

        return false;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    public Line CheckLines()
    {
        Line line = new Line();

        // Horizontal lines
        for (int j = 0; j < this.size; j++)
        {
            line.Clear();
            for (int i = 0; i < this.size; i++)
            {
                if (line.player == CellPlayer.NONE)
                {
                    line.player = this.board[i, j];
                }

                if (line.player != this.board[i, j] || this.board[i, j] == CellPlayer.NONE)
                {
                    line.valid = false;
                }

                line.points.Add((i, j));
            }

            if (line.valid)
            {
                return line;
            }
        }

        // Vertical line
        for (int i = 0; i < this.size; i++)
        {
            line.Clear();
            for (int j = 0; j < this.size; j++)
            {
                if (line.player == CellPlayer.NONE)
                {
                    line.player = this.board[i, j];
                }

                if (line.player != this.board[i, j] || this.board[i, j] == CellPlayer.NONE)
                {
                    line.valid = false;
                }

                line.points.Add((i, j));
            }

            if (line.valid)
            {
                return line;
            }
        }

        // Diagonal line
        line.Clear();
        for (int dx = 0; dx < this.size; dx++)
        {
            if (line.player == CellPlayer.NONE)
            {
                line.player = this.board[dx, dx];
            }

            if (line.player != this.board[dx, dx] || this.board[dx, dx] == CellPlayer.NONE)
            {
                line.valid = false;
            }

            line.points.Add((dx, dx));
        }

        if (line.valid)
        {
            return line;
        }

        // Inverse diagonal line
        line.Clear();
        for (int dx = 0; dx < this.size; dx++)
        {
            int dy = (this.size - 1) - dx;
            if (line.player == CellPlayer.NONE)
            {
                line.player = this.board[dx, dy];
            }

            if (line.player != this.board[dx, dy] || this.board[dx, dy] == CellPlayer.NONE)
            {
                line.valid = false;
            }

            line.points.Add((dx, dy));
        }

        if (line.valid)
        {
            return line;
        }

        return null;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public bool CheckGameOver()
    {
        bool over = true;
        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                if (this.board[i, j] == CellPlayer.NONE)
                {
                    over = false;
                }
            }
        }

        return over;
    }

    // TODO: Remove me
    private Line finalLine = null;
    private void OnDrawGizmos()
    {
        if (finalLine != null)
        {
            foreach (var (x, y) in finalLine.points)
            {
                var cell = this.cells[x, y];

                Gizmos.DrawWireSphere(cell.transform.position, 1f);
            }
        }
    }
}
