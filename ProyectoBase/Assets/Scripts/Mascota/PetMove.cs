using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    [Header("Pet Move variants")]
    [SerializeField] private int speed = 5;
    [SerializeField] private float stop_distance = 2.5f;
    [SerializeField] private float xtreme_distance = 20f;
    [SerializeField] private Transform target;

    public virtual void Start()
    {
        //si no se asigna un target se busca el objeto con el tag "Player"
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void Update()
    {
        //si el target no es nulo y la distancia entre el target y el objeto es mayor a la distancia de parada
        if (target != null)
        {
            //mueve el objeto hacia el target
            if (Vector3.Distance(transform.position, target.position) > stop_distance)
            {
                //mueve el objeto hacia el target
                Vector3 vector;
                vector = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                this.transform.position = vector;
            }
            if (Vector3.Distance(transform.position, target.position) > xtreme_distance)
            {

                {
                    //teletransporta la mascota hasta el target
                    this.transform.position = target.position;
                }
            }
        }
    }
}