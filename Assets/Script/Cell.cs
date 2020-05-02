using UnityEngine;

public class Cell : MonoBehaviour
{
    [HideInInspector]
    public Vector2Int boardCoordinates;

    public Collider collisionBox;

    public void Disable()
    {
        this.collisionBox.enabled = false;
    }
}
