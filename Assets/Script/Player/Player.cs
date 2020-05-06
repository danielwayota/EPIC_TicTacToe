using UnityEngine;

public abstract class Player
{
    public CellPlayer state { get; protected set; }
    public GameObject piecePrefab { get; protected set; }

    protected GameManager manager;

    public abstract string label { get; }

    /// ===========================================
    public Player(CellPlayer state, GameObject piecePrefab, GameManager manager)
    {
        this.state = state;
        this.piecePrefab = piecePrefab;
        this.manager = manager;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <returns>Has finish the turn?</returns>
    public virtual bool DoTheTurn()
    {
        throw new System.NotImplementedException();
    }
}
