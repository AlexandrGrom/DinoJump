using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x - 2.4f, transform.position.y, playerTransform.position.z - 9.4f);

        if(Input.GetKey(KeyCode.Tab))
        {
            Time.timeScale = 0.01f;
        }
    }
    
}
