using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFollower : MonoBehaviour
{
    public GameObject player;
    Rigidbody rbPlayer;
    void Start()
    {
        rbPlayer = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbPlayer.velocity.x < 0.5f)
        {
            return;
        }
        transform.position = new Vector3(player.transform.position.x - 6.5f, 1.5f, 7);
    }
}
