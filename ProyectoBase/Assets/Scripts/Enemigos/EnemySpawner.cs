using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn enemy settings")] //Configuracion de spawn de enemigos
    [SerializeField] private int life = 20;
    [SerializeField] private BoxCollider boxTrigger;
    private Transform player;



    [Header("Spawn configuration")] //Configuracion de cuantos enemigos spawnear
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int minEnemiesSpawn = 1;
    [SerializeField] private int maxEnemiesSpawn = 5;
    [SerializeField] private int maxEnemiestoGenerate = 10;
    private int enemiesGenerated = 0;
    private int maxEnemiesAlive = 10;
    private int currentEnemiesAlive = 0;

    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private float spawnRadius = 2f;

    private bool isPaused = false;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if(enemiesGenerated > maxEnemiestoGenerate)
        {
            StopCoroutine(SpawnEnemies());
            Destroy(gameObject);
        }
        if(life <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            //Si hay mas enemigos vivos que el maximo permitido, pausamos la generacion de enemigos
            if (currentEnemiesAlive >= maxEnemiesAlive)
            {
                isPaused = true;
                yield return new WaitUntil(() => currentEnemiesAlive <= maxEnemiesAlive - 3); // Espera hasta que al menos 3 enemigos hayan muerto
                isPaused = false;
            }

            //Esperamos un tiempo aleatorio entre minSpawnInterval y maxSpawnInterval
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);  //Esperamos interval segundos

            //Generamos un numero aleatorio de enemigos a spawnear entre minEnemiesSpawn y maxEnemiesSpawn
            int enemiesToSpawn = Random.Range(minEnemiesSpawn, maxEnemiesSpawn);

            for (int i = 0; i < enemiesToSpawn; i++) //Iteramos para spawnear cada enemigo
            {
                if (currentEnemiesAlive >= maxEnemiesAlive) break; // Evita que se generen más enemigos de lo permitido

                float offsetX = Random.Range(-spawnRadius, spawnRadius);
                float offsetZ = Random.Range(-spawnRadius, spawnRadius);
                Vector3 spawnOffset = new Vector3(offsetX, 0, offsetZ);
                Vector3 spawnPosition = (Vector3)gameObject.transform.position + spawnOffset; //Calculamos la posicion de spawn sumando la posicion del spawner y el offset
                currentEnemiesAlive++; //Aumentamos el contador de enemigos actuales
                enemiesGenerated++; //Aumentamos el contador de enemigos generados

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); //Instanciamos el enemigo en la posicion calculada
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Destruimos el collider para que solo se genere una vez
        Destroy(boxTrigger);
        //Generamos 4 enemigos al inicio
        for (int i = 0; i <= 3; i++)
        {
            float offsetX = Random.Range(-spawnRadius, spawnRadius);
            float offsetZ = Random.Range(-spawnRadius, spawnRadius);
            Vector3 spawnOffset = new Vector3(offsetX, 0, offsetZ);
            Vector3 spawnPosition = (Vector3)gameObject.transform.position + spawnOffset;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        //Si el jugador entra en el trigger, empezamos a spawnear enemigos
        if (collision.gameObject.CompareTag("Player") && !isPaused)
        {
            StartCoroutine(SpawnEnemies());
        }
    }
    public void EnemyDied()
    {
        currentEnemiesAlive--;
        if (currentEnemiesAlive < 0) currentEnemiesAlive = 0; //Evita que el contador de enemigos vivos sea negativo
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube();
    }
}

