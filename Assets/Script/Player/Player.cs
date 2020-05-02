using UnityEngine;

public class Player
{
    public CellState state { get; protected set; }
    public GameObject piecePrefab { get; protected set; }

    protected GameManager manager;

    public Player(CellState state, GameObject piecePrefab, GameManager manager)
    {
        this.state = state;
        this.piecePrefab = piecePrefab;
        this.manager = manager;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>Has finish the turn?</returns>
    public virtual bool DoTheTurn()
    {
        return false;
    }
}
