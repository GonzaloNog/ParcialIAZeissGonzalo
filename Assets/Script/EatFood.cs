using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    public int minDist { get; set; }
    public int maxDist { get; set; }
    public int scalar { get; set; }

    public Vector3 GetEatFood(List<Boid> boids, int current)
    {
        Vector3 result = Vector3.zero;
        Boid currentBoid = boids[current];

        if (currentBoid.targetPosition == null)      
            return Vector3.zero;

        if (Vector3.Distance(currentBoid.transform.position, currentBoid.targetPosition.position) < maxDist)
            result = (currentBoid.targetPosition.position - currentBoid.transform.position).normalized * scalar;

        if (Vector3.Distance(currentBoid.transform.position, currentBoid.targetPosition.position) < minDist)
        {
            currentBoid.IncreasePuntos();
            Destroy(currentBoid.targetPosition.gameObject);
                     
        }    
        
        return result;
    }
}
