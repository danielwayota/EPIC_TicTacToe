using UnityEngine;

public class AIPlayer : Player
{
    /// ===========================================
    public AIPlayer(CellPlayer state, GameObject piecePrefab, GameManager manager)
        : base(state, piecePrefab, manager)
    {
    }
}