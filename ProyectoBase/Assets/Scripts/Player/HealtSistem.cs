using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealtSistem : MonoBehaviour
{
    public int life;
    [SerializeField] private Slider healthBar;

    public void Update()
    {
        healthBar.GetComponent<Slider>().value = life;
        //si la vida del jugador es menor o igual a 0 se muere
        //cambiar para activar el panel de muerte
        if (life <= 0)
        {
            Debug.Log("HazMuerto");
        }
    }
    /*
    //[SerializeField] private GameObject[] hearts;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Sprite lifeBar;

    private int life;
    
    private bool dead = false;

    private void Start()
    {
        life = 3;
        //life = hearts.Length;
    }   

    private void Update()
    {
        lifeText.text = life.ToString();
        if (dead)
        { 
            Debug.Log("Reaparecer al personaje");
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            //Destroy(hearts[life].gameObject);
            if (life <= 0)
            {
                dead = true;
            }
        }
    }*/
}
