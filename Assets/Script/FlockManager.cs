using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlockManager : MonoBehaviour
{
    public int speed;
    public List<Boid> boids;
    public CanvasControler canv;

    private Alignment alignment;
    private Cohesion cohesion;
    private Separation separation;
    private FollowWaypoints waypoint;
    private EatFood eatFood;
    private Flee flee;


    void Awake()
    {

        boids = new List<Boid>();
        alignment = new Alignment();
        cohesion = new Cohesion();
        separation = new Separation();
        waypoint = new FollowWaypoints();
        eatFood = new EatFood();
        flee = new Flee();
    }

    void Update()
    {
        if(canv.GetUpdateFlock())
            SetFlockingValues();
        for (int a = boids.Count - 1; a >= 0; --a)
        {

            Boid b = boids[a];
            Vector3 velocity = b.velocity;

            velocity += alignment.GetAlignment(boids, a);
            velocity += cohesion.GetCohesion(boids, a);
            velocity += separation.GetSeparation(boids, a);
            velocity += waypoint.GoToNextWaypoint(boids, a);
            velocity += eatFood.GetEatFood(boids, a);
            velocity += flee.GetFlee(boids, a);

            velocity.Normalize();
            b.velocity = velocity;

            b.lookat = b.position + velocity;
        }
        for (int i = boids.Count - 1; i >= 0; --i)
        {
            if (!boids[i].enemy)            
                boids[i].transform.position += boids[i].velocity * Time.deltaTime * speed;
        }
    }

    public void SetFlockingValues()
    {
        print("Update");
        alignment.minDist = canv.genericMinDist;
        alignment.maxDist = canv.genericMaxDist;
        alignment.scalar = canv.aligmentMagnitude;

        cohesion.minDist = canv.genericMinDist;
        cohesion.maxDist = canv.genericMaxDist;
        cohesion.scalar = canv.choesionMagnitude;

        separation.minDist = canv.genericMinDist;
        separation.maxDist = canv.genericMaxDist;
        separation.scalar = canv.separationMagnitude;

        waypoint.minDist = canv.genericMinDist;
        waypoint.maxDist = canv.genericMaxDist;
        waypoint.scalar = canv.waypointMagnitude;

        eatFood.minDist = canv.genericMinDist;
        eatFood.maxDist = canv.genericMaxDist;
        eatFood.scalar = canv.eatMagnitude;

        flee.minDist = canv.genericMinDist;
        flee.maxDist = canv.genericMaxDist;
        flee.scalar = canv.fleeMagnitud;

        canv.UpdateFlock = false;
    }
}
