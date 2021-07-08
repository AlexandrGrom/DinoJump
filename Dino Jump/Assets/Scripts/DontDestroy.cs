using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        var array = FindObjectsOfType<AudioSource>();
        if (array.Length > 1)
            for (int i = 1; i < array.Length; i++) 
            {
                Destroy(array[i].gameObject);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
