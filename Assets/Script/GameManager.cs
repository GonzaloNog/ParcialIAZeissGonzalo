using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager instanse = null;

    public Waypoint[] waypoints;
    private FlockManager _flockManager;
    private List<Boid> _boids;
    public Transform flockingArea; 
    public GameObject boid;    
    public Transform contenedor;        
      
    private int _width { get { return (int)flockingArea.localScale.x; } }
    private int _height { get { return (int)flockingArea.localScale.y; } }
    private int _depth { get { return (int)flockingArea.localScale.z; } } 
       
    private int _posX { get { return (int)flockingArea.position.x; } }
    private int _posY { get { return (int)flockingArea.position.y; } }
    private int _posZ { get { return (int)flockingArea.position.z; } }

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
        else
            Destroy(this);
    }
    void Start()
    {
        _flockManager = gameObject.GetComponent<FlockManager>();
        _boids = _flockManager.boids;
    }     
    public void NewBoid()
    {
        SpawnBoids();
    }
    private void SpawnBoids()
    {
        Vector3 position = Vector3.zero;
        position = new Vector3((_posX - _width / 2) + UnityEngine.Random.value * _width, (_posY - _height / 2) + UnityEngine.Random.value * _height, (_posZ - _depth / 2) + UnityEngine.Random.value * _depth);
        SpawnBoid(position);
    }

    private void SpawnBoid(Vector3 position)
    {        
        GameObject _boid = boid;
        _boid = Instantiate(_boid, position, Quaternion.identity) as GameObject;
        _boid.transform.parent = contenedor;       
        Vector3 moveTo = flockingArea.position;
        Vector3 dir = moveTo - position;

        Boid boidAux = _boid.AddComponent<Boid>();
        boidAux.velocity = dir.normalized;
        boidAux.waypoint = waypoints[0];
        _boids.Add(boidAux);
    }    
}
