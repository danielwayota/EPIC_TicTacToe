using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera targetCamera { get; protected set; }

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
