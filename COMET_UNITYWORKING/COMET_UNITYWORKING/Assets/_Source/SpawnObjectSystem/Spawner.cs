using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] public ObjectPool objectPool;
    [SerializeField] public float сoinSpawnProbability;
    private float spawnDelay;
    private float timer = 0f;
    private float coinOrDeath;

    private void Start()
    {
        spawnDelay = Random.Range(0f, 10f);
        coinOrDeath = Random.Range(0f, 10f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            coinOrDeath = Random.Range(0f, 10f);

            if (coinOrDeath < сoinSpawnProbability)
            {
                GameObject obj = objectPool.GetObjectCoin();
                obj.transform.position = transform.position;
            }
            else // Спавн стены
            {
                GameObject obj = objectPool.GetObjectDeathWall();
                obj.transform.position = transform.position;
            }

            timer = 0f;
            SetRandomSpawnDelay(); // Устанавливаем новую задержку
        }
    }

    private void SetRandomSpawnDelay()
    {
        spawnDelay = Random.Range(0f, 10f);
    }
}
