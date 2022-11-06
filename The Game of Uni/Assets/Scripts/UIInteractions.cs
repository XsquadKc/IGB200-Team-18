using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCard()
    {
        gameManager.PlayCard();
    }

    public void CompleteTurn()
    {
        gameManager.CompleteTurn();
    }

    public void ChooseDegree(int choice)
    {
        gameManager.ChooseDegree(choice);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Settings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }

}
