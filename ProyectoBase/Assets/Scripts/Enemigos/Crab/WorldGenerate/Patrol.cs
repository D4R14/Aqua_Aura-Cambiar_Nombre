using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 5;
    [SerializeField] private int closestWaypoint;

    //Asignamos el tag de los waypoints
    private void Start()
    {

    }

    //hacemos que el objeto se mueva hacia el siguiente waypoint
    private void Update()
    {

    }

}
