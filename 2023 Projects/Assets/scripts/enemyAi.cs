using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    public Transform player;
    public List<Transform> points;
    public int nextId;
    private int idChangeValue = 3;
    public float speed;

    //float dist = Vector3.Distance(other.position, transform.position);

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        //set and get a goal point based off our lists index
        Transform goalPoint = points[nextId];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if ( Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextId == points.Count)
            {
                idChangeValue = -1;
            }
            if (nextId == 0)
            {
                idChangeValue = 1;
            }
        }

    }
}
