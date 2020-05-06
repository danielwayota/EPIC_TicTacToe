using UnityEngine;

public class Curtain : MonoBehaviour
{
    public float openSpeed = 1f;

    private RectTransform rect;

    private float percentage;
    private bool running;

    /// ===========================================
    void Awake()
    {
        this.rect = this.GetComponent<RectTransform>();

        this.percentage = 1f;
        this.running = false;

        this.rect.localScale = new Vector3(1, this.percentage, 1);
        Invoke("StartOpenRutine", .25f);
    }

    /// ===========================================
    void Update()
    {
        if (this.running)
        {
            this.percentage = Mathf.Clamp01(this.percentage - Time.deltaTime * this.openSpeed);

            this.rect.localScale = new Vector3(1, this.percentage, 1);

            if (this.percentage == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    /// ===========================================
    void StartOpenRutine()
    {
        this.running = true;
    }
}
