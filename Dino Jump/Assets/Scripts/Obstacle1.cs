using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if(player.transform.position.x>1000)
        {
            if (BoneSpawner.ObstaclesAndBones != null && !BoneSpawner.ObstaclesAndBones.Contains(gameObject) && transform.position.x < player.transform.position.x - 10)
            {
                BoneSpawner.ObstaclesAndBones.Enqueue(gameObject);
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
