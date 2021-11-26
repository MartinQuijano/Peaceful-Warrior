using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PathFollowing : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1.5f;

    private int waypointIndex = 0;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (AtWaypoint(waypoints[waypointIndex].transform))
            {
                waypointIndex += 1;
            }
        }
        else waypointIndex = 0;
    }

    private bool AtWaypoint(Transform waypoint)
    {
        if (Vector2.Distance(transform.position, waypoint.position) < Vector2.kEpsilon)
            return true;
        else return false;
    }
}
