using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [System.NonSerialized] public Vector3 point0; // 始点
    Vector3 point1; // 制御点1
    Vector3 point2; // 終点

    Vector3 angle_position;

    [System.NonSerialized] public float angle_z;

    [Range(2, 100)]
    public int segmentCount = 50; // 分割数

    int totalCount;

    LineRenderer lineRenderer;

    

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        totalCount = segmentCount + 2;
        lineRenderer.positionCount = totalCount;
    }

    private void Update()
    {
        DrawCurve();
    }

    private void DrawCurve()
    {
        if (point0 == null || point1 == null || point2 == null)
            return;

        point2 = transform.position;
        point1 = (point0 + point2) / 2 + new Vector3(0, 2, 0);

        

        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            Vector3 position = SampleCurve(point0, point2, point1, t);
            if (i == segmentCount - 1)
            {
                angle_position = position;
            }
            lineRenderer.SetPosition(i, position);
        }


        float y = angle_position.y - point2.y;
        float x = angle_position.x - point2.x;

        angle_z = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 180;
        

        lineRenderer.SetPosition(totalCount - 1, point2);
    }

    private Vector3 SampleCurve(Vector3 start, Vector3 end, Vector3 control, float t)
    {
        // Interpolate along line S0: control - start;
        Vector3 Q0 = Vector3.Lerp(start, control, t);
        // Interpolate along line S1: S1 = end - control;
        Vector3 Q1 = Vector3.Lerp(control, end, t);
        // Interpolate along line S2: Q1 - Q0
        Vector3 Q2 = Vector3.Lerp(Q0, Q1, t);
        return Q2; // Q2 is a point on the curve at time t
    }
}
