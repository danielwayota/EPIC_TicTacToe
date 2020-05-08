using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class DynamicBG : MonoBehaviour
{
    public GameObject tilePrefab;

    public Transform upperCorner;
    public Transform downCorner;

    public int horizontalCount;
    public int verticalCount;

    public float waveAmplitude = 1;
    public float waveSpeed = 1f;

    public Gradient[] gradients;

    private List<Vector3> positions;
    private List<Tile> tiles;

    private float time;

    protected const float TAU = 2 * Mathf.PI;

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.positions = this.GeneratePoints();
        this.ShufflePositions(this.positions);

        this.tiles = new List<Tile>();
        StartCoroutine(this.SpawnTiles());
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        this.time += Time.deltaTime * this.waveSpeed;
        if (this.time > TAU)
        {
            this.time -= TAU;
        }

        for (int j = 0; j < this.tiles.Count; j++)
        {
            float angle = this.time + this.tiles[j].transform.position.y;
            float wave = 1 + (Mathf.Sin(angle) * this.waveAmplitude);

            this.tiles[j].SetScale(wave);
        }
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(.5f);

        int i = 0;

        var gradient = this.gradients[Random.Range(0, this.gradients.Length)];

        while (i < this.positions.Count)
        {
            var pos = this.positions[i];

            var go = Instantiate(this.tilePrefab, pos, Quaternion.identity);
            var tile = go.GetComponent<Tile>();

            var c = gradient.Evaluate(pos.z);
            tile.SetColor(c);

            this.tiles.Add(tile);

            i++;
            yield return null;
        }
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    List<Vector3> GeneratePoints()
    {
        if (this.upperCorner == null || this.downCorner == null)
            return null;

        if (this.horizontalCount <= 0 || this.verticalCount <= 0)
            return null;

        var list = new List<Vector3>();

        float x = this.upperCorner.position.x;
        float y = this.upperCorner.position.y;

        float xDiff = this.upperCorner.position.x - this.downCorner.position.x;
        float yDiff = this.upperCorner.position.y - this.downCorner.position.y;

        float xStep = Mathf.Abs(xDiff) / this.horizontalCount;
        float yStep = -(Mathf.Abs(yDiff) / this.verticalCount);

        for (float i = 0; i <= this.horizontalCount; i++)
        {
            for (float j = 0; j <= this.verticalCount; j++)
            {
                float xx = x + xStep * i;
                float yy = y + yStep * j;


                // Store the height percentage in the Z component
                //  The camera is orthographic so, there is no problem.
                float heightPercent = j / this.verticalCount;
                list.Add(new Vector3(xx, yy, heightPercent));
            }
        }

        return list;
    }

    /// ===========================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="list"></param>
    void ShufflePositions(List<Vector3> list)
    {
        var length = list.Count;

        for (int i = 0; i < length; i++)
        {
            int index = Random.Range(i, length - 1);

            var vector = list[i];
            list[i] = list[index];
            list[index] = vector;
        }
    }

    /// ===========================================
    private void OnDrawGizmos()
    {
        var list = this.GeneratePoints();

        if (list != null)
        {
            foreach (var p in list)
            {
                Gizmos.DrawSphere(p, .25f);
            }
        }
    }
}
