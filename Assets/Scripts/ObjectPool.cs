using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] int capacity;
    private List<GameObject> pool = new List<GameObject>();

    protected void Initialized(GameObject prefab)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, container.transform);

            spawned.SetActive(false);

            pool.Add(spawned);

        }
    }

    protected void Initialized(GameObject[] prefab)
    {
        for (int i = 0; i < capacity; i++)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[randomIndex], container.transform);

            spawned.SetActive(false);

            pool.Add(spawned);

        }
    }

    protected bool  TryGetObject(out GameObject result)
    {
        result = pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

}
