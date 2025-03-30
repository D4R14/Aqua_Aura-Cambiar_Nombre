using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveProta : MonoBehaviour
{
    [SerializeField] private Transform cameraCM;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento
    [SerializeField] private float rotationSpeed = 5f; // Velocidad de rotacion
    [SerializeField] private float jumpForce = 10f; // Fuerza del salto

    [SerializeField] private Rigidbody rb;
    private bool isGrounded;

    public void Update()
    {
        //PuedeMoverse(true);
        //axis de movimiento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //movimiento del personaje
        Vector3 movement = cameraCM.forward * v + cameraCM.right * h; //Direccion del movimiento segun la camara
        movement.y = 0;//Para que no se mueva en y

        movement.Normalize(); //Para que no se mueva mas rapido en diagonal

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);//Movimiento del personaje

        //rotacion del personaje
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            Quaternion rote = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rote, rotationSpeed * Time.deltaTime);
        }

        //salto del personaje
        if (Input.GetButtonDown("Jump") && isGrounded) //Para que solo salte si hay suelo abajo :p
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
    }

    //Para que solo salte cuando toque el suelo 
    //Cambiar si queremos doble salto

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollitionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
