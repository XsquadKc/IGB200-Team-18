using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Dice DiceScript;

    public Transform target;
    public float speed;
    public int numTiles;
    public int currentTile;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        currentTile = 0;
        numTiles = 14;
        if (gameManager.previousPosition != new Vector3(0,0,0))
        {
            DiceScript.value = gameManager.savedValue;
            currentTile = gameManager.tile;
            transform.position = gameManager.previousPosition;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Minigame" && currentTile == DiceScript.value - 1 && gameManager.examComplete == false)
        {
            collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            runMinigame();
        }
        if (collider.tag == "Chance" && currentTile == DiceScript.value - 1)
        {
            gameManager.PlayerTurn("chance");
        }
    }

    public void runMinigame()
    {
        gameManager.savedValue = DiceScript.value;
        gameManager.previousPosition = transform.position;
        gameManager.tile = currentTile;

        
        SceneManager.LoadScene(sceneName: "Exam Minigame");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();


    }

    void FixedUpdate()
    {
        if (DiceScript.value > numTiles - 1)
        {
            DiceScript.value = numTiles;
        }
        Vector3 a = transform.position;
        Vector3 b;
        if (currentTile < DiceScript.value)
        {
            b = GameObject.Find("Tile" + (currentTile + 1).ToString()).transform.position;
            b.y = a.y;

            if (a != b)
            {
                transform.position = Vector3.MoveTowards(a, b, speed);
            }
            else
            {
                currentTile += 1;
            }
        }
        else
        {
            gameManager.moving = false;
        }
        
        
    }
}
