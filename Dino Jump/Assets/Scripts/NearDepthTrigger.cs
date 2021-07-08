using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDepthTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("ObstacleGround"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("neardepthdestroyer1");
        }
        if (other.gameObject.CompareTag("Bone"))
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("neardepthdestroyer2");
        }
    }
}
