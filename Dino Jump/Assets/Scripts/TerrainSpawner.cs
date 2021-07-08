using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            TerrainPool.terrainPooler.SpawnFromPool("Ground", Vector3.zero, Quaternion.identity);
        }

    }
}
