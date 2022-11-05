using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Screen4;
    public GameObject Screen5;
    public GameObject Screen6;

    [SerializeField] public bool MinigamePractice;
   


    // Start is called before the first frame update
    void Start()
    {
        Screen1.SetActive(true);
        Screen2.SetActive(false);
        Screen3.SetActive(false);
        Screen4.SetActive(false);
        Screen5.SetActive(false);
        Screen6.SetActive(false);

        MinigamePractice = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Page1()
    {
        Screen1.SetActive(true);
        Screen2.SetActive(false);
        
    }

   public void Page2()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(true);
        Screen3.SetActive(false);
    }

   public void Page3()
    {
        Screen2.SetActive(false);
        Screen3.SetActive(true);
        Screen4.SetActive(false);
    }

   public void Page4()
    {
        Screen4.SetActive(true);
        Screen3.SetActive(false);
        Screen5.SetActive(false);
    }

    public void Page5()
    {
        Screen5.SetActive(true);
        Screen4.SetActive(false);
        Screen6.SetActive(false);
    }

    public void Page6()
    {
        Screen6.SetActive(true);
        Screen5.SetActive(false);
    }

    public void MinigameS()
    {
        SceneManager.LoadScene(4);
        Debug.Log("run minigame");
        // create boolean so after minigame is done the player is taken back to the tutorial scene
        MinigamePractice = true;
    }

   public void MinigameE()
    {
        SceneManager.LoadScene(3);
        MinigamePractice = true;
    }

   public void MinigameK()
    {
        SceneManager.LoadScene(2);
        MinigamePractice = true;
    }

   public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
