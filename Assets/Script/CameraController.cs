using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera targetCamera;

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Awake()
    {
        this.targetCamera = GetComponentInChildren<Camera>();
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="size"></param>
    public void SetSize(float size)
    {
        this.targetCamera.orthographicSize = size;
    }
}
