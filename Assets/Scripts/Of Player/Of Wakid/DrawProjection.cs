using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public LineRenderer lineRenderer;
    public GameObject durianLaunchPoint;
    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;
    public LayerMask collidableLayers;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startDraw = durianLaunchPoint.transform.position;
        Vector3 startSpeed = durianLaunchPoint.transform.up * playerShoot.throwingPower;
        for(float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startDraw + t * startSpeed;
            newPoint.y = startDraw.y + startSpeed.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, collidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}
