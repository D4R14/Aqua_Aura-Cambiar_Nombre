using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtSistem : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;

    private int life;
    
    private bool dead = false;

    private void Start()
    {
        life = hearts.Length;
    }   

    private void Update()
    {
        if(dead)
        { 
            Debug.Log("Reaparecer al personaje");
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life <= 0)
            {
                dead = true;
            }
        }
    }
}
