using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 5;
    public float projectileDuration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            Destroy(projectile, projectileDuration);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}

