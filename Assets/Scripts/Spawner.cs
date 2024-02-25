using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] GameObject[] prefabObjects;
    [SerializeField] Transform[] spawner;
    [SerializeField] float secondForSpawn;
    private float time = 0;

    private void Start()
    {
        Initialized(prefabObjects);
    }
        
    private void Update()
    {
        time += Time.deltaTime;

        if(time >= secondForSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                time = 0;

                int spawnPointNumber = Random.Range(0, spawner.Length);

                SetEnemy(enemy, spawner[spawnPointNumber].position);
            }
        }
    }
     private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        
    }


}
