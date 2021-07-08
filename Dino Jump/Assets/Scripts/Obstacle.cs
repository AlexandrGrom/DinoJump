using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (BoneSpawner.ObstaclesAndBones != null
            && !BoneSpawner.ObstaclesAndBones.Contains(gameObject) 
            && player.transform.position.x > transform.position.x + 10)
        {
            BoneSpawner.ObstaclesAndBones.Enqueue(gameObject);
        }
    }
}
