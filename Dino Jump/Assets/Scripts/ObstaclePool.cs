using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }
    public static ObstaclePool terrainPooler;

    private void Awake()
    {
        terrainPooler = this;
    }

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

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.Log("tag does not exist");
            return null;
        }
            GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = new Vector3(objectToSpawn.transform.position.x + 500, 0 , 0);
            objectToSpawn.transform.rotation = rotation;

            PoolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
    }
}
