using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveProta : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento
    //[SerializeField] private float rotationSpeed = 5f; // Velocidad de rotación
    [SerializeField] private float jumpForce = 10f; // Fuerza del salto


    [SerializeField] private Rigidbody rb;
    //[SerializeField] private bool isGrounded;

    public void Update()
    {
        //PuedeMoverse(true);
        //axis de movimiento
        float horizontalImput = Input.GetAxis("Horizontal");
        float verticalImput = Input.GetAxis("Vertical");
        
        //movimiento del personaje
        Vector3 movement = new Vector3(horizontalImput, 0f, verticalImput) * moveSpeed;
        movement.Normalize();
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;

        //rotacion del personaje
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);

        //salto del personaje
        if (Input.GetButtonDown("Jump"))
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    /*public void PuedeMoverse(bool puedeMoverse)
    {
        //axis de movimiento
        float horizontalImput = Input.GetAxis("Horizontal");
        float verticalImput = Input.GetAxis("Vertical");

        //movimiento del personaje
        Vector3 movement = new Vector3(horizontalImput, 0f, verticalImput) * moveSpeed;
        movement.Normalize();
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;

        //rotacion del personaje
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);

        //salto del personaje
        if (Input.GetButtonDown("Jump"))
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }*/
}
