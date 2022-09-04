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
    private Vector3 previousPosition;
    private GameManager gameManager;

    public float x;
    public float y;
    public float z;
    public int savedValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        currentTile = 0;
        numTiles = 14;
        if (PlayerPrefs.HasKey("x") && PlayerPrefs.HasKey("y") && PlayerPrefs.HasKey("z") && PlayerPrefs.HasKey("sv") && PlayerPrefs.HasKey("tile"))
        {
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            z = PlayerPrefs.GetFloat("z");
            DiceScript.value = PlayerPrefs.GetInt("sv");
            currentTile = PlayerPrefs.GetInt("tile");
            Vector3 posVec = new Vector3(x, y, z);
            transform.position = posVec;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Minigame" && gameManager.examComplete == false)
        {
            x = transform.position.x;
            PlayerPrefs.SetFloat("x", x);
            y = transform.position.y;
            PlayerPrefs.SetFloat("y", y);
            z = transform.position.z;
            PlayerPrefs.SetFloat("z", z);
            savedValue = DiceScript.value;
            PlayerPrefs.SetInt("sv", savedValue);
            PlayerPrefs.SetInt("tile", currentTile);

            previousPosition = transform.position;

            collider.gameObject.AddComponent<BoxCollider>().isTrigger = false;
            SceneManager.LoadScene(sceneName: "Exam Minigame");
            Debug.Log("trigger event");
        }
        if (collider.tag == "Chance" && currentTile == DiceScript.value-1)
        {
            gameManager.PlayerTurn("chance");
        }


    }

    public void runMinigame()
    {
        x = transform.position.x;
        PlayerPrefs.SetFloat("x", x);
        y = transform.position.y;
        PlayerPrefs.SetFloat("y", y);
        z = transform.position.z;
        PlayerPrefs.SetFloat("z", z);
        savedValue = DiceScript.value;
        PlayerPrefs.SetInt("sv", savedValue);
        PlayerPrefs.SetInt("tile", currentTile);

        previousPosition = transform.position;

        SceneManager.LoadScene(sceneName: "Exam Minigame");
       // Debug.Log("trigger event");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName: "SampleScene");

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

            if (a != b)
            {
                transform.position = Vector3.MoveTowards(a, b, speed);
            }
            else
            {
                currentTile += 1;
            }
        }
        
        
    }
}
