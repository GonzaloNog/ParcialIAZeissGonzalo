using System.Linq;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint wayPointNext;

    public Waypoint GetWaypointNext()
    {
        return wayPointNext;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, wayPointNext.transform.position);
    }
}
