using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public int minDist { get; set; }
    public int maxDist { get; set; }
    public int scalar { get; set; }

    public FollowWaypoints()
    {
    }
    
    public Vector3 GoToNextWaypoint(List<Boid> boids, int current)
    {
        Boid currentBoid = boids[current];        

        if (Vector3.Distance(currentBoid.waypoint.transform.position, currentBoid.transform.position) < maxDist / 2)
            currentBoid.waypoint = currentBoid.waypoint.GetWaypointNext();

        return (currentBoid.waypoint.transform.position - boids[current].transform.position).normalized * scalar;
    }
}
