using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaDePlataforma : MonoBehaviour
{
    [SerializeField] private float timeToFall = 1.5f; // Tiempo antes de colapsar
    [SerializeField] private float destroyDelay = 2f; // Tiempo antes de destruir la plataforma
    private Rigidbody rb;
    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    //Checar si el Player esta en la plataforma

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            Invoke("CollapsePlatform", timeToFall);
        }
    }

    //Colapsar la plataforma

    private void CollapsePlatform()
    {
        rb.isKinematic = false; 
        Destroy(gameObject, destroyDelay); 
    }
}
