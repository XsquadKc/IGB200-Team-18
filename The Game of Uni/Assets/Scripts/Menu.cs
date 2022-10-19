using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{


    public void Play()
    {
        SceneManager.LoadScene(sceneName: "MainGame");
    }

    public void Settings()
    {

    }


    public void Quit()
    {
        Application.Quit();
    }
}
