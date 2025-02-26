using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
    private bool isPlayerInArea = false;
    [SerializeField] private GameObject sellerMark;
    //[SerializeField] private GameObject ;
    public void Start()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            isPlayerInArea = true;
            sellerMark.SetActive(true);
            Debug.Log("Sos la verga"); 
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInArea = false;
            sellerMark.SetActive(false);
            Debug.Log("si ja la verga");
        }
    }
}
