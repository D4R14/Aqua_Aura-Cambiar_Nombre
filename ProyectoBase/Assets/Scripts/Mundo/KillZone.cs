using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

//Es muy injusto?
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position; // Reaparecer al personaje 
        }
    }
}