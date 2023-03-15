using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> pool;
    private readonly T prefab;
    private readonly Transform parent;

    public ObjectPool(T prefab, Transform parent = null)
    {
        pool = new List<T>();
        this.prefab = prefab;
        this.parent = parent;
    }

    public T GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }

        T newObject = Object.Instantiate(prefab, parent);
        pool.Add(newObject);
        return newObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}