using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }
    public static TerrainPool terrainPooler;

    private void Awake()
    {
        terrainPooler = this;
    }

    public Transform playerTransform;
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> PoolDictionary;
    
    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        var pooling = true;
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.Log("tag does not exist");
            return;
        }
        if(pooling)
        {
            GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = new Vector3(objectToSpawn.transform.position.x + 500, -36, 0);
            objectToSpawn.transform.rotation = rotation;

            PoolDictionary[tag].Enqueue(objectToSpawn);
        }
        pooling = false;
    }
}
