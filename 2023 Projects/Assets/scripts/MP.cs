using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MP : MonoBehaviour
{
    public Transform[] platformPosition = new Transform[3];
    int direction = 1;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();

        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed = Time.deltaTime);

        float distance = (target - (Vector2)platformPosition[0].position).magnitude;

        if (distance == 1)
        {
            direction = -1;
        }
    }
    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return platformPosition[1].position;
        }
        else
        {
            return platformPosition[2].position;
        }
    }
    private void OnDrawGizmos()
    {
        if (platformPosition[0] != null && platformPosition[1] != null && platformPosition[2] != null)
        {
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[1].transform.position);
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[2].transform.position);
        }
    }
}
