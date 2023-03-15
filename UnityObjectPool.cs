using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int poolSize;
    [SerializeField] Transform poolParent;

    private GameObject[] pool;
    private int poolIndex = 0;

    void Start()
    {
        CreatePool();
        poolParent.parent = null;
    }

    public GameObject GetObject()
    {
        GameObject obj = pool[poolIndex];
        obj.SetActive(true);

        poolIndex++;
        if (poolIndex >= poolSize)
            poolIndex = 0;

        return obj;
    }

    private void CreatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(objectPrefab, poolParent.position, Quaternion.identity, poolParent);
            pool[i].gameObject.SetActive(false);
        }
    }
}
