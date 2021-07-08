using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float PlayerMoveSpeed;
    public float UpForce;
    public bool isGrounded;
    public bool isFlying;
    public static bool isPaused;
    public static bool isDead;


    private void Awake()
    {
        isPaused = false;
        playerRigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {

        playerRigidBody.velocity = new Vector3(PlayerMoveSpeed, 0, 0);
    }

    private void FixedUpdate()
    {
        if (isPaused || isDead)
        {
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.useGravity = false;
            return;
        }
        else
        {
            if(playerRigidBody.useGravity == false)
                playerRigidBody.useGravity = true;
        }
        if (isFlying)
        {
            playerRigidBody.velocity = new Vector3(PlayerMoveSpeed * Time.deltaTime, -1, 0);
        }
        else
        {
            playerRigidBody.velocity = new Vector3(PlayerMoveSpeed * Time.deltaTime, playerRigidBody.velocity.y, 0);
        }
    }
    void Update()
    {
        
        if (isPaused || isDead)
            return;
        //Debug.Log(playerRigidBody.velocity);
#if UNITY_EDITOR
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Debug.Log("onmousedown" + Time.time);
        //    if (isGrounded)
        //    {
        //        //Debug.Log("jump" + Time.time);
        //        isGrounded = false;
        //        playerRigidBody.AddForce(Vector3.up * UpForce, ForceMode.Force);
        //    }
        //}
#endif
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //    if (isGrounded)
        //    {
        //        isGrounded = false;
        //        playerRigidBody.AddForce(Vector3.up * UpForce, ForceMode.Force);
        //    }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ObstacleGround"))
            isGrounded = true;
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            //SceneManager.LoadScene("GamePlay");
            isDead = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!isGrounded && collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            playerRigidBody.AddForce(Vector3.up * UpForce, ForceMode.Force);
        }
    }
}
