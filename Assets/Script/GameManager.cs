using UnityEngine;

public enum CellState
{
    NONE, CIRCLE, CROSS
}

public struct Player
{
    public CellState state;
    public GameObject piecePrefab;

    public Player(CellState state, GameObject piecePrefab)
    {
        this.state = state;
        this.piecePrefab = piecePrefab;
    }
}

public class GameManager : MonoBehaviour
{
    public GameObject crossPrefab;
    public GameObject circlePrefab;

    private Player[] players;
    private int turn;

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

                go.GetComponent<Cell>().boardCoordinates = new Vector2Int(i, j);
            }
        }

        this.SetUpPlayers();
    }

    void SetUpPlayers()
    {
        this.players = new Player[]
        {
            new Player(CellState.CROSS, this.crossPrefab),
            new Player(CellState.CIRCLE, this.circlePrefab),
        };

        this.turn = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var mouse = Input.mousePosition;
            Ray ray = this.cameraController.targetCamera.ScreenPointToRay(mouse);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var posibleCell = hit.collider.gameObject;
                Cell cell = posibleCell.GetComponent<Cell>();

                Vector2Int coordinates = cell.boardCoordinates;

                CellState cellState = this.board[coordinates.x, coordinates.y];
                if (cellState == CellState.NONE)
                {
                    var player = this.players[this.turn];

                    this.board[coordinates.x, coordinates.y] = player.state;
                    Instantiate(player.piecePrefab, posibleCell.transform.position, Quaternion.identity);

                    this.turn = (this.turn + 1) % this.players.Length;
                }
            }
        }
    }
}
