using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone1 : MonoBehaviour
{
    public GameObject player;
    private GameObject childBone;
    public float rotateSpeed;
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Awake()
    {
        childBone = transform.GetChild(0).gameObject;
        mesh = childBone.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            if (BoneSpawner.ObstaclesAndBones != null && !BoneSpawner.ObstaclesAndBones.Contains(gameObject) && player.transform.position.x > transform.position.x + 10)
            {
                BoneSpawner.ObstaclesAndBones.Enqueue(gameObject);
            }
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0); 
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("ObstacleGround"))
        //{
        //    childBone.SetActive(false);
        //}
        if (other.gameObject.CompareTag("Player"))
        {
            childBone.GetComponent<ParticleSystem>().Play();
            //Invoke("DeactivateObject", 1f);
            DeactivateObject();
            ScoreManager.currentScore += 1;
        }
    }
    void DeactivateObject()
    {
        mesh.enabled = false;
        //childBone.SetActive(false);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("ObstacleGround"))
    //    {
    //        childBone.SetActive(false);
    //    }
    //}
}
