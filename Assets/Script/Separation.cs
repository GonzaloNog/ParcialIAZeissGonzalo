using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{
    public int minDist { get; set; }
    public int maxDist { get; set; }
    public int scalar { get; set; }

    public Separation()
    {

    }

    public Vector3 GetSeparation(List<Boid> boids, int current)
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

                float dist = Vector3.Magnitude(dif);
                if (dist <= maxDist && dist >= minDist)
                {
                    dif.Normalize();
                    result += dif / dist;
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
