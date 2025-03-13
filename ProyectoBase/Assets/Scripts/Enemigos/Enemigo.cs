using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public ParticleSystem particles;
    public float destroyDelay = 0.1f; //Tiempo en el que muere el enemigo

    [SerializeField] private int particleCount = 10; //Monedas o puntos aún no se 

    [Header("Enemy Stats")]
    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; 
    }

    //Danio jsjsj Recibir daño

    public void RecibirDanio(int damage)
    {
        currentHealth -= damage; 

        if (currentHealth <= 0) 
        {
            ActivarDestruccion();
        }
    }

    private void ActivarDestruccion()
    {
        if (particles != null)
        {
            particles.transform.parent = null;

            var emission = particles.emission;
            emission.SetBursts(new ParticleSystem.Burst[] {}); // Evita duplicados
            emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, particleCount) });

            particles.Play();
        }

        Destroy(gameObject, destroyDelay);
        //enemySpawner.EnemyDied();
    }
}

