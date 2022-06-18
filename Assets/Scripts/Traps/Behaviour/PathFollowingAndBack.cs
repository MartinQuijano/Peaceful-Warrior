using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingAndBack : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1.5f;

    private int waypointIndex = 0;

    private bool isGoingForward;

    private Vector3 initialPosition;

    private bool isActive = false;

    void Start()
    {
        isActive = true;
        initialPosition = transform.position;
        isGoingForward = true;
    }

    void Update()
    {
        isActive = true;
        if (isGoingForward)
            MoveForward();
        else
            MoveBackward();
    }

    private void MoveForward()
    {
        if (waypointIndex < waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (AtWaypoint(waypoints[waypointIndex].transform))
            {
                waypointIndex += 1;
            }
        }
        else 
            isGoingForward = false;
    }

    private void MoveBackward()
    {
        if (waypointIndex > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (AtWaypoint(waypoints[waypointIndex].transform))
            {
                waypointIndex -= 1;
            }
        }
        else 
            isGoingForward = true;
    }

    private bool AtWaypoint(Transform waypoint)
    {
        if (Vector2.Distance(transform.position, waypoint.position) < Vector2.kEpsilon)
            return true;
        else return false;
    }

    public void Restart(){
        this.GetComponent<Transform>().position = initialPosition;
        waypointIndex = 0;
        isActive = false;
        isGoingForward = true;
        this.enabled = false;
    }

    public bool GetIsActive(){
        return isActive;
    }
}
