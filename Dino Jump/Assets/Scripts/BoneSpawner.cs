using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSpawner : MonoBehaviour
{
    public GameObject player;
    Rigidbody playerRb;
    public static Queue<GameObject> ObstaclesAndBones;
    public int maxTimer;
    private int offSetBetWeenBones = 6;
    public LayerMask GroundMask;
    private int positionXofLastObstacle;
    private int positionXofPreviousObstacle;
    private Vector3 position;
    private GameObject SpawnObject;

    // Start is called before the first frame update

    private void Start()
    {
        ObstaclesAndBones = new Queue<GameObject>();
        playerRb = player.GetComponent<Rigidbody>();
        positionXofLastObstacle = (int)player.transform.position.x;
        positionXofPreviousObstacle = positionXofLastObstacle;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if ( player.transform.position.x < positionXofLastObstacle || playerRb.velocity.x < 0.5f)
        {
            return;
        }
        if (ObstaclesAndBones != null && ObstaclesAndBones.Count != 0) 
        {
            var randomCount = Random.Range(2, ObstaclesAndBones.Count);
            //positionXofLastObstacle = 0;
            for (int i = 0; i < randomCount ; i++)
            {
                if(i == 0)
                {
                    SpawnNewBones(60);
                }
                else
                {
                    SpawnNewBones(offSetBetWeenBones);
                }
            }
            positionXofLastObstacle = positionXofPreviousObstacle;
        }
    }
    void SpawnNewBones(int offSet)
    {
        if(ObstaclesAndBones.Count != 0)
        {
            SpawnObject = ObstaclesAndBones.Dequeue();
            position = new Vector3(positionXofPreviousObstacle + offSet, SpawnObject.transform.position.y, 7);//////made change here
            
            if (!Physics.CheckSphere(position, 1.2f, GroundMask, QueryTriggerInteraction.Collide))
            {
                SpawnObject.transform.position = position;
                if(SpawnObject.CompareTag("Bone"))
                {
                    SpawnObject.transform.GetChild(0).gameObject.SetActive(true);
                    SpawnObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

                //Debug.Log("spawningMethod");
            }
            positionXofPreviousObstacle = (int)position.x;
        }
    }
}
