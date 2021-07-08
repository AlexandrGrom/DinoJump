using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerColliderActivation : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
         parent.GetComponent<BoxCollider>().isTrigger = false;
    }
}
