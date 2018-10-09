using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Lines : MonoBehaviour
{

    LineRenderer lineRenderer;
    public Transform[] points;
    private Vector3[] vP;
    int seg = 20;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Line();
    }
    void Line()
    {
        seg = points.Length;
        vP = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            vP[i] = points[i].position;
        }
        for (int i = 0; i < seg; i++)
        {
            float t = i / (float)seg;
            lineRenderer.SetVertexCount(seg);
            lineRenderer.SetPositions(vP);
        }

    }
}
