using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject player;
    int timer = 0;
    public int maxFramesForTimer;
    public GameObject[] list;
    Rigidbody rbPlayer;
    public LayerMask GroundMask;

    private void Start()
    {
        //list = GameObject.FindGameObjectsWithTag("Obstacle");
        rbPlayer = player.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (timer == maxFramesForTimer)
        {
            timer = 0;
            if (rbPlayer.velocity.x > .5f) 
                SpawnObstacle();
        }
        else
            timer++;
    }
    private void SpawnObstacle()
    {
        var random = list[Random.Range(0, list.Length - 1)];
        if (random.transform.position.x < player.transform.position.x - 10)
        {
            var position = new Vector3(player.transform.position.x + 30, random.transform.position.y, 7);
            if (!Physics.CheckSphere(position, 1.2f, GroundMask, QueryTriggerInteraction.Collide))
            {
                random.transform.position = position;
                random.SetActive(true);
            }
            else
            {
                Debug.Log(position + "at this position 2 obstacles collided(obstacleSpawner)");
            }
        }
        else
            return;
    }
}
