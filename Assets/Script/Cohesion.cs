using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : MonoBehaviour
{
    public int minDist { get; set; }
    public int maxDist { get; set; }
    public int scalar { get; set; }

    public Cohesion()
    {

    }
    
    public Vector3 GetCohesion(List<Boid> boids, int current)
    {
        Vector3 result = Vector3.zero;
        int count = 0;
        for (int i = 0; i < boids.Count; ++i)
        {            
            if (i != current)
            {
                Boid b = boids[current];
                Boid other = boids[i];
                Vector3 otherPos = other.position;
                Vector3 dif = otherPos - b.position;

                
                float dist = Vector3.SqrMagnitude(dif);
                if (dist <= maxDist * maxDist && dist >= minDist * minDist)
                {
                    result += otherPos;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            result /= count;
            Vector3 dir = result - boids[current].position;
            return dir.normalized * scalar;
        }
        return result;
    }
}
