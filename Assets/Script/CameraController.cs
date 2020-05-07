using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera targetCamera { get; protected set; }
    public float rumbleSpeed = 1f;
    public float rumbleAmplitude = 1f;

    private float rumblePercent = 0f;

    private Vector3 rumbleDirection;

    private Vector3 anchor;

    protected const float TAU = 2f * Mathf.PI;

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Awake()
    {
        this.targetCamera = GetComponentInChildren<Camera>();
        this.anchor = this.transform.position;
    }

    /// ===========================================
    void Update()
    {
        if (this.rumblePercent != 0f)
        {
            this.rumblePercent = Mathf.Clamp(
                this.rumblePercent - Time.deltaTime * this.rumbleSpeed,
                0f, TAU
            );

            this.transform.position =
                this.anchor +
                this.rumbleDirection * Mathf.Sin(this.rumblePercent) * this.rumbleAmplitude;
        }
    }

    /// ===========================================
    public void Rumble()
    {
        this.rumblePercent = TAU;

        var angle = Random.Range(0f, TAU);
        this.rumbleDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
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
