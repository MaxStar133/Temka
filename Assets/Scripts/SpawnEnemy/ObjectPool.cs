using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
[SerializeField] private GameObject container;
[SerializeField] private int capacity;
private List<GameObject> pool = new();
    protected void Initialized(GameObject prefab)
    {
        for (int i = 0; i < capacity; i++)
        {
        Debug.Log(capacity);
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
    protected bool TryGetObject(out GameObject result)
    {
    result = pool.FirstOrDefault(p => p.activeSelf == false);
    return result != null;
    }
    protected void Zomby()
    {
    capacity = 1;
    }
}
