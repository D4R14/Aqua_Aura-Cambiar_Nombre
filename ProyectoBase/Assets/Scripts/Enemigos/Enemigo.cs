using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public ParticleSystem particles;
    public float destroyDelay = 0.1f; //Tiempo en el que muere el enemigo

    public Animator animator;

    [SerializeField] private int particleCount = 10; //Monedas o puntos aún no se 

    [Header("Enemy Stats")]
    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        //Inicializamos la vida del enemigo
        currentHealth = maxHealth;
        //iniciamos la animación de caminar
        animator.SetBool("isWalking", true);    
    }

    //Danio jsjsj Recibir daño

    public void RecibirDanio(int damage)
    {
        //Restamos la vida del enemigo
        currentHealth -= damage;
        //Si la vida del enemigo es menor o igual a 0, lo destruimos
        if (currentHealth <= 0) 
        {
            ActivarDestruccion();
        }
    }

    private void ActivarDestruccion()
    {
        //si tiene particulas
        if (particles != null)
        {
            //Instanciamos las particulas
            particles.transform.parent = null;

            //Configuramos las particulas
            var emission = particles.emission;
            emission.SetBursts(new ParticleSystem.Burst[] {}); // Evita duplicados
            emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, particleCount) });
            //Reproducimos las particulas
            particles.Play();
        }

        //Destruimos el enemigo
        Destroy(gameObject, destroyDelay);
        //enemySpawner.EnemyDied();
    }
}

