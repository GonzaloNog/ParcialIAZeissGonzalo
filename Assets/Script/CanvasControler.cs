using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    public int genericMinDist = 1; // distancia minima generica para todos los comportamientos
    public int genericMaxDist = 3; // distancia maxima generica para todos los comportamientos

    public int aligmentMagnitude = 5; // aliniarse
    public int choesionMagnitude = 5; // juntarse
    public int separationMagnitude = 5; // alejarse de los otros boids
    public int waypointMagnitude = 5; // buscar target
    public int eatMagnitude = 5; // atacar
    public int fleeMagnitud = 5; //Escapar de otros Boids

    public bool UpdateFlock = false;

    public Slider min;
    public Slider max;
    public Slider aligment;
    public Slider choesion;
    public Slider separation;
    public Slider waypoint;
    public Slider eat;
    public Slider flee;



    public void Start()
    {
        min.value = genericMinDist;
        max.value = genericMaxDist;
        aligment.value = aligmentMagnitude;
        choesion.value = choesionMagnitude;
        separation.value = separationMagnitude;
        waypoint.value = waypointMagnitude;
        eat.value = eatMagnitude;
        flee.value = fleeMagnitud;
        UpdateFlock = true;
    }
    public void Update()
    {
        if (min.value != genericMinDist)
        {
            genericMinDist = (int)min.value;
            UpdateFlock = true;
        }
        if (max.value != genericMaxDist)
        {
            genericMaxDist = (int)max.value;
            UpdateFlock = true;
        }
        if (aligment.value != aligmentMagnitude)
        {
            aligmentMagnitude = (int)aligment.value;
            UpdateFlock = true;
        }
        if (choesion.value != choesionMagnitude)
        {
            choesionMagnitude = (int)choesion.value;
            UpdateFlock = true;
        }
        if (separation.value != separationMagnitude)
        {
            separationMagnitude = (int)separation.value;
            UpdateFlock = true;
        }
        if (waypoint.value != waypointMagnitude)
        {
            waypointMagnitude = (int)waypoint.value;
            UpdateFlock = true;
        }
        if (eat.value != eatMagnitude)
        {
            eatMagnitude = (int)eat.value;
            UpdateFlock = true;
        }
        if (flee.value != fleeMagnitud)
        {
            fleeMagnitud = (int)flee.value;
            UpdateFlock = true;
        }
    }
    public bool GetUpdateFlock()
    {
        return UpdateFlock;
    }
}
