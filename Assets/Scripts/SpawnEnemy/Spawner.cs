using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] GameObject[] prefabObjects;
    [SerializeField] Transform[] spawner;
    [SerializeField] float secondForSpawn;
    [SerializeField] private float minusTime = 0.000025f;
    private float time = 0;
    private float time_cop = 0;
    public int TimeToAdd = 15;
    
    private void Start()
    {
        Initialized(prefabObjects);
        Zomby();
    }
        
    private void Update()
    {
        time += Time.deltaTime;
        time_cop += Time.deltaTime;
        //это код добавление моба каждые n секунд
        if (time_cop >= TimeToAdd)
        {
            time_cop = 0;
            Initialized(prefabObjects);
        }
        //

        //это уменьшение времени спавна
        secondForSpawn = secondForSpawn - minusTime;
            if (secondForSpawn < 0.1f)
        {
            secondForSpawn = 0.1f;
        }
        //

        if (time >= secondForSpawn)
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
