using Unity.Mathematics;
using UnityEngine;

public class ArcRenderer : MonoBehaviour
{
    LineRenderer lr;

    public float velocity;
    public float angle;
    public int resolution;

    float gravity;
    float radianAngle;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics2D.gravity.y);
    }

    private void Start()
    {
        lr.enabled = false;
    }

    public void ShowArc(float Velocity)
    {
        this.velocity = Velocity;
        
        lr.enabled = true;
    }
    private void Update()
    {
        this.angle = Vector2.Angle(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        RenderArc();
    }
    void RenderArc()
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
        arcArray[0] = (Vector2)transform.position;
        for(int i = 1; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;

            arcArray[i] = CalculateArcPoint(t, maxDistance);

        }
        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        var test = new Vector3(transform.position.x+x, transform.position.y+y);
        return test;
    }

}
