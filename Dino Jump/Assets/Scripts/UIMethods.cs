using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIMethods : MonoBehaviour
{
    public GameObject player;
    public GameObject PauseCanvas;
    public GameObject gameEndCanvas;
    GameObject parachute;
    public Text yourTimeText;
    public Text yourRecordText;
    public Text yourBonesText;

    PlayerController controllerPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerController.isDead)
            gameEndCanvas.SetActive(false);
        parachute = player.transform.GetChild(1).gameObject;
        controllerPlayer = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDead)
        {
            gameEndCanvas.SetActive(true);
            yourTimeText.text = "Time : " + ScoreManager.GameTimer;
            yourRecordText.text = "Your Record : " + ScoreManager.GameRecordDistance;
            yourBonesText.text = "Bones : " + ScoreManager.currentScore;
        }
        if (controllerPlayer.isFlying && controllerPlayer.isGrounded)
        {
            parachute.SetActive(false);
            controllerPlayer.isFlying = false;
        }
    }

    public void OpenParachute()
    {
        if(!controllerPlayer.isGrounded)
        {
            controllerPlayer.isFlying = true;
            parachute.SetActive(true);
        }
    }

    public void OpenPauseMenu()
    {
        PauseCanvas.SetActive(true);
        PlayerController.isPaused = true;
    }
    public void ReturnToGame()
    {
        PauseCanvas.SetActive(false);
        PlayerController.isPaused = false;
    }
    public void RefreshGame()
    {
        UIForMainMenu.NextSceneName = "GamePlay";
        PlayerController.isDead = false;
        UIForMainMenu.TagForActivateObjectFromMenu = "none";
        gameEndCanvas.SetActive(false);
        SceneManager.LoadScene("LoadingScene");
    }
    public void JumpIfPressed()
    {
            controllerPlayer.Jump();
    }
    public void OpenShop()
    {
        UIForMainMenu.NextSceneName = "MainMenu";
        UIForMainMenu.LastSceneName = "GamePlay";
        UIForMainMenu.TagForActivateObjectFromMenu = "StoreMenu";
        SceneManager.LoadScene("LoadingScene");
    }
}
