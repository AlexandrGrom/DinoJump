using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore;
    public static int bestScore;
    private int FixedTimer;
    public static int GameTimer = 0;
    public static int GameRecordDistance;
    private int CurrentDistance;
    public GameObject player;


    public GameObject scoreObj;
    public GameObject timerObj;

    TextMeshProUGUI scoreText;
    TextMeshProUGUI timerText;

    void Start()
    {
        timerText = timerObj.GetComponent<TextMeshProUGUI>();
        scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        if (PlayerController.isDead)
        {
            timerText.text = GameTimer.ToString();
            scoreText.text = "Bones : " + currentScore;
            return;
        }
        currentScore = 0;
        GameTimer = 0;
        FixedTimer = 0;
        scoreText.text = "Bones : " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        //if(currentScore>bestScore)
        //{
        //    bestScore = currentScore;
        //    scoreText.text = "BestScore: " + bestScore;
        //}
        scoreText.text = "Bones : " + currentScore;

    }

    private void FixedUpdate()
    {
        if (PlayerController.isPaused)
        {
            return;
        }
        if(PlayerController.isDead)
        {
            CurrentDistance = (int)(player.transform.position.x - 121);
            if(CurrentDistance>GameRecordDistance)
            {
                GameRecordDistance = CurrentDistance;
            }
            return;
        }
        FixedTimer += 1;
        if (FixedTimer == 60)
        {
            FixedTimer = 0;
            GameTimer += 1;
            timerText.text = GameTimer.ToString();
        }
    }
}
