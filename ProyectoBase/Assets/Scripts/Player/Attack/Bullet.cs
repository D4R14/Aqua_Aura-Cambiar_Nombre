using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime;
    private int damage = 1; // Daño que causa la bala

    public void SetLifeTime(float time)
    {
        lifeTime = time;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                enemigo.RecibirDanio(damage); // La bala resta vida al enemigo
            }
        }

        Destroy(gameObject); // La bala se destruye al colisionar
    }

    public void SetDamage(int newDamage) 
    {
        damage = newDamage;
    }
}
