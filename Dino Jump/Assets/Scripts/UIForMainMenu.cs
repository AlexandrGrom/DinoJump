using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIForMainMenu : MonoBehaviour
{
    //public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject missionMenu;
    public GameObject statsMenu;
    public GameObject settingsMenu;
    public GameObject contentOfScrollBar;
    public GameObject bonusesMenu;
    public GameObject hatsMenu;
    public GameObject premiumMenu;
    public GameObject parachutesMenu;
    public static GameObject TheChosenDino;
    public GameObject[] dinos;
    public Slider volumeSlider;
    public Text menuText;
    public AudioSource music;

    Vector3 point1 = new Vector3(-50, 0, 0);
    Vector3 point2 = new Vector3(-550, 0, 0);
    Vector3 point3 = new Vector3(-1050, 0, 0);
    Vector3 point4 = new Vector3(-1550, 0, 0);
    Vector3 point5 = new Vector3(-2041, 0, 0);

    public GameObject charactersMenu;

    public static string NextSceneName;
    public static string TagForActivateObjectFromMenu;
    public static string LastSceneName;

    public Animator animOfMenu;

    private bool characterMenuIsActive;
    public void StartGame()
    {
        NextSceneName = "GamePlay";
        SceneManager.LoadScene("LoadingScene");
    }
    public void ShowMenu()
    { 
        animOfMenu.Play("menuToLeft");
    }
    public void HideMenu()
    {
        animOfMenu.Play("menuToRight");
    }
    public void ShowOrHide()
    {
        if (animOfMenu.GetCurrentAnimatorStateInfo(0).IsName("MainMenuToLeftMovement"))
        {
            animOfMenu.SetBool("toRight", true);
            animOfMenu.SetBool("toLeft", false);
        }
        else if (animOfMenu.GetCurrentAnimatorStateInfo(0).IsName("MainMenuToRightMovement") || animOfMenu.GetCurrentAnimatorStateInfo(0).IsName("MainMenuIdle"))
        {
            animOfMenu.SetBool("toRight", false);
            animOfMenu.SetBool("toLeft", true);
        }
    }
    public void OpenStore()
    {
        //storeMenu.SetActive(true);
        //menuText.text = "Store";
        LastSceneName = SceneManager.GetActiveScene().name;
        TagForActivateObjectFromMenu = "StoreMenu";
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = "MainMenu";
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            if(storeMenu!=null)
                storeMenu.SetActive(true);
        }
    }
    public void CloseStore()
    {
        //storeMenu.SetActive(false);
        if(LastSceneName == "GamePlay")
        {
            NextSceneName = LastSceneName;
            TagForActivateObjectFromMenu = "none";
            storeMenu.SetActive(false);
            SceneManager.LoadScene("LoadingScene");
            return;
        }
        TagForActivateObjectFromMenu = "none";
        storeMenu.SetActive(false);
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = LastSceneName;
            SceneManager.LoadScene("LoadingScene");
        }
    }
    public void OpenMissions()
    {
        //missionMenu.SetActive(true);
        //menuText.text = "Missions";
        LastSceneName = SceneManager.GetActiveScene().name;
        TagForActivateObjectFromMenu = "MissionsMenu";
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = "MainMenu";
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            if (missionMenu != null)
                missionMenu.SetActive(true);
        }
    }
    public void CloseMissions()
    {
        //missionMenu.SetActive(false);
        TagForActivateObjectFromMenu = "none";
        missionMenu.SetActive(false);
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = LastSceneName;
            SceneManager.LoadScene("LoadingScene");
        }
    }
    public void OpenStatistics()
    {
        //statsMenu.SetActive(true);
        //menuText.text = "Statistics";
        LastSceneName = SceneManager.GetActiveScene().name;
        TagForActivateObjectFromMenu = "StatsMenu";

        if (LastSceneName == "StartMenu")
        {
            NextSceneName = "MainMenu";
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            if (statsMenu != null)
                statsMenu.SetActive(true);
        }
    }
    public void CloseStatistics()
    {
        //statsMenu.SetActive(false);
        TagForActivateObjectFromMenu = "none";
        statsMenu.SetActive(false);
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = LastSceneName;
            SceneManager.LoadScene("LoadingScene");
        }
    }
    public void OpenSettings()
    {
        //settingsMenu.SetActive(true);
        //menuText.text = "Settings";
        LastSceneName = SceneManager.GetActiveScene().name;
        TagForActivateObjectFromMenu = "SettingsMenu";
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = "MainMenu";
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            if (settingsMenu != null)
                settingsMenu.SetActive(true);
        }
    }
    public void CloseSettings()
    {
        //settingsMenu.SetActive(false);
        TagForActivateObjectFromMenu = "none";
        settingsMenu.SetActive(false);
        if (LastSceneName == "StartMenu")
        {
            NextSceneName = LastSceneName;
            SceneManager.LoadScene("LoadingScene");
        }
    }
    private void Start()
    {
        if(TagForActivateObjectFromMenu != null && TagForActivateObjectFromMenu != "none")
        {
            if (TagForActivateObjectFromMenu == "StoreMenu")
                storeMenu.SetActive(true);
            else if (TagForActivateObjectFromMenu == "SettingsMenu")
                settingsMenu.SetActive(true);
            else if (TagForActivateObjectFromMenu == "StatsMenu")
                statsMenu.SetActive(true);
            else if (TagForActivateObjectFromMenu == "MissionsMenu")
                missionMenu.SetActive(true);
            else
            {
                Debug.Log("there is an error in te if statement");
            }
        }
    }


    public void SelectPlayer()
    {

    }

    public void SetPositionOfScrollBar()
    {
        if (contentOfScrollBar.transform.localPosition.x > -300 && contentOfScrollBar.transform.localPosition.x <= -49) 
        {
            SnapToPoint(point1);
            TheChosenDino = dinos[0];
        }
       else if(contentOfScrollBar.transform.localPosition.x < -300 && contentOfScrollBar.transform.localPosition.x >= -800)
        {
            SnapToPoint(point2);
            TheChosenDino = dinos[1];
        }
        else if (contentOfScrollBar.transform.localPosition.x < -800 && contentOfScrollBar.transform.localPosition.x >= -1300)
        {
            SnapToPoint(point3);
            TheChosenDino = dinos[2];
        }
        else if (contentOfScrollBar.transform.localPosition.x < -1300 && contentOfScrollBar.transform.localPosition.x >= -1800)
        {
            SnapToPoint(point4);
            TheChosenDino = dinos[3];
        }
        else if(contentOfScrollBar.transform.localPosition.x < -1800 && contentOfScrollBar.transform.localPosition.x >= -2042)
        {
            SnapToPoint(point5);
            TheChosenDino = dinos[4];
        }
        else
       {
            return;
       }
    }
    void SnapToPoint(Vector3 point)
    {
        contentOfScrollBar.transform.localPosition = Vector3.Lerp(contentOfScrollBar.transform.position, point,1000);

    }


    private void Update()
    {
        if (characterMenuIsActive && Input.GetMouseButtonUp(0))
            SetPositionOfScrollBar();
    }

    public void OpenAnimalMenu()
    {
        charactersMenu.SetActive(true);
        characterMenuIsActive = true;
    }
    public void CloseAnimalMenu()
    {
        charactersMenu.SetActive(false);
        characterMenuIsActive = false;
    }
    public void OpenBonusesMenu()
    {
        bonusesMenu.SetActive(true);
    }
    public void CloseBonusesMenu()
    {
        bonusesMenu.SetActive(false);
    }
    public void OpenHatsMenu()
    {
        hatsMenu.SetActive(true);
    }
    public void CloseHatsMenu()
    {
        hatsMenu.SetActive(false);
    }
    public void OpenParachutesMenu()
    {
        parachutesMenu.SetActive(true);
    }
    public void CloseParachutesMenu()
    {
        parachutesMenu.SetActive(false);
        Debug.Log("closedparachutes");
    }
    public void OpenPremiumMenu()
    {
        premiumMenu.SetActive(true);
    }
    public void ClosePremiumMenu()
    {
        premiumMenu.SetActive(false);
        Debug.Log("closedpremium");
    }
    public void ChangeVolume()
    {
        music = FindObjectOfType<AudioSource>();
        music.volume = volumeSlider.value;
    }
    public void MusicOFF()
    {
        music.mute = true;
    }
    public void MusicON()
    {
        music.mute = false;
    }
}
