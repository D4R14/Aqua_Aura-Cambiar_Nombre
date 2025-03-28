using UnityEngine;

public class ParticulaColision : MonoBehaviour
{
    public float puntosQueDa = 1f; // Puntos por cada colisión de partícula
    private ParticleSystem partSystem;
    private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];

    [Header("Movimiento")]
    private Transform target;
    private float speed = 5;

    private void Start()
    {
        partSystem = GetComponent<ParticleSystem>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = partSystem.GetCollisionEvents(other, collisionEvents);

        if (other.CompareTag("Player"))
        {
            // Sumar puntos en base a la cantidad de partículas que colisionaron
            ScoreManager.instance.AddPoints((int)(puntosQueDa * numCollisionEvents));

            // Accedemos a las partículas activas para eliminarlas individualmente
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[partSystem.particleCount];
            int particleCount = partSystem.GetParticles(particles);

            for (int i = 0; i < numCollisionEvents && i < particleCount; i++)
            {
                // Eliminamos la partícula haciendo que su tiempo de vida sea 0
                particles[i].remainingLifetime = 0;
            }

            // Aplicamos el cambio al sistema de partículas
            partSystem.SetParticles(particles, particleCount);
        }
    }

    public void Update()
    {
        //si el target no es nulo y la distancia entre el target y el objeto es mayor a la distancia de parada
        if (target != null)
        {
            //mueve el objeto hacia el target
            if (Vector3.Distance(transform.position, target.position) > 0)
            {
                //mueve el objeto hacia el target
                Vector3 vector;
                vector = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                this.transform.position = vector;
            }
        }
    }
}
