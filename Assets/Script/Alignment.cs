using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{
    public int minDist { get; set; }
    public int maxDist { get; set; }
    public int scalar { get; set; }

    public Alignment()
    {

    }

    public Vector3 GetAlignment(List<Boid> boids, int current)
    {        
        Vector3 result = Vector3.zero;
        int count = 0;
        for (int i = 0; i < boids.Count; ++i)
        {          
            if (i != current)
            {
                Boid b = boids[current];
                Boid other = boids[i];
                Vector3 bPos = b.position;                
                Vector3 dif = bPos - other.position;
                
                float dist = Vector3.SqrMagnitude(dif);
                if (dist <= maxDist * maxDist && dist >= minDist * minDist)
                {
                    result += other.velocity;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            result /= count;
            result.Normalize();            
            return result * scalar;
        }
        return result;
    }
}
