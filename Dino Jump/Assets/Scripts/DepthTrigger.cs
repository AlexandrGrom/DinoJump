using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.isDead = true;
            //Time.timeScale = 0;
        }
    }
}
