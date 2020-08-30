using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{
    public Color lineColor;

    // using list
    private List<Transform> waypoint = new List<Transform>(); 

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        // makes a waypoint system using parent-child relationship
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        waypoint = new List<Transform>();

        // gets the index for each child in the waypoint system
        for(int i = 0; i < pathTransform.Length; i++)
        {
            // checks if pathTransform of current waypoint is not equal to current transform
            if (pathTransform[i] != transform)
            {
                waypoint.Add(pathTransform[i]); // pushes to waypoint list
            }
        
        }

        // draws a line for the waypoints
        for (int x = 0; x < waypoint.Count; x++)
        {
            Vector3 curWayPoint = waypoint[x].position; // gets the current position of the waypoint
            Vector3 prevWayPoint = Vector3.zero; // previous waypoint

            // connects the previous waypoint to the current waypoint
            if (x > 0) // if waypoint index is greater than 0
            {
                //  previous waypoint will not return negative values
                prevWayPoint = waypoint[x - 1].position;
            }
            else if (x == 0 && waypoint.Count > 1)
            {
                // takes the last waypoint in the list
                prevWayPoint = waypoint[waypoint.Count - 1].position;
            }
        
            Gizmos.DrawLine(prevWayPoint, curWayPoint); // makes the path visible
            Gizmos.DrawWireSphere(curWayPoint, 0.4f); // draws spheres for the waypoints
        } 
    }


}
