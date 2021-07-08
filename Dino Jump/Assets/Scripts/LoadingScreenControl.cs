using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreenControl : MonoBehaviour
{
    //public GameObject loadingScreenObject;
    public Slider slider;

    AsyncOperation async;


    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadingScreen(UIForMainMenu.NextSceneName));
    }

    IEnumerator LoadingScreen(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
