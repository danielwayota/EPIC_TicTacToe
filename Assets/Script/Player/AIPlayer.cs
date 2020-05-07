using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : Player
{
    public override string label => "Machine";

    private List<(int, int)> emptySpots;

    private float time = 1f;

    /// ===========================================
    public AIPlayer(CellPlayer state, GameObject piecePrefab, GameManager manager)
        : base(state, piecePrefab, manager)
    {
        this.emptySpots = new List<(int, int)>();
    }

    /// ===========================================
    public override bool DoTheTurn()
    {
        if (this.time > 0f)
        {
            this.time -= Time.deltaTime;

            return false;
        }

        this.emptySpots.Clear();
        var size = this.manager.board.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (this.manager.board[i, j] == CellPlayer.NONE)
                {
                    this.emptySpots.Add((i, j));
                }
            }
        }

        int randomIndex = Random.Range(0, this.emptySpots.Count);
        var (x, y) = this.emptySpots[randomIndex];

        this.manager.AllocatePiece(x, y, this);

        this.time = 1f;
        return true;
    }
}