using System.Collections.Generic;

public class Line
{
    public bool valid;
    public CellPlayer player;
    public List<(int, int)> points;

    /// ===========================================
    public Line()
    {
        this.valid = false;
        this.player = CellPlayer.NONE;
        this.points = new List<(int, int)>();
    }

    /// ===========================================
    public void Clear()
    {
        this.valid = true;
        this.player = CellPlayer.NONE;
        this.points.Clear();
    }

    public override string ToString()
    {
        string pointsStr = "";

        foreach (var (i, j) in this.points)
        {
            pointsStr += $" <{i}, {j}> ";
        }

        return $"{this.valid} : ({pointsStr})";
    }
}
