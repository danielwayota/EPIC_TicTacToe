using UnityEngine;

public class HumanPlayer : Player
{
    public HumanPlayer(CellState state, GameObject piecePrefab, GameManager manager)
        : base(state, piecePrefab, manager)
    {
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>Has finish the turn?</returns>
    public override bool DoTheTurn()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var mouse = Input.mousePosition;
            Ray ray = this.manager.cameraController.targetCamera.ScreenPointToRay(mouse);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var posibleCell = hit.collider.gameObject;
                Cell cell = posibleCell.GetComponent<Cell>();

                Vector2Int coordinates = cell.boardCoordinates;

                return this.manager.AllocatePiece(coordinates.x, coordinates.y, this);
            }
        }
        return false;
    }
}
