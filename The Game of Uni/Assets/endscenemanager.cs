using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscenemanager : MonoBehaviour
{
    public GameObject ScreenE;
    public GameObject ScreenS;
    public GameObject ScreenK;

    public float experience;
    public float social;
    public float knowledge;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        ScreenE.SetActive(false);
        ScreenS.SetActive(false);
        ScreenK.SetActive(false);


        if(gameManager.experienceScore > gameManager.socialScore && gameManager.experienceScore > gameManager.knowledgeScore)
        {
            ScreenE.SetActive(true);
            Debug.Log("experience won");
        }
        if (gameManager.socialScore > gameManager.experienceScore && gameManager.socialScore > gameManager.knowledgeScore)
        {
            ScreenS.SetActive(true);
            Debug.Log("social won");
        }
        if (gameManager.knowledgeScore > gameManager.socialScore && gameManager.knowledgeScore > gameManager.experienceScore)
        {
            ScreenK.SetActive(true);
            Debug.Log("knowledge won");
        }
        else
        {
            ScreenE.SetActive(true);
            Debug.Log("nothing won??");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
