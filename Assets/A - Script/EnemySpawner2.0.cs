using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject normalEnemyPrefab;      // Prefab standardowego przeciwnika
    public GameObject strongEnemyPrefab;      // Prefab przeciwnika wymagaj¹cego 3 kolizji
    public GameObject healthPackPrefab;       // Prefab apteczki
    public GameObject shieldPickupPrefab;     // Prefab tarczy
    public Transform spawnPoint;              // Punkt, z którego pojawiaj¹ siê przeciwnicy
    public float spawnInterval = 2f;          // Czêstotliwoœæ spawnów
    public float shieldSpawnInterval = 15f;   // Czêstotliwoœæ pojawiania siê tarczy
    private float spawnX = 2f;                // Pozycja X (poza ekranem)

    private float shieldSpawnTimer;
    

    private void Start()
    {
        // Regularne spawnowanie przeciwników
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
        shieldSpawnTimer = shieldSpawnInterval;
    }

    private void Update()
    {
        // Sprawdzanie, czy czas na spawn tarczy
        shieldSpawnTimer -= Time.deltaTime;
        if (shieldSpawnTimer <= 0)
        {
            SpawnShieldPickup();
            shieldSpawnTimer = shieldSpawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        float chance = Random.Range(0f, 1f);
        GameObject enemyPrefab;

        if (chance <= 0.25f)
        {
            enemyPrefab = strongEnemyPrefab;
        }
        else
        {
            enemyPrefab = normalEnemyPrefab;
        }

        // Spawn przeciwnika
        float spawnY = Random.Range(-0.9f, 0.9f);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        Instantiate(enemyPrefab, new Vector2(spawnPoint.position.x, Random.Range(-0.9f, 0.9f)), Quaternion.Euler(0, 0, 90));

    }

    private void SpawnShieldPickup()
    {
        // Spawn tarczy
        Instantiate(shieldPickupPrefab, new Vector2(spawnPoint.position.x, Random.Range(-0.9f, 0.9f)), Quaternion.Euler(0, 0, 0));
    }
}
