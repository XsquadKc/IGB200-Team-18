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
        SceneManager.LoadScene(sceneName: "Settings");
    }

    public void Back()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(sceneName: "Tutorial");
    }


}
