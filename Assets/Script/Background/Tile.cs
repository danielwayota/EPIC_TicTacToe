using UnityEngine;

public class Tile : MonoBehaviour
{
    public void SetColor(Color c)
    {
        var rend = GetComponentInChildren<MeshRenderer>();

        rend.material.SetColor("_EmissionColor", c);
    }

    public void SetScale(float scale)
    {
        this.transform.localScale = Vector3.one * scale;
    }
}
