using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn enemy settings")]
    [SerializeField] private int life = 20;


    [Header("Spawn configuration")]
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int minEnemiesSpawn = 1;
    [SerializeField] private int maxEnemiesSpawn = 5;

    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private float spawnRadius = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            //Esperamos un tiempo aleatorio entre minSpawnInterval y maxSpawnInterval
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);  //Esperamos interval segundos

            //Generamos un numero aleatorio de enemigos a spawnear entre minEnemiesSpawn y maxEnemiesSpawn
            int enemiesToSpawn = Random.Range(minEnemiesSpawn, maxEnemiesSpawn);
            for (int i = 0; i < enemiesToSpawn; i++) //Iteramos para spawnear cada enemigo
            {
                float offsetX = Random.Range(-spawnRadius, spawnRadius);
                float offsetZ = Random.Range(-spawnRadius, spawnRadius);
                Vector3 spawnOffset = new Vector3(offsetX, 0, offsetZ);
                Vector3 spawnPosition = (Vector3)gameObject.transform.position + spawnOffset; //Calculamos la posicion de spawn sumando la posicion del spawner y el offset

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); //Instanciamos el enemigo en la posicion calculada
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, spawnRadius);
    //}
}
