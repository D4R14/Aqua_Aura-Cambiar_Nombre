using UnityEngine;

public class ParticulaColision : MonoBehaviour
{
    public float puntosQueDa = 1f; // Puntos por cada colisión de partícula
    private ParticleSystem partSystem;
    private ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];

    private void Start()
    {
        partSystem = GetComponent<ParticleSystem>();
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
}
